using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<bool> DoesExistByIdAsync(int id);

        Task<bool> SaveChangesAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
