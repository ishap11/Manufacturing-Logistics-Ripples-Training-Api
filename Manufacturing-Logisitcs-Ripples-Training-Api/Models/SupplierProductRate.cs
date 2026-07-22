using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class SupplierProductRate
    {
        public long SupplierProductRateIdPk { get; set; }
        public long? SupplierIdFk { get; set; }
        public long? ProductIdFk { get; set; }
        public decimal? BaseRate { get; set; }
        public decimal? SupplyingQuantity { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Suppliers? Supplier { get; set; }
        public virtual Product? Product { get; set; }
    }
}
