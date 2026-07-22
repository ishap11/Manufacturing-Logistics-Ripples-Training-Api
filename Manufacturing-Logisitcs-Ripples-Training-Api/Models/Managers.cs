using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Managers
    {
        public long ManagersIdPk { get; set; }
        public string ManagersName { get; set; } = null!;
        public string? ManagersContactCode { get; set; }
        public string? ManagersContactPhone { get; set; }
        public string? ManagersEmail { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
