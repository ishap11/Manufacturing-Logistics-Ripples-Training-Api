namespace ManufacturingLogisticsMVC.Controllers.Exceptions
{
    public class StoreAlreadyExistsException : Exception
    {
        public StoreAlreadyExistsException(string message): base(message)
        {
        }
    }
}