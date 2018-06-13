using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Application : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string FirstName { get; set; }

        [IncludeList()]
        public string LastName { get; set; }

        [IncludeList()]
        public string MiddleName { get; set; }

        public int Gender { get; set; }

        [IncludeList("Birth Date")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [UIHint("_DatePicker")]
        public DateTime BirthDate { get; set; }

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

        [Display(Name = "Region")]
        [UIHint("_Region")]
        public int? RegionId { get; set; }

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

        [Display(Name = "Rajon")]
        [UIHint("_Rajon")]
        public int? RajonId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Rajon")]
        public string RajonName
        {
            get
            {
                if (this.Rajon == null)
                    return String.Empty;

                return string.Format("{0}", this.Rajon.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Rajon Rajon { get; set; }

        public int CityType { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string HouseNumberAddition { get; set; }

        public string Apartment { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string Email { get; set; }

        public string EnterpreneurCode { get; set; }

        public string Number { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        public int CreatedByUserID { get; set; }

    }
}