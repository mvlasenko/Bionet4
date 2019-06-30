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
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList("First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [IncludeList("Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [IncludeList("Middle Name")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [IncludeList()]
        [UIHint("_Gender")]
        public int Gender { get; set; }

        [IncludeList("Birth Date")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [UIHint("_DatePicker")]
        public DateTime? BirthDate { get; set; }

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

        [ScaffoldColumn(false)]
        public int? CityType { get; set; }

        [IncludeList()]
        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Display(Name = "House Number Addition")]
        public string HouseNumberAddition { get; set; }

        public string Apartment { get; set; }

        [IncludeList("Phone Home")]
        [Display(Name = "Phone Home")]
        public string PhoneHome { get; set; }

        [IncludeList("Phone Mobile")]
        [Display(Name = "Phone Mobile")]
        public string PhoneMobile { get; set; }

        [IncludeList()]
        public string Email { get; set; }

        [Display(Name = "Enterpreneur Code")]
        public string EnterpreneurCode { get; set; }

        public string Number { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }
    }
}