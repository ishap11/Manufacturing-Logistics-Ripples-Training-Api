using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class DcInventory
    {
        public long DcInventoryIdPk { get; set; }
        public long DcIdFk { get; set; }
        public long ProductIdFk { get; set; }
        public int AvailableQuantity { get; set; }
        public int DamagedQuantity { get; set; }
        public int BlockedQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int IntransitQuantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual DC? Dc { get; set; }
        public virtual Product? Product { get; set; }
    }
}
