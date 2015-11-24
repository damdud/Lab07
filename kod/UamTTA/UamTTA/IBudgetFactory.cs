using System;

namespace UamTTA
{
    public interface IBudgetFactory
    {
        Budget CreateBudget(BudgetTemplate template, DateTime startDate);
    }
}