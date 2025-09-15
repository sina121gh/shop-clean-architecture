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
using Shop.Application.Enums;
using Shop.Persistence.Extensions;

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
            string? query, int? categoryId, int? minPrice, int? maxPrice, string? sortBy, SortDirection sortDirection)
        {
            var products = _context.Products.AsQueryable();

            products = ApplySearch(products, query);

            products = ApplyFilter(products, categoryId, minPrice, maxPrice);

            if (!string.IsNullOrEmpty(sortBy))
                products = products.Sort(sortBy, sortDirection);

            return await products.ToPaginatedResultAsync(pageNumber, pageSize);
        }

        public async Task<Product?> GetProductByIdIncludingCategory(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == productId);
        }

        private IQueryable<Product> ApplyFilter(IQueryable<Product> products,
            int? categoryId, decimal? minPrice, decimal? maxPrice)
        {
            if (categoryId != null)
                products = products.Where(p => p.CategoryId == categoryId);

            if (minPrice != null)
                products = products.Where(p => p.Price >= minPrice);

            if (maxPrice != null)
                products = products.Where(p => p.Price <= maxPrice);

            return products;
        }


        private IQueryable<Product> ApplySearch(IQueryable<Product> products, string? query)
        {
            return products.Where(p => EF.Functions.Like(p.Name, $"%{query}%")
                || EF.Functions.Like(p.Description, $"%{query}%"));
        }
    }
}
