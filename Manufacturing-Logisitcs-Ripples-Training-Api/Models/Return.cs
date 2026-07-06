using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Return
    {
        public long ReturnIdPk { get; set; }
        public string ReturnRequestNumber { get; set; } = null!;
        public long StoreIdFk { get; set; }
        public long DcIdFk { get; set; }
        public DateTime ReturnDate { get; set; }
        public long? ReturnStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual StoreProfiles? Store { get; set; }
        public virtual DC? Dc { get; set; }
        public virtual Catalog? ReturnStatus { get; set; }
    }
}
