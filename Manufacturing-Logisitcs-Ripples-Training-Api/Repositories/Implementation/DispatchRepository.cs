using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;
namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation
{
    public class DispatchRepository : IDispatchRepository
    {
        private readonly
           ManufacturingLogisticsDbContext _context;

        public DispatchRepository(
            ManufacturingLogisticsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dispatch>
            FetchAllDispatches()
        {
            return _context
                    .Dispatches
                    .ToList();
        }
        public Dispatch FetchDispatchById(
            long dispatchId)
        {
            Dispatch dispatch =
                _context.Dispatches.Find(dispatchId);

            if (dispatch == null)
            {
                throw new DispatchNotFoundException(
                    "Dispatch Id not found");
            }

            return dispatch;
        }
        public bool AddDispatch(
    Dispatch dispatch)
        {
            _context.Dispatches.Add(dispatch);

            int rowsAffected =
                _context.SaveChanges();

            return rowsAffected > 0;
        }

        public IEnumerable<Dispatch>
    FilterByDcId(long dcId)
        {
            return _context.Dispatches
                           .Where(
                                d => d.DcIdFk == dcId)
                           .ToList();
        }
        public IEnumerable<DispatchStatusService> FetchDispatchUsingEagerLoading()
        {
            return _context.Dispatches
                           .Include(
                                d => d.DispatchStatus)
                           .Select(d =>
                                new DispatchStatusService
                                {
                                    DispatchIdPk =
                                        d.DispatchIdPk,

                                    DcIdFk =
                                        d.DcIdFk,

                                    StoreIdFk =
                                        d.StoreIdFk,

                                    DispatchDate =
                                        d.DispatchDate,

                                    DispatchStatusName =
                                        d.DispatchStatus
                                         .CatalogKey
                                })
                           .ToList();
        }
        public bool DispatchExists(
    long dispatchId)
        {
            return _context.Dispatches
                           .Any(d =>
                                d.DispatchIdPk ==
                                dispatchId);
        }

        public bool DcExists(long dcId)
        {
            return _context.DCs.Any(d => d.DCIdPk == dcId);
        }

        public bool StoreExists(long storeId)
        {
            return _context.StoreProfiles.Any(s => s.StoreIdPk == storeId);
        }

        public bool DispatchStatusExists(long statusId)
        {
            return _context.Catalogs.Any(c => c.CatalogIdPk == statusId);
        }

    }
}
