using Azure;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.DTOs;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<bool> DoesExistByIdAsync(int id) => await _dbSet.FindAsync(id) != null;

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public async Task<PagedResult<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet.AsQueryable();

            return await query.ToPaginatedResultAsync(pageNumber, pageSize);
        }
    }
}
