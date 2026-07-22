using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ProductSupplierMapping
    {
        public long ProductSupplierIdPk { get; set; }
        public long? ProductIdFk { get; set; }
        public long? SupplierIdFk { get; set; }
        public DateTime? LeadTime { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public long? ProductSupplierStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Suppliers? Supplier { get; set; }
        public virtual Catalog? ProductSupplierStatus { get; set; }
    }
}
