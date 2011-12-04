using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.Paging
{
    public interface IPaginatedList
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
