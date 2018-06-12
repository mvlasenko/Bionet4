using System.Web.Mvc;
using System.Web.Security;
using Bionet4.Admin.Models;

namespace Bionet4.Admin.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginUser user, string ReturnUrl)
        {
            if (this.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View();
            }
        }

        private bool IsValid(LoginUser user)
        {
            return user.Login == "admin" && user.Password == "123";
        }
    }
}