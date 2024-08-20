using Bar.Domain.Entities;
using MediatR;

namespace Bar.Application.Commands
{
    public class CreateWaiterCommand : IRequest<Waiter>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
