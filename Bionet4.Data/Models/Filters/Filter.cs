using System;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models.Filters
{
    public class Filter<T, TKey> : IFilter<T, TKey> where T : IEntity<TKey>
    {
        private int pageIndex = 1;
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The page index.
        /// </value>
        public virtual int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 10;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        Func<T, object> orderBy = new Func<T, object>(x => x.Id);
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        public Func<T, object> OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

        /// <summary>
        /// Gets or sets the order by desc.
        /// </summary>
        /// <value>
        /// The order by desc.
        public Func<T, object> OrderByDescending { get; set; }

        Func<T, bool> where = new Func<T, bool>(x => x.Id != null);

        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        /// <value>
        /// The where.
        /// </value>
        public Func<T, bool> Where
        {
            get { return where; }
            set { where = value; }
        }
    }
}
