using System;
using System.ComponentModel.DataAnnotations;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class Video : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList("Video")]
        [Display(Name = "Video")]
        public string VideoID { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        public byte[] Binary { get; set; }

        [IncludeList("Created")]
        [Display(Name = "Created")]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList()]
        [ScaffoldColumn(false)]
        public int? SeqID { get; set; }

    }
}