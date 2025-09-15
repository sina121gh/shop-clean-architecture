using Microsoft.EntityFrameworkCore;
using Shop.Application.DTOs;
using Shop.Application.Enums;
using Shop.Application.Persistence;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Extensions;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<Category>> FilterCategoriesAsync(int pageNumber, int pageSize,
            string? query, string? sortBy, SortDirection sortDirection)
        {
            var categories = _context.Categories.AsQueryable();

            categories = ApplySearch(categories, query);

            if (!string.IsNullOrEmpty(sortBy))
                categories = categories.Sort(sortBy, sortDirection);

            return await categories.ToPaginatedResultAsync(pageNumber, pageSize);
        }

        private IQueryable<Category> ApplySearch(IQueryable<Category> categories, string? query)
        {
            return categories.Where(p => EF.Functions.Like(p.Name, $"%{query}%"));
        }
    }
}
