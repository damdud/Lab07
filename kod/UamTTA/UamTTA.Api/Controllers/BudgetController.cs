using System;
using System.Web.Http;
using UamTTA.Api.Models;
using UamTTA.Model;
using UamTTA.Services;
using UamTTA.Storage;

namespace UamTTA.Api.Controllers
{
    public class BudgetController : ApiController
    {
        private readonly IBudgetFactory _factory;
        private readonly IRepository<BudgetTemplate> _templateRepository;
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetFactory factory, IRepository<BudgetTemplate> templateRepository, IBudgetService budgetService)
        {
            _factory = factory;
            _templateRepository = templateRepository;
            _budgetService = budgetService;
        }

        [Route("api/budget/createTemplate")]
        [HttpPost]
        public IHttpActionResult CreateTemplate(CreateTemplateModel parameter)
        {
            var template = new BudgetTemplate { Duration = parameter.Duration, Name = parameter.Name };
            _templateRepository.Persist(template);

            return CreatedAtRoute("GetTemplateById", new { id = template.Id }, template);
        }

        [Route("api/budget/getTemplate/{id}", Name = "GetTemplateById")]
        [HttpGet]
        public TemplateModel GetTemplate(int id)
        {
            var template = _templateRepository.FindById(id);
            return new TemplateModel { Duration = template.Duration, Name = template.Name };
        }

        [Route("api/budget/createBudget/{templateId}")]
        [HttpPost]
        public Budget CreateBudget(int templateId)
        {
            return _budgetService.CreateBudgetFromTemplate(templateId, DateTime.Today);
        }
    }
}