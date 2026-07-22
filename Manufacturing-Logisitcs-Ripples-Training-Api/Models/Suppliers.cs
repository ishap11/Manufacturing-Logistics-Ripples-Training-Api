using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Suppliers
    {
        public long SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long SupplierTypeId { get; set; }
        public long AddressId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual SupplierType SupplierType { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
    }
}
