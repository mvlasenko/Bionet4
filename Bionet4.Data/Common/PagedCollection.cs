using Bionet4.Data.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace Bionet4.Data.Common
{
    public class PagedCollection<T> : IPagedCollection<T>, IPagedCollection
    {
        private readonly IEnumerable<T> items;

        public PagedCollection(IEnumerable<T> items, int pageIndex, int pageSize, int totalCount)
        {
            this.items = items;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        public IEnumerator GetEnumerator()
        {
            if (this.items == null)
                return null;

            return (IEnumerator)this.items.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (this.items == null)
                return null;

            return this.items.GetEnumerator();
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
