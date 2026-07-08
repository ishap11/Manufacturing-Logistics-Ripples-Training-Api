namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services
{
    public class DispatchStatusService
    {
        public long DispatchIdPk
        {
            get;
            set;
        }

        public long DcIdFk
        {
            get;
            set;
        }

        public long StoreIdFk
        {
            get;
            set;
        }

        public DateTime DispatchDate { get; set; }

        public string DispatchStatusName
        {
            get;
            set;
        }
    }
}
