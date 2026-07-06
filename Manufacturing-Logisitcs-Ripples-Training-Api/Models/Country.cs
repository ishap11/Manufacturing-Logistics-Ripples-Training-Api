using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Country
    {
        public long CountryIdPk { get; set; }
        public string? CountryName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
