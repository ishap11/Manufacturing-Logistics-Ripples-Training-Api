using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class InventoryTransactions
    {
        public long InventoryTransactionIdPk { get; set; }
        public long DcIdFk { get; set; }
        public long InspectionIdFk { get; set; }
        public int QuantityChange { get; set; }
        public long TransactionTypeIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual DC? Dc { get; set; }
        public virtual ReturnInspection? ReturnInspection { get; set; }
        public virtual Catalog? TransactionType { get; set; }
    }
}
