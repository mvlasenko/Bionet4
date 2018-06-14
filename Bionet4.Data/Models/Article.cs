using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Article : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        public string Body { get; set; }

        [IncludeList()]
        public string Author { get; set; }

        [IncludeList("Publish Date")]
        [Display(Name = "Publish Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [UIHint("_DateTimePicker")]
        public DateTime? PublishDate { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }
    }
}