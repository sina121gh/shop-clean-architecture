namespace Shop.Application.DTOs
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (decimal)PageSize);

        public PagedResult(IReadOnlyList<T> items, int pageNumber, int pageSize, int totalRecords)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }
}
