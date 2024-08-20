using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bar.Domain.Entities;
using Bar.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Bar.Infraestructure.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _context.Tables.Include(t => t.Waiter).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _context.Tables.Include(t => t.Waiter).ToListAsync();
        }

        public async Task AddAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var table = await GetByIdAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
