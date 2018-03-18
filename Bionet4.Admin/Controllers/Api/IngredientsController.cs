using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Bionet4.Admin.Models;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Newtonsoft.Json;

namespace Bionet4.Admin.Controllers.Api
{
    public class IngredientsController : ApiController<Ingredient, int>
    {
        public IngredientsController() : base(DependencyResolver.Current.GetService<IIngredientsRepository>())
        {

        }

        [HttpPost]
        [Route("api/AddIngredient")]
        public HttpResponseMessage AddIngredient(HttpRequestMessage request)
        {
            string json = request.Content.ReadAsStringAsync().Result;

            GoogleAction action = JsonConvert.DeserializeObject<GoogleAction>(json);

            Ingredient ingredient = new Ingredient();
            ingredient.Title = action.result.parameters.ingridient;
            ingredient.Amount = action.result.parameters.number.ToString(); //todo
            ingredient.Measure = action.result.parameters.measure;
            if (string.IsNullOrEmpty(ingredient.Measure))
                ingredient.Measure = "item";

            this.repository.Insert(ingredient);

            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent("Ok") };


        }
    }
}