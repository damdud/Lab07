using System;
using UamTTA.Model;
using UamTTA.Storage;

namespace UamTTA.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetFactory _factory;
        private readonly IRepository<Budget> _budgetRepository;

        public BudgetService(IBudgetFactory factory, IRepository<Budget> budgetRepository)
        {
            _factory = factory;
            _budgetRepository = budgetRepository;
        }

        public Budget CreateBudgetFromTemplate(BudgetTemplate template, DateTime startDate)
        {
            Budget newBudget = _factory.CreateBudget(template, startDate);
            _budgetRepository.Persist(newBudget);
            return newBudget;
        }
    }
}