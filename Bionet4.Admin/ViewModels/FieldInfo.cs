using System;

namespace Bionet4.Admin.ViewModels
{
    public class FieldInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public Type Type { get; set; }
        public string UIHint { get; set; }
    }
}