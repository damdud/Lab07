using System;
using UamTTA.Model;

namespace UamTTA
{
    public interface IBudgetFactory
    {
        Budget CreateBudget(BudgetTemplate template, DateTime startDate);
    }
}