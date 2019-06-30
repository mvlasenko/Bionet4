using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Article : IEntity<int>
    {
        public Article()
        {
            this.Paragraphs = new List<Paragraph>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("_Enum")]
        public virtual ArticleType ArticleType { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("ArticleType")]
        public string ArticleTypeName
        {
            get
            {
                return this.ArticleType.ToString();
            }
        }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        [Rtf]
        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        [Display(Name = "FA Icon")]
        [UIHint("_FaIcon")]
        public string FaIcon { get; set; }

        [Display(Name = "Video URL")]
        public string VideoUrl { get; set; }

        [IncludeList()]
        public string Author { get; set; }

        [IncludeList("Publish Date")]
        [Display(Name = "Publish Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [UIHint("_DateTimePicker")]
        public DateTime? PublishDate { get; set; }

        [IncludeList("External URL")]
        [Display(Name = "External URL")]
        public string ExternalURL { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}