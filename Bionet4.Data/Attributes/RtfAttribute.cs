using System;
using System.Web.ModelBinding;

namespace Bionet4.Admin.Attributes
{
    public class RtfAttribute : Attribute, IMetadataAware
    {
        public RtfAttribute()
        {

        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["RtfAttribute"] = true;
        }
    }
}