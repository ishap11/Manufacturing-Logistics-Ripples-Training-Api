using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Address
    {
        public long AddressIdPk { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public long? CityIdFk { get; set; }
        public string? Pincode { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual City? City { get; set; }
    }
}
