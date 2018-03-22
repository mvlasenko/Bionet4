using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Product : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Title { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Category")]
        public string CategoryTitle
        {
            get
            {
                if (this.Category == null)
                    return String.Empty;

                return string.Format("{0}", this.Category.Title);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Category Category { get; set; }

    }
}