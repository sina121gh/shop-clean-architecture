namespace Shop.Application.Parameters
{
    public class PaginatedRequestParameters
    {
        const int _maxPageSize = 50;
        int _pageSize = 10;
        int _pageNumber = 1;

        public int PageNumber
        {
            get
            { return _pageNumber; }
            set
            {
                _pageNumber = value < 1 ? 1 : value;
            }
        }

        public int PageSize
        {
            get
            { return _pageSize; }
            set
            {
                _pageSize = Math.Min(_maxPageSize, value);
            }
        }
    }
}
