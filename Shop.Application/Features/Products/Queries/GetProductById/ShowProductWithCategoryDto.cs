using Shop.Application.DTOs.Category;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetProductById
{
    public record ShowProductWithCategoryDto : ShowProductDto
    {
        public ShowCategoryDto Category { get; set; }
    }
}
