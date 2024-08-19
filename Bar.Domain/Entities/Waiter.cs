using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Domain.Entities
{
    // Entidad Mozo
    public class Waiter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Table> Tables { get; set; } = new List<Table>(); // Colección con mesas

        // Método para obtener el nombre completo del mozo
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
