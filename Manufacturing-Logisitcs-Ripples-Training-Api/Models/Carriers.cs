using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Carriers
    {
        public long CarrierIdPk { get; set; }
        public string CarrierName { get; set; } = null!;
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
