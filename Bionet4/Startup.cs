using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bionet4.Startup))]
namespace Bionet4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
