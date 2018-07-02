using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Variable : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList()]
        public string Value { get; set; }

        public string BigValue { get; set; }
    }
}