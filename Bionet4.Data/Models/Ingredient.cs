using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Ingredient : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string HeadLetter { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

    }
}