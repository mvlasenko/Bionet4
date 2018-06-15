using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Video : IEntity<Guid>
    {
        [HiddenInput(DisplayValue = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [IncludeList("File")]
        [Display(Name = "File")]
        [ReadOnly(true)]
        public string FileName { get; set; }

        [UIHint("_FileUpload")]
        public byte[] Binary { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }
    }
}