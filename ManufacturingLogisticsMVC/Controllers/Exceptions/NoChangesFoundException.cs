namespace ManufacturingLogisticsMVC.Controllers.Exceptions
{
    public class NoChangesFoundException : Exception
    {
        public NoChangesFoundException(string message): base(message){}
    }
}