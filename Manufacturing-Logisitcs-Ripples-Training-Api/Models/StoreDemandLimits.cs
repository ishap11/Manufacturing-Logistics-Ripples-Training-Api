using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class StoreDemandLimits
    {
        public long LimitIdPk { get; set; }
        public long? StoreIdFk { get; set; }
        public long? ProductIdFk { get; set; }
        public int? MinOrderLevel { get; set; }
        public int? MaxOrderLevel { get; set; }
        public DateTime? EffectiveFromDate { get; set; }
        public DateTime? EffectiveToDate { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual StoreProfiles? Store { get; set; }
        public virtual Product? Product { get; set; }
    }
}
