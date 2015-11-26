using System;
using UamTTA.Model;

namespace UamTTA.Services
{
    public interface IBudgetService
    {
        Budget CreateBudgetFromTemplate(BudgetTemplate template, DateTime startDate);

        Budget CreateBudgetFromTemplate(int templateId, DateTime startDate);
    }
}