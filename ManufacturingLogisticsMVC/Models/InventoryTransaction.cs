using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class InventoryTransaction
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

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Dc DcIdFkNavigation { get; set; } = null!;

    public virtual ReturnInspection InspectionIdFkNavigation { get; set; } = null!;

    public virtual Catalog TransactionTypeIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
