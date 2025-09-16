using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Categories.Commands.Create
{
    public record CreateCategoryDto
    {
        public string Name { get; set; }
    }
}
