using System.Collections.Generic;
using System.Threading.Tasks;
using Bar.Domain.Entities;

namespace Bar.Domain.Interfaces
{
    public interface IWaiterRepository
    {
        Task<Waiter> GetByIdAsync(int id);
        Task<IEnumerable<Waiter>> GetAllAsync();
        Task AddAsync(Waiter waiter);
        Task UpdateAsync(Waiter waiter);
        Task DeleteAsync(int id);
    }
}
