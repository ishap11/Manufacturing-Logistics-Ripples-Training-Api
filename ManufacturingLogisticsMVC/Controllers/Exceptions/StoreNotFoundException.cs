namespace ManufacturingLogisticsMVC.Controllers.Exceptions
{
    public class StoreNotFoundException :Exception
    {
        public StoreNotFoundException(string message): base(message)
        {
        }
    }
}