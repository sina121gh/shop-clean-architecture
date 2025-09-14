using Shop.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsParameters : PaginatedRequestParameters
    {
        public int? CategoryId { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public string? Query { get; set; }
    }
}
