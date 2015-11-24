using System;
using UamTTA.Model;

namespace UamTTA.Services
{
    public class BudgetFactory : IBudgetFactory
    {
        public Budget CreateBudget(BudgetTemplate template, DateTime startDate)
        {
            var endDate = default(DateTime);
            switch (template.Duration)
            {
                case Duration.Weekly:
                    endDate = AddWeek(startDate);
                    break;

                case Duration.Monthly:
                    endDate = AddMonth(startDate);
                    break;

                case Duration.Quarterly:
                    break;

                case Duration.Yearly:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Budget {ValidFrom = startDate, ValidTo = endDate};
        }

        private static DateTime AddWeek(DateTime startDate)
        {
            return startDate.AddDays(6);
        }

        private static DateTime AddMonth(DateTime startDate)
        {
            var endDate = startDate.AddMonths(1);
            var daysInStartDate = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            var daysInNextMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month);
            if (daysInNextMonth >= 30 && (endDate.Day < daysInNextMonth || daysInNextMonth == daysInStartDate))
                endDate = endDate.AddDays(-1);
            return endDate;
        }
    }
}