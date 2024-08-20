using Bar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Application.Commands
{
    public class CreateReceiptCommand : IRequest<Receipt>
    {
        public int TableId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EmissionDate { get; set; }
    }
}
