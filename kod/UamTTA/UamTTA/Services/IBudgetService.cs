using System;
using UamTTA.Model;

namespace UamTTA.Services
{
    public interface IBudgetService
    {
        Budget CreateBudgetFromTemplate(BudgetTemplate template, DateTime startDate);
    }
}