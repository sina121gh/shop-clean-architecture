using Shop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<PagedResult<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task AddAsync(T entity);
        Task<bool> DoesExistByIdAsync(int id);

        Task<bool> SaveChangesAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
