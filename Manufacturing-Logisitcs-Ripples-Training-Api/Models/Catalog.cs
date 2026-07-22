using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Catalog
    {
        public long CatalogIdPk { get; set; }
        public string? CatalogType { get; set; }
        public string? CatalogKey { get; set; }
        public string? CatalogValue { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
