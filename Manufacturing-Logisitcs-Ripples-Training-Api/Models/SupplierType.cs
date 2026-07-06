using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class SupplierType
    {
        public long SupplierTypeIdPk { get; set; }
        public string? SupplierTypeName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
