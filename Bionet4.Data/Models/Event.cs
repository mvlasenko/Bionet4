using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Event : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList("Date")]
        [Display(Name = "Date and Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [UIHint("_DateTimePicker")]
        public DateTime? EventDateTime { get; set; }

        [IncludeList()]
        public string City { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }
    }
}