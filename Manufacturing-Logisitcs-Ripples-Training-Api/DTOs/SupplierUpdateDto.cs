using System.ComponentModel.DataAnnotations;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class SupplierUpdateDto
    {
        [Required(ErrorMessage = "Supplier ID is mandatory.")]
        [Range(1, long.MaxValue, ErrorMessage = "Supplier ID must be greater than 0.")]
        public long SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Company name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s&\-\.]+$", ErrorMessage = "Company name can only contain alphabets, numbers, spaces, &, -, and .")]
        public string CompanyName { get; set; } = null!;

        [Required(ErrorMessage = "Contact person name is mandatory.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Contact person name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Contact Person name must contain only alphabetic characters.")]
        public string ContactPerson { get; set; } = null!;

        [Required(ErrorMessage = "Age is mandatory.")]
        [Range(18, 70, ErrorMessage = "Age must be between 18 and 70.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Supplier type is mandatory.")]
        public string SupplierType { get; set; } = null!;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address Line 1 cannot exceed 200 characters.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Pincode is required.")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Invalid Pincode.")]
        public string Pincode { get; set; } = null!;
    }

    //public class SupplierUpdateDto
    //{
    //    public long SupplierId { get; set; }

    //    [Required(ErrorMessage = "Company name is mandatory.")]
    //    public string CompanyName { get; set; } = null!;

    //    // Remaining properties...
    //}
}
