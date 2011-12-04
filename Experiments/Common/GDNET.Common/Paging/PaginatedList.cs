using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.Paging
{
    public class PaginatedList<T> : List<T>, IPaginatedList
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);

            base.AddRange(items);
        }

        /// <summary>
        /// Get a page of items. If pageIndex = -1 and pageSize = -1, it means we do not need paging
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="pageIndex">Index of the page, start from 0</param>
        /// <param name="pageSize">Number of item per page</param>
        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = source.Count();

            if ((pageIndex == -1) && (pageSize == -1))
            {
                this.TotalPages = 1;
                base.AddRange(source);
            }
            else
            {
                this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
                base.AddRange(source.Skip(this.PageIndex * this.PageSize).Take(this.PageSize));
            }
        }

        /// <summary>
        /// Get a page of items. If pageIndex = -1 and pageSize = -1, it means we do not need paging
        /// </summary>
        /// <param name="source">The data source</param>
        public PaginatedList(IQueryable<T> source)
        {
            this.PageIndex = 0;
            this.PageSize = -1;
            this.TotalCount = source.Count();

            this.TotalPages = 1;
            base.AddRange(source);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (this.PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (this.PageIndex + 1 < this.TotalPages);
            }
        }
    }
}
