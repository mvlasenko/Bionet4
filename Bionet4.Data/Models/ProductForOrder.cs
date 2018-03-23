using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class ProductForOrder : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int ItemID { get; set; }

        public int ParentID { get; set; }

        public string Code { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList()]
        public decimal Price { get; set; }

        [IncludeList()]
        public int? Point { get; set; }

        [IncludeList()]
        public int? Balance { get; set; }

        [IncludeList()]
        public int? Limit { get; set; }

    }
}