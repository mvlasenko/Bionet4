using Bionet4.T4.Model;
using System.Collections.Generic;

namespace Bionet4.T4.Templates
{
    public partial class RegisterUnityTemplate
    {
        public string RootNamespace { get; set; }

        public List<ModelInfo> Models { get; set; }
    }
}
