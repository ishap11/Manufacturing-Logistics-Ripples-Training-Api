namespace ManufacturingLogisticsMVC.Controllers.Exceptions
{
    public class ManagerNotFoundException : Exception
    {
        public ManagerNotFoundException(string message) : base(message)
        {
        }
    }
}