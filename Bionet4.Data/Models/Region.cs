using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Region : IEntity<int>
    {
        public Region()
        {
            this.Applications = new List<Application>();
            this.Rajons = new List<Rajon>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [Display(Name = "Country")]
        [UIHint("_Country")]
        public int CountryId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Country")]
        public string CountryName
        {
            get
            {
                if (this.Country == null)
                    return String.Empty;

                return string.Format("{0}", this.Country.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Country Country { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Application> Applications { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Rajon> Rajons { get; set; }

    }
}