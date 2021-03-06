﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bionet4.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBindersConfig.RegisterModelBinders(ModelBinders.Binders);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}