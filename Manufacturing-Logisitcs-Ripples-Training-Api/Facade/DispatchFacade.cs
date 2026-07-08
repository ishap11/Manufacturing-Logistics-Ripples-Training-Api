using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
//using Serilog;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Facade
{
    public class DispatchFacade
    {
        private readonly
           DispatchService dispatchBO;

        public DispatchFacade(
            DispatchService dispatchBO)
        {
            this.dispatchBO = dispatchBO;
        }

        public IEnumerable<Dispatch>
            FetchAllDispatches()
        {
            try
            {
              //  Log.Information("Fetch All Dispatches Started");

                IEnumerable<Dispatch>
                    dispatchList =
                    dispatchBO
                        .FetchAllDispatches();

                //Log.Information(
                  //  "Dispatches fetched successfully");

                return dispatchList;
            }

            catch (DispatchManagementException ex)
            {
                //Log.Error(ex,
                  //  "Business exception occurred");

                throw;
            }
        }
        public Dispatch FetchDispatchById(
            long dispatchId)
        {
            try
            {
                //Log.Information(
                 //   "Fetch Dispatch By Id started");

                return
                    dispatchBO.FetchDispatchById(dispatchId);
            }
            catch (DispatchNotFoundException ex)
            {
//                Log.Error(ex.Message);

                throw;
            }
        }
        public bool AddDispatch(
    Dispatch dispatch)
        {
            try
            {
  //              Log.Information(
    //                "Add Dispatch started");

                bool result =
                    dispatchBO.AddDispatch(dispatch);

      //          Log.Information(
            //        "Dispatch added successfully");

                return result;
            }
            catch (Exception ex)
            {
        //        Log.Error(ex.Message);

                throw;
            }
        }
        public IEnumerable<Dispatch>
    FilterByDcId(long dcId)
        {
          //  Log.Information(
            //    "Filtering Dispatches by DC Id");

            return dispatchBO
                    .FilterByDcId(dcId);
        }
        public IEnumerable<DispatchStatusService>
    FetchDispatchUsingEagerLoading()
        {
            //Log.Information(
              //  "Fetching Dispatches using Join");

            return dispatchBO
                    .FetchDispatchUsingEagerLoading();
        }
    }
}
