﻿using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Bionet4.Data.Models
{
    public class Category : IEntity<int>
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Title { get; set; }

        [IncludeList()]
        public string Description { get; set; }

        [IncludeList("Image")]
        public string ImagePath { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
