namespace ManufacturingLogisticsMVC.Controllers.Exceptions
{
    public class NoStoresFoundException : Exception
    {
        public NoStoresFoundException(string message) : base(message) { }
    }
}