using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Dc
{
    public long DcIdPk { get; set; }

    public string DcName { get; set; } = null!;

    public long DcAddressIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Address DcAddressIdFkNavigation { get; set; } = null!;

    public virtual ICollection<DcInventory> DcInventories { get; set; } = new List<DcInventory>();

    public virtual ICollection<DcReceiving> DcReceivings { get; set; } = new List<DcReceiving>();

    public virtual ICollection<Dispatch> Dispatches { get; set; } = new List<Dispatch>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
