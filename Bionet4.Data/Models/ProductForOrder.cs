using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class ProductForOrder : IEntity<int>
    {
        public ProductForOrder()
        {
            this.OrderItems = new List<OrderItem>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int ItemID { get; set; }

        public int ParentID { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

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

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}