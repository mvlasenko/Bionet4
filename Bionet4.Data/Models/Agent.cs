using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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

        [IncludeList()]
        public string Email { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        [IncludeList("ID")]
        [Display(Name = "ID")]
        public int AgentID { get; set; }

        [UIHint("_Agent")]
        public int ParentID { get; set; }

        [IncludeList()]
        public int Level { get; set; }

        [IncludeList()]
        public int Percent { get; set; }

        [IncludeList("Begin")]
        [Display(Name = "Begin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [UIHint("_DatePicker")]
        public DateTime? BeginDate { get; set; }

        [IncludeList()]
        public string Phone { get; set; }

        [UIHint("MultilineText")]
        public string Address { get; set; }

        [IncludeList("Updated")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? UpdatedDateTime { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Order> Orders { get; set; }

    }
}