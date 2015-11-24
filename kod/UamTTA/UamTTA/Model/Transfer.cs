using System;

namespace UamTTA.Model
{
    public class Transfer : ModelBase
    {
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