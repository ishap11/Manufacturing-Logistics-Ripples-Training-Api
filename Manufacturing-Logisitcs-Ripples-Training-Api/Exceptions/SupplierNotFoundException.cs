using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions
{
    public class SupplierNotFoundException : Exception
    {
        public SupplierNotFoundException(string message) : base(message)
        {
        }
    }
}
