using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;

namespace Bionet4.Data.Models
{
    public class MailTemplate : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("_Enum")]
        public virtual MailType MailType { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("MailType")]
        public string MailTypeName
        {
            get
            {
                return this.MailType.ToString();
            }
        }

        [UIHint("MultilineText")]
        public string Description { get; set; }
    }
}