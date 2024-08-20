using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bar.Domain.Entities;
using Bar.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Bar.Domain.Interfaces;

namespace Bar.Infraestructure.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppDbContext _context;

        public ReceiptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Receipt> GetByIdAsync(int id)
        {
            return await _context.Receipts.Include(r => r.Table).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _context.Receipts.Include(r => r.Table).ToListAsync();
        }

        public async Task AddAsync(Receipt receipt)
        {
            await _context.Receipts.AddAsync(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var receipt = await GetByIdAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
