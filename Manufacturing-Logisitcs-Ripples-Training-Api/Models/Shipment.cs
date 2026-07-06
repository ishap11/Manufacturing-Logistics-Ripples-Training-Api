using System;
using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Shipment
    {
        public long ShipmentIdPk { get; set; }
        public long PurchaseOrderIdFk { get; set; }
        public long ShipmentStatusIdFk { get; set; }
        public long TransportModeIdFk { get; set; }
        public long CarrierIdFk { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime EstimatedArrival { get; set; }
        public DateTime? ActualArrival { get; set; }
        public long CurrentLocationIdFk { get; set; }
        public long OriginLocationIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
    }
}
