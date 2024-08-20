using Bar.Application.Handlers.TableHandlers;
using Bar.Domain.Entities;
using Bar.Infraestructure.Repositories;
using FluentAssertions;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Bar.Tests.Handlers.TableHandlers
{
    public class CreateTableHandlerTests
    {
        private readonly ITableRepository _tableRepository;
        private readonly CreateTableHandler _handler;

        public CreateTableHandlerTests()
        {
            _tableRepository = Substitute.For<ITableRepository>();
            var mapper = Substitute.For<IMapper>();
            _handler = new CreateTableHandler(_tableRepository, mapper);
        }

        [Fact]
        public async Task Handle_ShouldCreateTable()
        {
            // Arrange
            var command = new CreateTableCommand
            {
                Number = 1,
                Capacity = 4,
                WaiterId = 1
            };

            var table = new Table
            {
                Id = 1,
                Number = command.Number,
                Capacity = command.Capacity,
                WaiterId = command.WaiterId
            };

            var mapper = Substitute.For<IMapper>();
            mapper.Map<Table>(command).Returns(table);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(table);
            await _tableRepository.Received(1).AddAsync(table);
        }
    }
}
