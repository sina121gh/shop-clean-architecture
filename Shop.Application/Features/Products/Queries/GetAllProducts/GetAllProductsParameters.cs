
namespace Shop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsParameters : FilterAllEntitiesParameters
    {
        public int? CategoryId { get; set; }

        public bool? IsActive { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }
    }
}
