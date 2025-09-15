using Shop.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Parameters
{
    public class FilterAllEntitiesParameters : PaginatedRequestParameters
    {
        public string? Query { get; set; }

        public string SortBy { get; set; } = "Id";

        public SortDirection SortDirection { get; set; } = SortDirection.Asc;
    }
}
