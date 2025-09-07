using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalRecords / (decimal)pageSize);
            TotalRecords = totalRecords;
            Data = data;
            Succeeded = true;
            Errors = null;
            Message = null;
        }
    }
}
