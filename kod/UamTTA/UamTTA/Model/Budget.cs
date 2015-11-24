using System;
using System.Collections.Generic;
using UamTTA.Tools;

namespace UamTTA.Model
{
    public class Budget : ModelBase
    {
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