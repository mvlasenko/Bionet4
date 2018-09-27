using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class OrderItem : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Order")]
        [UIHint("_Order")]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Order Order { get; set; }

        [Display(Name = "Product")]
        [UIHint("_Product")]
        public int? ProductId { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Product Product { get; set; }

        [UIHint("_ProductForOrder")]
        public int? ProductForOrderId { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ProductForOrder ProductForOrder { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Product")]
        public string ProductName
        {
            get
            {
                if (this.Product != null)
                    return string.Format("{0}", this.Product.Name);

                if (this.ProductForOrder != null)
                    return string.Format("{0}", this.ProductForOrder.Name);

                return String.Empty;
            }
        }

        [Display(Name = "Count")]
        public int ProductCount { get; set; }

    }
}