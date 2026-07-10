using Manufacturing_Logisitcs_Ripples_Training_Api.Services.Implementation;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Facade
{
    public class ProcurementOrderManagementFacade
    {
        private readonly ProcurementOrderManagementService procurementOrderManagementBo;

        public ProcurementOrderManagementFacade(
            ProcurementOrderManagementService procurementOrderManagementBo)
        {
            this.procurementOrderManagementBo = procurementOrderManagementBo;
        }

        public bool AddPurchaseOrder(ProcurementOrderManagementDto vo)
        {
            return procurementOrderManagementBo.AddPurchaseOrder(vo);
        }

        public List<ProcurementOrderManagementDto> GetAllPurchaseOrders()
        {
            return procurementOrderManagementBo.GetAllPurchaseOrders();
        }

        public List<ProcurementOrderManagementDto> GetPurchaseOrderByIdUsingJoins(long purchaseOrderId)
        {
            return procurementOrderManagementBo.GetPurchaseOrderByIdUsingJoins(purchaseOrderId);
        }

        public List<ProcurementOrderManagementDto> FetchAllUsingLazyLoading()
        {
            return procurementOrderManagementBo.FetchAllUsingLazyLoading();
        }

        public bool InsertPurchaseOrderWithItems(ProcurementOrderManagementDto vo)
        {
            return procurementOrderManagementBo.InsertPurchaseOrderWithItems(vo);
        }
    }
}
