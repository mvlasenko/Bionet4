using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Models;
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

        public static MvcHtmlString FooterMenu(this MvcSiteMapHtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<p>");

            foreach (ISiteMapNode item in helper.SiteMap.RootNode.ChildNodes)
            {
                ProcessItem2(item, sb);
                sb.Append("<br />");
            }

            sb.Append("</p>");

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

        private static void ProcessItem2(ISiteMapNode item, StringBuilder sb)
        {
            if (item.ChildNodes != null && item.ChildNodes.Count > 0)
            {
                string url = item.Controller == "Articles" && item.Action == "Article" ? "/Articles/Article/" + item.Key : item.Url;
                sb.AppendFormat("<a href=\"{0}\">{1}</a> ", url, item.Title);

                foreach (ISiteMapNode childItem in item.ChildNodes)
                {
                    ProcessItem2(childItem, sb);
                }
            }
            else
            {
                string url = item.Controller == "Articles" && item.Action == "Article" ? "/Articles/Article/" + item.Key : item.Url;
                sb.AppendFormat("<a href=\"{0}\">{1}</a> ", url, item.Title);
            }
        }

        private static List<ISiteMapNode> GetBreadcrumbs(ISiteMapNode current)
        {
            List<ISiteMapNode> res = new List<ISiteMapNode>();

            if (current.ParentNode != null)
            {
                res.AddRange(GetBreadcrumbs(current.ParentNode));
            }

            res.Add(current);

            return res;
        }

        public static MvcHtmlString BreadcrumbsMenu(this MvcSiteMapHtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            sb.AppendFormat("<li>{0}</li>", Resources.BreadcrumbsTitle);

            ISiteMapNode current = helper.SiteMap.CurrentNode;

            //fix products paging
            if (current == null)
            {
                var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"];
                var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"];

                if (controller != null && controller.ToString() == "Products" && action != null && action.ToString() == "Index")
                {
                    current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && v.Action == action.ToString());
                }
            }

            if (current != null)
            {
                if (current.ParentNode != null)
                {
                    foreach (ISiteMapNode item in GetBreadcrumbs(current.ParentNode))
                    {
                        sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
                    }
                }
            }
            else
            {
                ISiteMapNode parent = GetParent(helper);
                if (parent != null)
                {
                    foreach (ISiteMapNode item in GetBreadcrumbs(parent))
                    {
                        sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
                    }
                }
            }

            sb.AppendFormat("<li>{0}</li>", GetTitleString(helper));

            sb.Append("</ul>");

            return new MvcHtmlString(sb.ToString());
        }

        private static ISiteMapNode GetParent(MvcSiteMapHtmlHelper helper)
        {
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"];
            var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"];
            var id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];

            //articles
            if (controller != null && controller.ToString() == "Articles" && action != null && action.ToString() == "Article" && id != null && id.ToString() != string.Empty)
            {
                return helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && v.Key != id.ToString());
            }

            //products
            if (controller != null && controller.ToString() == "Products" && action != null && action.ToString() == "Product" && id != null && id.ToString() != string.Empty)
            {
                return helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && v.Key != id.ToString());
            }

            return null;
        }

        private static string GetTitleString(MvcSiteMapHtmlHelper helper)
        {
            ISiteMapNode current = helper.SiteMap.CurrentNode;
            if (current != null)
                return current.Title;

            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"];
            var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"];
            var id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];

            //articles
            if (controller != null && controller.ToString() == "Articles" && action != null && action.ToString() == "Article" && id != null && id.ToString() != string.Empty)
            {
                IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
                Article article = repository.GetById(int.Parse(id.ToString()));
                return article.Name;
            }

            //products
            if (controller != null && controller.ToString() == "Products" && action != null && action.ToString() == "Product" && id != null && id.ToString() != string.Empty)
            {
                IProductsRepository repository = DependencyResolver.Current.GetService<IProductsRepository>();
                Product product = repository.GetById(int.Parse(id.ToString()));
                return product.Name;
            }

            //products paging
            if (controller != null && controller.ToString() == "Products" && action != null && action.ToString() == "Index")
            {
                current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && v.Action == action.ToString());
                return current.Title;
            }

            return string.Empty;
        }

        public static MvcHtmlString GetTitle(this MvcSiteMapHtmlHelper helper)
        {
            return new MvcHtmlString(GetTitleString(helper));
        }

    }
}