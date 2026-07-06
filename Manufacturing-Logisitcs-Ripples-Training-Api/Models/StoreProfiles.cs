using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class StoreProfiles
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

        public virtual Managers? Manager { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Catalog? StoreStatus { get; set; }
    }
}
