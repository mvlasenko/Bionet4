using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;
using Bionet4.Data.Properties;

namespace Bionet4.Data.Models
{
    public class Product : IEntity<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [IncludeList()]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [IncludeList("Image")]
        [Display(Name = "Image")]
        [UIHint("_Image")]
        public string ImageID { get; set; }

        [IncludeList()]
        public decimal Price { get; set; }

        [IncludeList()]
        public string Code { get; set; }

        [UIHint("_Unit")]
        public virtual Unit Unit { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Unit")]
        public string UnitName
        {
            get
            {
                if (this.Unit == Unit.None)
                    return string.Empty;

                try
                {
                    return Resources.ResourceManager.GetString(this.Unit.ToString());
                }
                catch {
                    return this.Unit.ToString();
                }
            }
        }

        [Display(Name = "Parent Product")]
        [UIHint("_Product")]
        public int? ParentProductId { get; set; }

        [Display(Name = "Category")]
        [UIHint("_Category")]
        public int? CategoryId { get; set; }

        [ScaffoldColumn(false)]
        [IncludeList("Category")]
        public string CategoryName
        {
            get
            {
                if (this.Category == null)
                    return String.Empty;

                return string.Format("{0}", this.Category.Name);
            }
        }

        [ScaffoldColumn(false)]
        [ScriptIgnore(ApplyToOverrides = true)]
        [XmlIgnore]
        public virtual Category Category { get; set; }

        [IncludeList("Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedDateTime { get; set; }

        [IncludeList("")]
        [HiddenInput(DisplayValue = false)]
        public int? SeqID { get; set; }
    }
}