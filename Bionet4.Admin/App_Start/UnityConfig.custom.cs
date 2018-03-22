using System;
using Bionet4.Data.Contracts;
using Bionet4.Data.Repository;
using Unity;

namespace Bionet4.Admin
{
    public static partial class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContextFactory, DbContextFactory>();

            container.RegisterType<IProductsRepository, ProductsRepository>();
            container.RegisterType<ICategoriesRepository, CategoriesRepository>();
            container.RegisterType<ICountriesRepository, CountriesRepository>();
            container.RegisterType<ILanguagesRepository, LanguagesRepository>();
            container.RegisterType<IIngredientsRepository, IngredientsRepository>();

        }
    }
}