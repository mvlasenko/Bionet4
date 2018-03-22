using System.Xml.Serialization;

namespace Bionet4.T4.Model
{
    public class FieldInfo
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("friendly_name")]
        public string FriendlyName { get; set; }

        [XmlAttribute("fk_singular")]
        public string FkSingular { get; set; }

        [XmlAttribute("mm_singular")]
        public string MMSingular { get; set; }

        [XmlAttribute("mm_plural")]
        public string MMPlural { get; set; }

        [XmlAttribute("include_list")]
        public string IncludeList { get; set; }

        [XmlAttribute("include_form")]
        public string IncludeForm { get; set; }

        [XmlAttribute("ui_hint")]
        public string UIHint { get; set; }
    }
}
