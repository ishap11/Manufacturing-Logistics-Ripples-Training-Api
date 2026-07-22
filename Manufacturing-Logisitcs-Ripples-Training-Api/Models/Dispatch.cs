using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Dispatch
    {
        public long DispatchIdPk { get; set; }
        public long DcIdFk { get; set; }
        public long StoreIdFk { get; set; }
        public DateTime DispatchDate { get; set; }
        public long DispatchStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual DC? Dc { get; set; }
        public virtual StoreProfiles? Store { get; set; }
        public virtual Catalog? DispatchStatus { get; set; }
    }
}
