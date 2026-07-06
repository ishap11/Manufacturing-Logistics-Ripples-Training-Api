using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Role
    {
        public long RoleIdPk { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
