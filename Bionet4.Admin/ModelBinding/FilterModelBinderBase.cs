using System;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models.Filters;

namespace Bionet4.Admin.ModelBinding
{
    public abstract class FilterModelBinderBase<T, TKey> : DefaultModelBinder where T : IEntity<TKey>
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            return new Filter<T, TKey>();
        }
    }
}