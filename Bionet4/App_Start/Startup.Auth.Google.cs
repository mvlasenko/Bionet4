using Microsoft.Owin.Security.Google;
using Owin;

namespace Bionet4
{
    public partial class Startup
    {
        public void ConfigureGoogle(IAppBuilder app)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "169135684821 - r10bl1oniskthroe868g4ji7lg82tqi7.apps.googleusercontent.com",
                ClientSecret = "Mq7W06H_p9GQ8WCLw_PGEfdX"
            });
        }
    }
}