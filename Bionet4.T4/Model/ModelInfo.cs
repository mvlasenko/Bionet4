using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bionet4.T4.Model
{
    public class ModelInfo
    {
        [XmlAttribute("singular")]
        public string Singular { get; set; }

        [XmlAttribute("plural")]
        public string Plural { get; set; }

        [XmlElement("field")]
        public List<FieldInfo> Fields { get; set; }

        [XmlIgnore]
        public ModelInfo CollectionModel { get; set; }
    }
}
