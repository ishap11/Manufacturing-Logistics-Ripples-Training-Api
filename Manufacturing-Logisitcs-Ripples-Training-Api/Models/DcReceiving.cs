using System;
using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class DcReceiving
    {
        public long DcReceivingIdPk { get; set; }
        public long DcIdFk { get; set; }
        public long ShipmentIdFk { get; set; }
        public long ReceivingStatusIdFk { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual DC? Dc { get; set; }
        public virtual Shipment? Shipment { get; set; }
        public virtual Catalog? ReceivingStatus { get; set; }
        public virtual ICollection<DcReceivingItem> DcReceivingItems { get; set; } = new List<DcReceivingItem>();
    }
}
