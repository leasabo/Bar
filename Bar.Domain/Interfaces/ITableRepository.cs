using System.Collections.Generic;
using System.Threading.Tasks;
using Bar.Domain.Entities;

namespace Bar.Domain.Interfaces
{
    public interface ITableRepository
    {
        Task<Table> GetByIdAsync(int id);
        Task<IEnumerable<Table>> GetAllAsync();
        Task AddAsync(Table table);
        Task UpdateAsync(Table table);
        Task DeleteAsync(int id);
    }
}
