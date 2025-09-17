namespace Shop.Application.Features.Products.Queries.GetAllProducts
{
    public record ShowProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

    }
}
