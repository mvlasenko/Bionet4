using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Bionet4.Data.Models
{
    public class Country : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }
    }
}
