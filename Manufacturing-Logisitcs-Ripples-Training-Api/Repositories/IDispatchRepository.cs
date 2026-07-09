using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories
{
    public interface IDispatchRepository
    {
        IEnumerable<Dispatch> FetchAllDispatches();

        Dispatch FetchDispatchById(long dispatchId);

        bool AddDispatch(Dispatch dispatch);

        IEnumerable<Dispatch> FilterByDcId(long dcId);

        IEnumerable<DispatchStatusService> FetchDispatchUsingEagerLoading();

        bool DispatchExists(
    long dispatchId);

        bool DcExists(long dcId);

        bool StoreExists(long storeId);

        bool DispatchStatusExists(long statusId);
    }
}
