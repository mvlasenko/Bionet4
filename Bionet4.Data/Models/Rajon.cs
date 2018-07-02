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
    public class Rajon : IEntity<int>
    {
        public Rajon()
        {
            this.Applications = new List<Application>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [Display(Name = "Region")]
        [UIHint("_Region")]
        public int RegionId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Region")]
        public string RegionName
        {
            get
            {
                if (this.Region == null)
                    return String.Empty;

                return string.Format("{0}", this.Region.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Region Region { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Application> Applications { get; set; }

    }
}