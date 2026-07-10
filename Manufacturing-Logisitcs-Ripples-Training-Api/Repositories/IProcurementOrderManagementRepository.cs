using Manufacturing_Logisitcs_Ripples_Training_Api.Services;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories
{
    public interface IProcurementOrderManagementRepository
    {
        public bool AddPurchaseOrder(ProcurementOrderManagementDto vo);

        public List<ProcurementOrderManagementDto> GetAllPurchaseOrders();

        public List<ProcurementOrderManagementDto> GetPurchaseOrderByIdUsingJoins(long PurchaseOrderId);

        public List<ProcurementOrderManagementDto> FetchAllUsingLazyLoading();

        public bool InsertPurchaseOrderWithItems(ProcurementOrderManagementDto vo);
    }
}
