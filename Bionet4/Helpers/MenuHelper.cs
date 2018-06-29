using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Html;

namespace Bionet4.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString MainMenu(this MvcSiteMapHtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class=\"nav navbar-nav sf-menu\">");

            foreach (ISiteMapNode item in helper.SiteMap.RootNode.ChildNodes)
            {
                ProcessItem(item, sb);
            }

            sb.Append("</ul>");

            return new MvcHtmlString(sb.ToString());
        }

        private static void ProcessItem(ISiteMapNode item, StringBuilder sb)
        {
            if (item.ChildNodes != null && item.ChildNodes.Count > 0)
            {
                sb.Append("<li>");

                int level = item.GetNodeLevel();
                if (level < 2)
                {
                    sb.AppendFormat("<a href=\"{0}\" class=\"sf-with-ul\">{1}<span class=\"sf-sub-indicator\"><i class=\"fa fa-angle-down\"></i></span></a>", item.Url, item.Title);
                }
                else
                {
                    sb.AppendFormat("<a href=\"{0}\" class=\"sf-with-ul\">{1}<span class=\"sf-sub-indicator pull-right\"><i class=\"fa fa-angle-right\"></i></span></a>", item.Url, item.Title);
                }

                sb.Append("<ul>");
                foreach (ISiteMapNode childItem in item.ChildNodes)
                {
                    ProcessItem(childItem, sb);
                }
                sb.Append("</ul>");

                sb.Append("</li>");
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\" class=\"sf-with-ul\">{1}</a></li>", item.Url, item.Title);
            }
        }
    }
}