using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Paragraph : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Article")]
        public int ArticleId { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Article Article { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        [Display(Name = "FA Icon")]
        [UIHint("_FaIcon")]
        public string FaIcon { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }
    }
}