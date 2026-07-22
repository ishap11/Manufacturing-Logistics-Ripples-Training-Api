using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Users
    {
        public long UserIdPk { get; set; }
        public string? UserName { get; set; }
        public long? RoleIdFk { get; set; }
        public string? Password { get; set; }
        public long? UserAddressIdFk { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Address? UserAddress { get; set; }
    }
}
