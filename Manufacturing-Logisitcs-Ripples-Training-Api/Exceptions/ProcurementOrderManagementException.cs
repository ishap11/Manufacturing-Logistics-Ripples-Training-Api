using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions
{
    [Serializable]
    public class ProcurementOrderManagementException : Exception
    {
        public ProcurementOrderManagementException()
        {
        }

        public ProcurementOrderManagementException(string? message) : base(message)
        {
        }

        public ProcurementOrderManagementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProcurementOrderManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
