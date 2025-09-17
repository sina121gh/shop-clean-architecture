using Shop.Application.Enums;

namespace Shop.Application.Parameters
{
    public class FilterAllEntitiesParameters : PaginatedRequestParameters
    {
        public string? Query { get; set; }

        public string SortBy { get; set; } = "Id";

        public SortDirection SortDirection { get; set; } = SortDirection.Asc;
    }
}
