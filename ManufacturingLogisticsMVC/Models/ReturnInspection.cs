using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class ReturnInspection
{
    public long InspectionIdPk { get; set; }

    public long ReturnIdFk { get; set; }

    public int InspectedQuantity { get; set; }

    public int DamagedQuantity { get; set; }

    public int AcceptedQuantity { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual Return ReturnIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
