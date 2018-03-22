using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bionet4.T4.Model
{
    [XmlRoot("root")]
    public class DatabaseInfo
    {
        [XmlElement("root_namespace")]
        public string RootNamespace { get; set; }

        [XmlElement("model")]
        public List<ModelInfo> Models { get; set; }
    }
}
