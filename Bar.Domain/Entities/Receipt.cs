using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Domain.Entities
{
    // Entidad para el Ticket
    public class Receipt
    {
        public int Id { get; set; }
        public int TableId { get; set; } // Clave foránea para Mesa
        public Table Table { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EmissionDate { get; set; }
        
        public void UpdateTotal(decimal amount)
        {
            TotalAmount = amount;
        }
    }
}
