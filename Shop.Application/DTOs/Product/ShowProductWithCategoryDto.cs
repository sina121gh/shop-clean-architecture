using Shop.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTOs.Product
{
    public record ShowProductWithCategoryDto : ShowProductDto
    {
        public ShowCategoryDto Category { get; set; }
    }
}
