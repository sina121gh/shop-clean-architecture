using Shop.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Categories.Queries.GetAll
{
    public class GetAllUsersParameters : FilterAllEntitiesParameters
    {
        public bool? IsAdmin { get; set; }
    }
}
