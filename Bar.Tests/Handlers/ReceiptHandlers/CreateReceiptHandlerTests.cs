using Bar.Application.Handlers.ReceiptHandlers;
using Bar.Domain.Entities;
using Bar.Infraestructure.Repositories;
using FluentAssertions;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Bar.Domain.Interfaces;
using AutoMapper;

namespace Bar.Tests.Handlers.ReceiptHandlers
{
    public class CreateReceiptHandlerTests
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly CreateReceiptHandler _handler;

        public CreateReceiptHandlerTests()
        {
            _receiptRepository = Substitute.For<IReceiptRepository>();
            var mapper = Substitute.For<IMapper>();
            _handler = new CreateReceiptHandler(_receiptRepository, mapper);
        }

        [Fact]
        public async Task Handle_ShouldCreateReceipt()
        {
            // Arrange
            var command = new CreateReceiptCommand
            {
                TableId = 1,
                TotalAmount = 100.00m,
                EmissionDate = DateTime.UtcNow
            };

            var receipt = new Receipt
            {
                Id = 1,
                TableId = command.TableId,
                TotalAmount = command.TotalAmount,
                EmissionDate = command.EmissionDate
            };

            var mapper = Substitute.For<IMapper>();
            mapper.Map<Receipt>(command).Returns(receipt);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(receipt);
            await _receiptRepository.Received(1).AddAsync(receipt);
        }
    }
}
