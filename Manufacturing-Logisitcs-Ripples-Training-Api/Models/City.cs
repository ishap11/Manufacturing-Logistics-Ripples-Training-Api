using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class City
    {
        public long CityIdPk { get; set; }
        public string? CityName { get; set; }
        public long? StateIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual State? State { get; set; }
    }
}
