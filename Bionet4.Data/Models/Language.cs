using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Bionet4.Data.Models
{
    public class Language : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [IncludeList()]
        public string Title { get; set; }
    }
}