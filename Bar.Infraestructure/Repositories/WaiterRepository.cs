using Bar.Domain.Entities;
using Bar.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bar.Domain.Interfaces;

namespace Bar.Infraestructure.Repositories
{
    public class WaiterRepository : IWaiterRepository
    {
        private readonly AppDbContext _context;

        public WaiterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Waiter> GetByIdAsync(int id)
        {
            return await _context.Waiters.Include(w => w.Tables).FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Waiter>> GetAllAsync()
        {
            return await _context.Waiters.Include(w => w.Tables).ToListAsync();
        }

        public async Task AddAsync(Waiter waiter)
        {
            await _context.Waiters.AddAsync(waiter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Waiter waiter)
        {
            _context.Waiters.Update(waiter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var waiter = await GetByIdAsync(id);
            if (waiter != null)
            {
                _context.Waiters.Remove(waiter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
