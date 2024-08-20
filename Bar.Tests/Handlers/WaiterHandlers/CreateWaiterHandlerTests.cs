using AutoMapper;
using Bar.Application.Handlers.WaiterHandlers;
using Bar.Domain.Entities;
using Bar.Domain.Interfaces;
using Bar.Infraestructure.Repositories;
using FluentAssertions;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Bar.Tests.Handlers.WaiterHandlers
{
    public class CreateWaiterHandlerTests
    {
        private readonly IWaiterRepository _waiterRepository;
        private readonly IMapper _mapper;
        private readonly CreateWaiterHandler _handler;

        public CreateWaiterHandlerTests()
        {
            _waiterRepository = Substitute.For<IWaiterRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateWaiterHandler(_waiterRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldCreateWaiter()
        {
            // Arrange
            var command = new CreateWaiterCommand
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var waiter = new Waiter
            {
                Id = 1,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            _mapper.Map<Waiter>(command).Returns(waiter);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(waiter);
            await _waiterRepository.Received(1).AddAsync(waiter);
        }
    }
}
