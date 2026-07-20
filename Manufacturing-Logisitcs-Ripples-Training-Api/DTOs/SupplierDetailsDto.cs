namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class SupplierDetailsDto
    {
        public long SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;
        public int Age { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SupplierType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Pincode { get; set; } = null!;
    }
}
