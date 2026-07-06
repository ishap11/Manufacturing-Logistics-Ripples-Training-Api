using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Subcategory
    {
        public long SubcategoryIdPk { get; set; }
        public string? SubcategoryName { get; set; }
        public long? CategoryIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Category? Category { get; set; }
    }
}
