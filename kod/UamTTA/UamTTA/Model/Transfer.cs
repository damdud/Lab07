using System;

namespace UamTTA
{
    public class Transfer : ModelBase
    {
        public Transfer(decimal amount, Account sourceAccount, Account destinationAccount,
            Budget budget, DateTime? plannedDate, DateTime? transferDate,
            string reference = null)
        {
            Amount = amount;
            DestinationAccount = destinationAccount;
            SourceAccount = sourceAccount;
            Budget = budget;
            PlannedDate = plannedDate;
            TransferDate = transferDate;
            Reference = reference;
        }

        public Transfer()
        {
        }

        public Budget Budget { get; set; }

        public Account SourceAccount { get; set; }

        public Account DestinationAccount { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PlannedDate { get; set; }

        public DateTime? TransferDate { get; set; }

        public string Reference { get; set; }

        public override string ToString()
        {
            return $"Budget: {Budget}, SourceAccount: {SourceAccount}, DestinationAccount: {DestinationAccount}, Amount: {Amount}, PlannedDate: {PlannedDate}, TransferDate: {TransferDate}, Reference: {Reference}";
        }
    }
}