using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class State
    {
        public long StateIdPk { get; set; }
        public string? StateName { get; set; }
        public long? CountryIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Country? Country { get; set; }
    }
}
