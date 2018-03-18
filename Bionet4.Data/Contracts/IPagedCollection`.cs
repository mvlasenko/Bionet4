using System.Collections.Generic;

namespace Bionet4.Data.Contracts
{
    public interface IPagedCollection<T> : IPagedCollection, IEnumerable<T>
    {
    }
}
