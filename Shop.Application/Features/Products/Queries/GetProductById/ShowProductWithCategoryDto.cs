using Shop.Application.DTOs.Category;
using Shop.Application.Features.Products.Queries.GetAllProducts;

namespace Shop.Application.Features.Products.Queries.GetProductById
{
    public record ShowProductWithCategoryDto : ShowProductDto
    {
        public ShowCategoryDto Category { get; set; }
    }
}
