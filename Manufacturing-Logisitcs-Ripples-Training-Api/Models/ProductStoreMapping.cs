using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ProductStoreMapping
    {
        public long ProductStoreIdPk { get; set; }
        public long? ProductIdFk { get; set; }
        public long? StoreIdFk { get; set; }
        public decimal? MinQuantity { get; set; }
        public decimal? MaxQuantity { get; set; }
        public decimal? ReorderPoint { get; set; }
        public long? ProductStoreStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Product? Product { get; set; }
        public virtual StoreProfiles? Store { get; set; }
        public virtual Catalog? ProductStoreStatus { get; set; }
    }
}
