using System.Collections.Generic;
using System.Threading.Tasks;
using Bar.Domain.Entities;

namespace Bar.Domain.Interfaces
{
    public interface IReceiptRepository
    {
        Task<Receipt> GetByIdAsync(int id);
        Task<IEnumerable<Receipt>> GetAllAsync();
        Task AddAsync(Receipt receipt);
        Task UpdateAsync(Receipt receipt);
        Task DeleteAsync(int id);
    }
}
