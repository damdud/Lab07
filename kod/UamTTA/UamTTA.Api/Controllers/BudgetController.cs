using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using UamTTA.Api.Models;
using UamTTA.Storage;

namespace UamTTA.Api.Controllers
{
    public class BudgetController : ApiController
    {
        private readonly IBudgetFactory _factory;
        private readonly IRepository<BudgetTemplate> _templateRepository;

        public BudgetController(IBudgetFactory factory, IRepository<BudgetTemplate> templateRepository)
        {
            _factory = factory;
            _templateRepository = templateRepository;
        }

        [Route("api/budget/createTemplate")]
        [HttpPost]
        public IHttpActionResult CreateTemplate(CreateTemplateModel parameter)
        {
            var template = new BudgetTemplate(parameter.Duration, parameter.Name);
            _templateRepository.Persist(template);

            return CreatedAtRoute("GetTemplateById", new { id = template.Id }, template);
        }

        [Route("api/budget/getTemplate/{id}", Name = "GetTemplateById")]
        [HttpGet]
        public TemplateModel GetTemplate(int id)
        {
            var template = _templateRepository.FindById(id);
            return new TemplateModel { Duration = template.DefaultDuration, Name = template.DefaultName };
        }
    }
}