using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
        public int WaiterId {  get; set; } // Clave foránea para Mozo
        public Waiter Waiter { get; set; }

        public Table() 
        {
            Capacity = 2;
            IsOccupied = false;
        }

        // Método para marcar la mesa como ocupada
        public void MarkAsOccupied()
        {
            IsOccupied = true;
        }

        // Método para marcar la mesa como libre
        public void MarkAasAvailable()
        {
            IsOccupied = false;
        }
    }
}
