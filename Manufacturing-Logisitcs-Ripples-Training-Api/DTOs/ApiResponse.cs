using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public T? Data { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
