using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class StoreProfile
{
    public long StoreIdPk { get; set; }

    public string StoreName { get; set; } = null!;

    public long? ManagersIdFk { get; set; }

    public long? AddressIdFk { get; set; }

    public long? StoreStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual Address? AddressIdFkNavigation { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Dispatch> Dispatches { get; set; } = new List<Dispatch>();

    public virtual Manager? ManagersIdFkNavigation { get; set; }

    public virtual ICollection<ProductStoreMapping> ProductStoreMappings { get; set; } = new List<ProductStoreMapping>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<StoreDemandLimit> StoreDemandLimits { get; set; } = new List<StoreDemandLimit>();

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();

    public virtual Catalog? StoreStatusIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
