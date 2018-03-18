using System;
using System.Web.ModelBinding;

namespace Bionet4.Admin.Attributes
{
    public class IncludeListAttribute : Attribute, IMetadataAware
    {
        public string IncludeListTitle { get; private set; }

        public IncludeListAttribute()
        {

        }

        public IncludeListAttribute(string title)
        {
            this.IncludeListTitle = title;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["IncludeList"] = true;
            metadata.AdditionalValues["IncludeListTitle"] = this.IncludeListTitle;
        }
    }
}