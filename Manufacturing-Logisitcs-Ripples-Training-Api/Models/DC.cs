using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class DC
    {
        public long DCIdPk { get; set; }
        public string DCName { get; set; } = null!;
        public long DCAddressIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
