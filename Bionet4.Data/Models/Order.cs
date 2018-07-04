using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Order : IEntity<int>
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        [UIHint("_Agent")]
        public string IDLeft { get; set; }

        [IncludeList()]
        [UIHint("_Agent")]
        public string IDRight { get; set; }

        [IncludeList()]
        public decimal Discount { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        [IncludeList("Viewed")]
        [Display(Name = "Viewed")]
        public bool IsViewed { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}