using System;
using Bionet4.Controllers;
using Bionet4.Data.Contracts;
using Bionet4.Data.Repository;
using Unity;
using Unity.Injection;

namespace Bionet4
{
    public static partial class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContextFactory, DbContextFactory>();

            container.RegisterType<IAgentsRepository, AgentsRepository>();
            container.RegisterType<IAlbumDetailsRepository, AlbumDetailsRepository>();
            container.RegisterType<IAlbumsRepository, AlbumsRepository>();
            container.RegisterType<IApplicationsRepository, ApplicationsRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
            container.RegisterType<IMailTemplatesRepository, MailTemplatesRepository>();
            container.RegisterType<IParagraphsRepository, ParagraphsRepository>();
            container.RegisterType<IEventsRepository, EventsRepository>();
            container.RegisterType<IFAQRepository, FAQRepository>();
            container.RegisterType<IIngredientsRepository, IngredientsRepository>();
            container.RegisterType<IOrderItemsRepository, OrderItemsRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<ICategoriesRepository, CategoriesRepository>();
            container.RegisterType<IProductsRepository, ProductsRepository>();
            container.RegisterType<IProductsForOrderRepository, ProductsForOrderRepository>();
            container.RegisterType<IRajonsRepository, RajonsRepository>();
            container.RegisterType<IRegionsRepository, RegionsRepository>();
            container.RegisterType<ICountriesRepository, CountriesRepository>();
            container.RegisterType<IVariablesRepository, VariablesRepository>();
            container.RegisterType<IVideosRepository, VideosRepository>();
            container.RegisterType<IImagesRepository, ImagesRepository>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
        }
    }
}