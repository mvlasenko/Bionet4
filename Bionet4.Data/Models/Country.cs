using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

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