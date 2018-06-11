using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Agent")]
        [UIHint("_Agent")]
        public int AgentId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Agent")]
        public string AgentName
        {
            get
            {
                if (this.Agent == null)
                    return String.Empty;

                return string.Format("{0}", this.Agent.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Agent Agent { get; set; }

        [IncludeList()]
        public string IDLeft { get; set; }

        [IncludeList()]
        public string IDRight { get; set; }

        [IncludeList()]
        public decimal Discount { get; set; }

        public string Body { get; set; }

        [IncludeList()]
        public bool IsViewed { get; set; }

        [IncludeList("Created")]
        [Display(Name = "Created")]
        public DateTime CreatedDateTime { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}