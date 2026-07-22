using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class StoreManager
{
    public long StoreManagerIdPk { get; set; }

    public string StoreManagerName { get; set; } = null!;

    public string? StoreManagerContactCode { get; set; }

    public string? StoreManagerContactPhone { get; set; }

    public string? StoreManagerContactEmail { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual ICollection<StoreProfile> StoreProfiles { get; set; } = new List<StoreProfile>();
}
