using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Persistence;
using Shop.Application.DTOs;

namespace Shop.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<Product>> FilterProductsAsync(int pageNumber, int pageSize,
            int? categoryId, decimal? minPrice, decimal? maxPrice)
        {
            var products = _context.Products.AsQueryable();

            if (categoryId != null)
                products = products.Where(p => p.CategoryId == categoryId);

            if (minPrice != null)
                products = products.Where(p => p.Price >=  minPrice);

            if (maxPrice != null)
                products = products.Where(p => p.Price <= maxPrice);

            var totalRecords = await products.CountAsync();
            var items = await products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>(items, pageNumber, pageSize, totalRecords);
        }

        public async Task<Product?> GetProductByIdIncludingCategory(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}
