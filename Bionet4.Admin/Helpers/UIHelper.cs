using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Helpers;

namespace Bionet4.Admin.Helpers
{
    public static class UIHelper
    {
        public static List<Agent> GetAgents()
        {
            IAgentsRepository repository = DependencyResolver.Current.GetService<IAgentsRepository>();
            return repository.GetList().ToList();
        }

        public static List<AlbumDetail> GetAlbumDetails()
        {
            IAlbumDetailsRepository repository = DependencyResolver.Current.GetService<IAlbumDetailsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Album> GetAlbums()
        {
            IAlbumsRepository repository = DependencyResolver.Current.GetService<IAlbumsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Application> GetApplications()
        {
            IApplicationsRepository repository = DependencyResolver.Current.GetService<IApplicationsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Article> GetArticle()
        {
            IArticleRepository repository = DependencyResolver.Current.GetService<IArticleRepository>();
            return repository.GetList().ToList();
        }

        public static List<BottomBanner> GetBottomBanners()
        {
            IBottomBannersRepository repository = DependencyResolver.Current.GetService<IBottomBannersRepository>();
            return repository.GetList().ToList();
        }

        public static List<Certificate> GetCertificates()
        {
            ICertificatesRepository repository = DependencyResolver.Current.GetService<ICertificatesRepository>();
            return repository.GetList().ToList();
        }

        public static List<Event> GetEvents()
        {
            IEventsRepository repository = DependencyResolver.Current.GetService<IEventsRepository>();
            return repository.GetList().ToList();
        }

        public static List<FAQ> GetFAQ()
        {
            IFAQRepository repository = DependencyResolver.Current.GetService<IFAQRepository>();
            return repository.GetList().ToList();
        }

        public static List<Ingredient> GetIngredients()
        {
            IIngredientsRepository repository = DependencyResolver.Current.GetService<IIngredientsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Logo> GetLogos()
        {
            ILogosRepository repository = DependencyResolver.Current.GetService<ILogosRepository>();
            return repository.GetList().ToList();
        }

        public static List<OrderItem> GetOrderItems()
        {
            IOrderItemsRepository repository = DependencyResolver.Current.GetService<IOrderItemsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Order> GetOrders()
        {
            IOrdersRepository repository = DependencyResolver.Current.GetService<IOrdersRepository>();
            return repository.GetList().ToList();
        }

        public static List<Category> GetCategories()
        {
            ICategoriesRepository repository = DependencyResolver.Current.GetService<ICategoriesRepository>();
            return repository.GetList().ToList();
        }

        public static List<Product> GetProducts()
        {
            IProductsRepository repository = DependencyResolver.Current.GetService<IProductsRepository>();
            return repository.GetList().ToList();
        }

        public static List<ProductForOrder> GetProductsForOrder()
        {
            IProductsForOrderRepository repository = DependencyResolver.Current.GetService<IProductsForOrderRepository>();
            return repository.GetList().ToList();
        }

        public static List<Rajon> GetRajons()
        {
            IRajonsRepository repository = DependencyResolver.Current.GetService<IRajonsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Region> GetRegions()
        {
            IRegionsRepository repository = DependencyResolver.Current.GetService<IRegionsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Country> GetCountries()
        {
            ICountriesRepository repository = DependencyResolver.Current.GetService<ICountriesRepository>();
            return repository.GetList().ToList();
        }

        public static List<Slider> GetSliders()
        {
            ISlidersRepository repository = DependencyResolver.Current.GetService<ISlidersRepository>();
            return repository.GetList().ToList();
        }

        public static List<Unit> GetUnits()
        {
            IUnitsRepository repository = DependencyResolver.Current.GetService<IUnitsRepository>();
            return repository.GetList().ToList();
        }

        public static List<Variable> GetVariables()
        {
            IVariablesRepository repository = DependencyResolver.Current.GetService<IVariablesRepository>();
            return repository.GetList().ToList();
        }

        public static List<Video> GetVideos()
        {
            IVideosRepository repository = DependencyResolver.Current.GetService<IVideosRepository>();
            return repository.GetList().ToList();
        }

        public static List<Image> GetImages()
        {
            IImagesRepository repository = DependencyResolver.Current.GetService<IImagesRepository>();
            return repository.GetList().ToList();
        }

        public static MvcHtmlString Cut(this MvcHtmlString str, int maxLength)
        {
            return new MvcHtmlString(str.ToString().Cut(maxLength));
        }

        public static MvcHtmlString StripTags(this MvcHtmlString str)
        {
            return new MvcHtmlString(str.ToString().StripTags());
        }

        public static string GetDateFormat()
        {
            return "DD/MM/YYYY";
        }

        public static string GetDateTimeFormat()
        {
            return "DD/MM/YYYY HH:mm";
        }
    }
}