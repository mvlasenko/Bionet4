using System;
using System.ComponentModel.DataAnnotations;

namespace Bionet4.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [UIHint("_Gender")]
        public int Gender { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Mobile")]
        public string PhoneMobile { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [UIHint("_DatePicker")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Country")]
        [UIHint("_Country")]
        public int CountryId { get; set; }

        [Display(Name = "Region")]
        [UIHint("_Region")]
        public int? RegionId { get; set; }

        [Display(Name = "Rajon")]
        [UIHint("_Rajon")]
        public int? RajonId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Display(Name = "House Number Addition")]
        public string HouseNumberAddition { get; set; }

        public string Apartment { get; set; }

        [Display(Name = "Phone Home")]
        public string PhoneHome { get; set; }
    }
}