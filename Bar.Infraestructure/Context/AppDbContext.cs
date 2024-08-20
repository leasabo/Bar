using Bar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        // Constructor para inicializar el contexto de la BBDD y permite
        // inyección de dependencias aceptando opciones como parámetro
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DBSet es una clase en Entity Framework que
        // representa una colección de entidades en BBDD
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations (if needed)
            modelBuilder.Entity<Waiter>()
                .HasMany(w => w.Tables)
                .WithOne(t => t.Waiter)
                .HasForeignKey(t => t.WaiterId);

            modelBuilder.Entity<Table>()
                .HasOne(t => t.Waiter)
                .WithMany(w => w.Tables)
                .HasForeignKey(t => t.WaiterId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Table)
                .WithMany()
                .HasForeignKey(r => r.TableId);
        }
    }
}
