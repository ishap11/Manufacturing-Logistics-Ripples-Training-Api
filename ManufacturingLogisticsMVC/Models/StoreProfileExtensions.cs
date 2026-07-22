namespace ManufacturingLogisticsMVC.Models
{
    public partial class StoreProfile
    {
        // Not a DB column — computed in C# from StoreIdPk
        // e.g. StoreIdPk = 1 -> "STR001", StoreIdPk = 15 -> "STR015"
        public string StoreCode => $"STR{StoreIdPk:D3}";
    }
}