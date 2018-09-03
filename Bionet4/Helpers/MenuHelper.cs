using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Properties;
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
            //if (item.Controller == "Products" && item.Action == "Index")
            //{
            //    sb.Append("<li>");
            //    sb.AppendFormat("<a href=\"{0}\" class=\"sf-with-ul\">{1}<span class=\"sf-sub-indicator pull-right\"><i class=\"fa fa-angle-right\"></i></span></a>", item.Url, item.Title);

            //    sb.Append("<ul>");
            //    foreach (Category category in UIHelper.GetCategories().Where(x => x.ParentCategoryId == null))
            //    {
            //        sb.AppendFormat("<li><a href=\"/Categories/Category/{0}\" class=\"sf-with-ul\">{1}</a></li>", category.Id, category.Name);
            //    }
            //    sb.Append("</ul>");

            //    sb.Append("</li>");
            //}
            //else 
            
            if (item.ChildNodes != null && item.ChildNodes.Count > 0)
            {
                string url = item.Controller == "Articles" && item.Action == "Article" ? "/Articles/Article/" + item.Key : item.Url;

                sb.Append("<li>");

                int level = item.GetNodeLevel();
                if (level < 2)
                {
                    sb.AppendFormat("<a href=\"{0}\" class=\"sf-with-ul\">{1}<span class=\"sf-sub-indicator\"><i class=\"fa fa-angle-down\"></i></span></a>", url, item.Title);
                }
                else
                {
                    sb.AppendFormat("<a href=\"{0}\" class=\"sf-with-ul\">{1}<span class=\"sf-sub-indicator pull-right\"><i class=\"fa fa-angle-right\"></i></span></a>", url, item.Title);
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
                string url = item.Controller == "Articles" && item.Action == "Article" ? "/Articles/Article/" + item.Key : item.Url;

                sb.AppendFormat("<li><a href=\"{0}\" class=\"sf-with-ul\">{1}</a></li>", url, item.Title);
            }
        }

        public static MvcHtmlString BreadcrumbsMenu(this MvcSiteMapHtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            sb.AppendFormat("<li>{0}</li>", Resources.BreadcrumbsTitle);

            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"].ToString();

            foreach (ISiteMapNode item in GetBreadcrumbs(helper.SiteMap.CurrentNode.ParentNode))
            {
                sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
            }

            if (!string.IsNullOrEmpty(id) && controller == "Articles")
            {
                ISiteMapNode current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Key == id && v.Controller == controller);
                if (current != null)
                {
                    foreach (ISiteMapNode item in GetBreadcrumbs(current.ParentNode))
                    {
                        sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
                    }
                }

                IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
                Article article = repository.GetById(int.Parse(id));
                sb.AppendFormat("<li>{0}</li>", article.Name);
            }
            else if (helper.SiteMap.CurrentNode != null && helper.SiteMap.CurrentNode.ParentNode != null)
            {
                foreach (ISiteMapNode item in GetBreadcrumbs(helper.SiteMap.CurrentNode.ParentNode))
                {
                    sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
                }

                sb.AppendFormat("<li>{0}</li>", helper.SiteMap.CurrentNode.Title);
            }

            sb.Append("</ul>");

            return new MvcHtmlString(sb.ToString());
        }

        private static List<ISiteMapNode> GetBreadcrumbs(ISiteMapNode current)
        {
            List<ISiteMapNode> res = new List<ISiteMapNode>();

            if (current.ParentNode != null)
            {
                res.AddRange(GetBreadcrumbs(current.ParentNode));
            }

            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"].ToString();
            if (!string.IsNullOrEmpty(id) && controller == "Articles")
            {
                IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
                Article article = repository.GetById(int.Parse(id));

                current.Title = article.Name;
            }

            res.Add(current);

            return res;
        }

        public static MvcHtmlString GetTitle(this MvcSiteMapHtmlHelper helper)
        {
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"].ToString();

            if (!string.IsNullOrEmpty(id) && controller == "Articles")
            {
                IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
                Article article = repository.GetById(int.Parse(id));
                return new MvcHtmlString(article.Name);
            }

            return new MvcHtmlString(helper.SiteMap.CurrentNode.Title);
        }

    }
}