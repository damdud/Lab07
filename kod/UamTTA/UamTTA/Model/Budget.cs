using System;
using System.Collections.Generic;
using System.Linq;

namespace UamTTA
{
    public class Budget : ModelBase
    {
        public Budget(
            DateTime validFrom, DateTime validTo,
            IEnumerable<Transfer> operations = null, IEnumerable<Account> relatedAccounts = null,
            Account clearingAccount = null)
        {
            ValidFrom = validFrom;
            ValidTo = validTo;
            Operations = operations ?? Enumerable.Empty<Transfer>();
            RelatedAccounts = relatedAccounts ?? Enumerable.Empty<Account>();
        }

        public Budget()
        {
        }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public IEnumerable<Account> RelatedAccounts { get; set; }

        public IEnumerable<Transfer> Operations { get; set; }

        public override string ToString()
        {
            return $"ValidFrom: {ValidFrom}, ValidTo: {ValidTo}, RelatedAccounts: {RelatedAccounts.ToElementsString()}, Operations: {Operations.ToElementsString()}";
        }
    }
}