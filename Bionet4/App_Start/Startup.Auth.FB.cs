using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Facebook;
using Owin;

namespace Bionet4
{
    public partial class Startup
    {
        public void ConfigureFb(IAppBuilder app)
        {
            var x = new FacebookAuthenticationOptions();

            x.Scope.Add("email");

            x.AppId = "203267170310866";
            x.AppSecret = "8545962fa88df4ab4a9acb5832dfe1be";

            x.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = async context =>
                {
                    //Get the access token from FB and store it in the database and
                    //use FacebookC# SDK to get more information about the user
                    context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                    context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:name", context.Name));
                    context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:email", context.Email));
                }
            };
            x.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(x);

            //https://bionetvip.com.ua/signin-facebook

            //app.UseFacebookAuthentication(
            //   appId: "203267170310866",
            //   appSecret: "8545962fa88df4ab4a9acb5832dfe1be");
        }
    }
}