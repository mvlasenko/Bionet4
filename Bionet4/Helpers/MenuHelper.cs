﻿using System.Collections.Generic;
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

        private static ISiteMapNode GetCurrent(MvcSiteMapHtmlHelper helper)
        {
            ISiteMapNode current = helper.SiteMap.CurrentNode;
            if (current != null)
                return current;

            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"];
            var id = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];

            //articles
            if (controller != null && controller.ToString() == "Articles")
            {
                if (id != null && id.ToString() != string.Empty)
                {
                    current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Key == id.ToString() && v.Controller == controller.ToString());

                    IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
                    Article article = repository.GetById(int.Parse(id.ToString()));
                    current.Title = article.Name;
                }
                else
                {
                    current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && string.IsNullOrEmpty(v.Key));
                }
            }

            //products
            if (controller != null && controller.ToString() == "Products")
            {
                if (id != null && id.ToString() != string.Empty)
                {
                    current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Key == id.ToString() && v.Controller == controller.ToString());
                    
                    //todo
                    if (current == null)
                    {
                        
                    }

                    IProductsRepository repository = DependencyResolver.Current.GetService<IProductsRepository>();
                    Product product = repository.GetById(int.Parse(id.ToString()));
                    current.Title = product.Name;
                }
                else
                {
                    current = helper.SiteMap.GetDescendants(helper.SiteMap.RootNode).FirstOrDefault(v => v.Controller == controller.ToString() && string.IsNullOrEmpty(v.Key));
                }
            }

            //todo: more controllers

            return current;

        }

        //private static List<MySiteMapNode> GetBreadcrumbs(MySiteMapNode current)
        //{
        //    List<MySiteMapNode> res = new List<MySiteMapNode>();

        //    if (current.ParentNode != null)
        //    {
        //        res.AddRange(GetBreadcrumbs(current.ParentNode));
        //    }

        //    res.Add(current);

        //    return res;
        //}

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

            ISiteMapNode current = GetCurrent(helper);

            if (current != null)
            {
                if (current.ParentNode != null)
                {
                    foreach (ISiteMapNode item in GetBreadcrumbs(current.ParentNode))
                    {
                        sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", item.Url, item.Title);
                    }
                }

                sb.AppendFormat("<li>{0}</li>", current.Title);
            }

            sb.Append("</ul>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString GetTitle(this MvcSiteMapHtmlHelper helper)
        {
            ISiteMapNode current = GetCurrent(helper);
            return new MvcHtmlString(current.Title);
        }

    }
}