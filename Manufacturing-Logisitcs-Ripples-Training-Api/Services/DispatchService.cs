using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services
{
    public class DispatchService
    {
        private readonly
               IDispatchRepository repository;

        public DispatchService(
            IDispatchRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Dispatch>
    FetchAllDispatches()
        {
            IEnumerable<Dispatch>
                dispatchList =
                repository
                    .FetchAllDispatches();

            if (dispatchList == null
                || !dispatchList.Any())
            {
                throw new
                    DispatchManagementException(
                        "No dispatch records found");
            }

            return dispatchList;
        }
        public Dispatch FetchDispatchById(
            long dispatchId)
        {

            if (dispatchId <= 0)
            {
                throw new
                    DispatchManagementException(
                    "Invalid Dispatch Id");
            }

            return
                repository
                .FetchDispatchById(dispatchId);
        }

        public bool AddDispatch(
    Dispatch dispatch)
        {
            if (dispatch == null)
            {
                throw new
                    DispatchManagementException(
                    "Dispatch object is null");
            }

            if (dispatch.DispatchIdPk <= 0)
            {
                throw new
                    DispatchManagementException(
                    "Invalid Dispatch Id");
            }

            if (dispatch.DcIdFk <= 0)
            {
                throw new
                    DispatchManagementException(
                    "Invalid DC Id");
            }

            if (dispatch.StoreIdFk <= 0)
            {
                throw new
                    DispatchManagementException(
                    "Invalid Store Id");
            }
            if (!repository.DcExists(dispatch.DcIdFk))
            {
                throw new DispatchManagementException(
                    "Distribution Center does not exist.");
            }

            if (!repository.StoreExists(dispatch.StoreIdFk))
            {
                throw new DispatchManagementException(
                    "Store does not exist.");
            }

            if (!repository.DispatchStatusExists(dispatch.DispatchStatusIdFk))
            {
                throw new DispatchManagementException(
                    "Dispatch Status does not exist.");
            }

            if (repository.DispatchExists(
                    dispatch.DispatchIdPk))
            {
                throw new
                    DispatchManagementException(
                    "Dispatch Id already exists");
            }

            dispatch.CreatedDateTime =
                DateTime.Now;

            dispatch.UpdatedDateTime =
                DateTime.Now;

            return repository
                   .AddDispatch(dispatch);
        }

        public IEnumerable<Dispatch> FilterByDcId(long dcId)
        {
            if (dcId <= 0)
            {
                throw new
                    DispatchManagementException(
                    "Invalid DC Id");
            }

            IEnumerable<Dispatch>
                dispatchList =
                repository.FilterByDcId(dcId);

            if (!dispatchList.Any())
            {
                throw new
                    DispatchManagementException(
                    "No Dispatches Found");
            }

            return dispatchList;
        }
        public IEnumerable<DispatchStatusService>
    FetchDispatchUsingEagerLoading()
        {
            return repository
                    .FetchDispatchUsingEagerLoading();
        }
    }
}
