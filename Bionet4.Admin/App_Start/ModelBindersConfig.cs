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
            binders[typeof(IFilter<Product, int>)] = new ProductsFilterModelBinder();
            binders[typeof(IFilter<Category, int>)] = new CategoriesFilterModelBinder();
            binders[typeof(IFilter<Country, int>)] = new CountriesFilterModelBinder();
            binders[typeof(IFilter<Language, int>)] = new LanguagesFilterModelBinder();
            binders[typeof(IFilter<Ingredient, int>)] = new IngredientsFilterModelBinder();
        }
    }
}