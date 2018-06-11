using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Agent : IEntity<int>
    {
        public Agent()
        {
            this.Orders = new List<Order>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int UserID { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        public int AgentID { get; set; }

        public int ParentID { get; set; }

        [IncludeList()]
        public int Level { get; set; }

        [IncludeList()]
        public int Percent { get; set; }

        [IncludeList()]
        public DateTime? BeginDate { get; set; }

        [IncludeList()]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Display(Name = "Updated")]
        public DateTime? UpdatedDateTime { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Order> Orders { get; set; }

    }
}