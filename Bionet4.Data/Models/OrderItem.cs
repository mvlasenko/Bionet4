using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class OrderItem : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Order Order { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Product")]
        public string ProductName
        {
            get
            {
                if (this.Product == null)
                    return String.Empty;

                return string.Format("{0}", this.Product.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Product Product { get; set; }

        [Display(Name = "Count")]
        public int ProductCount { get; set; }

    }
}