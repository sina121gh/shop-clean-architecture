using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdIncludingCategory(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}
