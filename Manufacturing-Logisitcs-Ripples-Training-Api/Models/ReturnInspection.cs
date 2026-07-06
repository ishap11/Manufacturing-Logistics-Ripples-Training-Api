using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ReturnInspection
    {
        public long InspectionIdPk { get; set; }
        public long ReturnIdFk { get; set; }
        public int InspectedQuantity { get; set; }
        public int DamagedQuantity { get; set; }
        public int AcceptedQuantity { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Return? Return { get; set; }
    }
}
