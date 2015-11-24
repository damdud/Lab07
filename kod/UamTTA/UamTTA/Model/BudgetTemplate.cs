using System.Collections.Generic;
using System.Linq;
using UamTTA.Tools;

namespace UamTTA.Model
{
    public class BudgetTemplate : ModelBase
    {
        public BudgetTemplate()
        {
            Accounts = Enumerable.Empty<Account>();
        }

        public string Name { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public Duration Duration { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Accounts: {Accounts.ToElementsString()}, Duration: {Duration}";
        }
    }
}