using System.Collections.Generic;
using System.Linq;

namespace UamTTA
{
    public class BudgetTemplate : ModelBase
    {
        public BudgetTemplate(Duration defaultDuration, string defaultName, IEnumerable<Account> defaultAccounts = null)
        {
            DefaultAccounts = defaultAccounts ?? Enumerable.Empty<Account>();
            DefaultDuration = defaultDuration;
            DefaultName = defaultName;
        }

        public BudgetTemplate()
        {
        }

        public string DefaultName { get; set; }

        public IEnumerable<Account> DefaultAccounts { get; set; }

        public Duration DefaultDuration { get; set; }

        public override string ToString()
        {
            return $"DefaultName: {DefaultName}, DefaultAccounts: {DefaultAccounts.ToElementsString()}, DefaultDuration: {DefaultDuration}";
        }
    }
}