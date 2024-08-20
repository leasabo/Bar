using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bar.Domain.Entities;

namespace Bar.Application.Commands
{
    public class CreateTableCommand : IRequest<Table>
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int WaiterId { get; set; }
    }
}