using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Product
    {
        public long ProductIdPk { get; set; }
        public string? ProductName { get; set; }
        public long? SubcategoryIDFk { get; set; }
        public long? StorageTypeIdFk { get; set; }
        public long? TaxCategoryIdFk { get; set; }
        public long? UnitOfMeasurementIdFk { get; set; }
        public long? HsnCode { get; set; }
        public decimal? PackSize { get; set; }
        public decimal? ProductWeight { get; set; }
        public long? ProductStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
        
        // Navigation properties
        public virtual Catalog? UnitOfMeasurement { get; set; }
    }
}
