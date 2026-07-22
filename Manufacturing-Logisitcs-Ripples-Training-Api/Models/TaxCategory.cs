using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class TaxCategory
    {
        public long TaxCategoryIdPk { get; set; }
        public string? TaxCategoryName { get; set; }
        public int? TaxCategoryValue { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
