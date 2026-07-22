using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Shipment
{
    public long ShipmentIdPk { get; set; }

    public long PurchaseOrderIdFk { get; set; }

    public long ShipmentStatusIdFk { get; set; }

    public long TransportModeIdFk { get; set; }

    public long CarrierIdFk { get; set; }

    public string? TrackingNumber { get; set; }

    public DateOnly DispatchDate { get; set; }

    public DateOnly EstimatedArrival { get; set; }

    public DateOnly? ActualArrival { get; set; }

    public long CurrentLocationIdFk { get; set; }

    public long OriginLocationIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual Carrier CarrierIdFkNavigation { get; set; } = null!;

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Location CurrentLocationIdFkNavigation { get; set; } = null!;

    public virtual ICollection<DcReceiving> DcReceivings { get; set; } = new List<DcReceiving>();

    public virtual Location OriginLocationIdFkNavigation { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrderIdFkNavigation { get; set; } = null!;

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    public virtual Catalog ShipmentStatusIdFkNavigation { get; set; } = null!;

    public virtual Catalog TransportModeIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
