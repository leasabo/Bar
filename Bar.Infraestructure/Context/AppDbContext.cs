using Bar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Infraestructure.Context
{
    public class AppDbContext:DbContext
    {
        // Constructor para inicializar el contexto de la BBDD y permite
        // inyección de dependencias aceptando opciones como parámetro
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        
        // DBSet es una clase en Entity Framework que
        // representa una colección de entidades en BBDD
        public DbSet<Waiter> Waiters { get; set; }
    }
}
