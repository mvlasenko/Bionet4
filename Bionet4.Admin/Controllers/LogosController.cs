using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class LogosController : ApplicationController<Logo, int>
    {
        private ILogosRepository repository;

        public LogosController(ILogosRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
