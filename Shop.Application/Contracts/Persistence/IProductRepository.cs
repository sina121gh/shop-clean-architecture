using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.DTOs;

namespace Shop.Application.Persistence
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetProductByIdIncludingCategory(int productId);

        Task<PagedResult<Product>> FilterProductsAsync(int pageNumber, int pageSize,
            string? query, int? categoryId, decimal? minPrice, decimal? maxPrice);
    }
}
