using System;
using System.Web.Mvc;
using Bionet4.Admin.ModelBinding;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin
{
    public class ModelBindersConfig
    {
        public static void RegisterModelBinders(ModelBinderDictionary binders)
        {
            binders[typeof(IFilter<Agent, int>)] = new AgentsFilterModelBinder();
            binders[typeof(IFilter<AlbumDetail, int>)] = new AlbumDetailsFilterModelBinder();
            binders[typeof(IFilter<Album, int>)] = new AlbumsFilterModelBinder();
            binders[typeof(IFilter<Application, int>)] = new ApplicationsFilterModelBinder();
            binders[typeof(IFilter<Article, int>)] = new ArticleFilterModelBinder();
            binders[typeof(IFilter<BottomBanner, int>)] = new BottomBannersFilterModelBinder();
            binders[typeof(IFilter<Certificate, int>)] = new CertificatesFilterModelBinder();
            binders[typeof(IFilter<Event, int>)] = new EventsFilterModelBinder();
            binders[typeof(IFilter<FAQ, int>)] = new FAQFilterModelBinder();
            binders[typeof(IFilter<Ingredient, int>)] = new IngredientsFilterModelBinder();
            binders[typeof(IFilter<Logo, int>)] = new LogosFilterModelBinder();
            binders[typeof(IFilter<OrderItem, int>)] = new OrderItemsFilterModelBinder();
            binders[typeof(IFilter<Order, int>)] = new OrdersFilterModelBinder();
            binders[typeof(IFilter<Category, int>)] = new CategoriesFilterModelBinder();
            binders[typeof(IFilter<Product, int>)] = new ProductsFilterModelBinder();
            binders[typeof(IFilter<ProductForOrder, int>)] = new ProductsForOrderFilterModelBinder();
            binders[typeof(IFilter<Rajon, int>)] = new RajonsFilterModelBinder();
            binders[typeof(IFilter<Region, int>)] = new RegionsFilterModelBinder();
            binders[typeof(IFilter<Country, int>)] = new CountriesFilterModelBinder();
            binders[typeof(IFilter<Slider, int>)] = new SlidersFilterModelBinder();
            binders[typeof(IFilter<Unit, int>)] = new UnitsFilterModelBinder();
            binders[typeof(IFilter<Variable, int>)] = new VariablesFilterModelBinder();
            binders[typeof(IFilter<Video, int>)] = new VideosFilterModelBinder();
            binders[typeof(IFilter<Image, Guid>)] = new ImagesFilterModelBinder();
        }
    }
}