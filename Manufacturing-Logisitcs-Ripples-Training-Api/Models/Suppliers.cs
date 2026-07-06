using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Suppliers
    {
        public long SupplierIdPk { get; set; }
        public string? SupplierName { get; set; }
        public long? SupplierTypeIdFk { get; set; }
        public long? CurrencyIdFk { get; set; }
        public long? GstNumber { get; set; }
        public long? ManagersIdFk { get; set; }
        public long? SupplierStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual SupplierType? SupplierType { get; set; }
        public virtual Catalog? Currency { get; set; }
        public virtual Managers? Manager { get; set; }
        public virtual Catalog? SupplierStatus { get; set; }
    }
}
