using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Return
{
    public long ReturnIdPk { get; set; }

    public string ReturnRequestNumber { get; set; } = null!;

    public long StoreIdFk { get; set; }

    public long DcIdFk { get; set; }

    public DateOnly ReturnDate { get; set; }

    public long? ReturnStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Dc DcIdFkNavigation { get; set; } = null!;

    public virtual ICollection<ReturnInspection> ReturnInspections { get; set; } = new List<ReturnInspection>();

    public virtual ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

    public virtual Catalog? ReturnStatusIdFkNavigation { get; set; }

    public virtual StoreProfile StoreIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
