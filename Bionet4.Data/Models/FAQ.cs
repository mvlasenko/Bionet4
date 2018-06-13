using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class FAQ : IEntity<int>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [IncludeList()]
        public string UserName { get; set; }

        [IncludeList()]
        public string Email { get; set; }

        [IncludeList()]
        public string Question { get; set; }

        [IncludeList()]
        public string Answer { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        public int CreatedByUserID { get; set; }

        [IncludeList("Modified")]
        [HiddenInput(DisplayValue = false)]
        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedByUserID { get; set; }

        public bool IsApproved { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }

    }
}