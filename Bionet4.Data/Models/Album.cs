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
    public class Album : IEntity<int>
    {
        public Album()
        {
            this.AlbumDetails = new List<AlbumDetail>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        public int? Year { get; set; }

        [UIHint("MultilineText")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual ICollection<AlbumDetail> AlbumDetails { get; set; }

    }
}