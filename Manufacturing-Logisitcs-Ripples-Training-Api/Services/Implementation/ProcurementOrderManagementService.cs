using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services.Implementation
{
    public class ProcurementOrderManagementService
    {
        private readonly IProcurementOrderManagementRepository procurementOrderManagementRepository;

        public ProcurementOrderManagementService(
            IProcurementOrderManagementRepository procurementOrderManagementRepository)
        {
            this.procurementOrderManagementRepository =
                procurementOrderManagementRepository;
        }
        public bool AddPurchaseOrder(ProcurementOrderManagementDto vo)
        {
            if (vo.PurchaseOrderIdPk <= 0)
            {
                throw new ProcurementOrderManagementException("Purchase Order Id is mandatory");
            }

            if (vo.SupplierIdFk <= 0)
            {
                throw new ProcurementOrderManagementException("Supplier Id is mandatory");
            }

            if (vo.PurchaseOrderStatusIdFk <= 0)
            {
                throw new ProcurementOrderManagementException("Purchase Order Status Id is mandatory");
            }

            if (vo.CurrencyIdFk <= 0)
            {
                throw new ProcurementOrderManagementException("Currency Id is mandatory");
            }

            if (vo.PurchaseOrderDate == DateTime.MinValue)
            {
                throw new ProcurementOrderManagementException("Purchase Order Date is mandatory");
            }

            if (vo.PurchaseOrderDate.Date != DateTime.Today)
            {
                throw new ProcurementOrderManagementException("Purchase Order Date should be today's date");
            }

            if (vo.ExpectedDeliveryDate == DateTime.MinValue)
            {
                throw new ProcurementOrderManagementException("Expected Delivery Date is mandatory");
            }

            if (vo.ExpectedDeliveryDate.Date <= DateTime.Today)
            {
                throw new ProcurementOrderManagementException("Expected Delivery Date should be a future date");
            }

            return procurementOrderManagementRepository
                .AddPurchaseOrder(vo);
        }

        public List<ProcurementOrderManagementDto> GetAllPurchaseOrders()
        {
            return procurementOrderManagementRepository.GetAllPurchaseOrders();
        }

        public List<ProcurementOrderManagementDto> GetPurchaseOrderByIdUsingJoins(long purchaseOrderId)
        {
            if (purchaseOrderId <= 0)
            {
                throw new ProcurementOrderManagementException("Purchase Order Id is mandatory");
            }

            return procurementOrderManagementRepository.GetPurchaseOrderByIdUsingJoins(purchaseOrderId);
        }

        public List<ProcurementOrderManagementDto> FetchAllUsingLazyLoading()
        {
            return procurementOrderManagementRepository.FetchAllUsingLazyLoading();
        }

        public bool InsertPurchaseOrderWithItems(ProcurementOrderManagementDto vo)
        {
            if (vo.PurchaseOrderIdPk <= 0)
                throw new ProcurementOrderManagementException("Purchase Order Id is mandatory");

            if (vo.ItemList == null || vo.ItemList.Count <= 0)
                throw new ProcurementOrderManagementException("Purchase Order Items are mandatory");

            if (vo.SupplierIdFk <= 0)
                throw new ProcurementOrderManagementException("Supplier Id is mandatory");

            if (vo.PurchaseOrderStatusIdFk <= 0)
                throw new ProcurementOrderManagementException("Purchase Order Status Id is mandatory");

            if (vo.CurrencyIdFk <= 0)
                throw new ProcurementOrderManagementException("Currency Id is mandatory");

            if (vo.PurchaseOrderDate == DateTime.MinValue)
                throw new ProcurementOrderManagementException("Purchase Order Date is mandatory");

            if (vo.PurchaseOrderDate.Date != DateTime.Today)
                throw new ProcurementOrderManagementException("Purchase Order Date should be today's date");

            if (vo.ExpectedDeliveryDate == DateTime.MinValue)
                throw new ProcurementOrderManagementException("Expected Delivery Date is mandatory");

            if (vo.ExpectedDeliveryDate.Date <= DateTime.Today)
                throw new ProcurementOrderManagementException("Expected Delivery Date should be a future date");

            foreach (ProcurementOrderManagementDto itemVO in vo.ItemList)
            {
                ValidatePurchaseOrderItem(itemVO);
            }

            return procurementOrderManagementRepository.InsertPurchaseOrderWithItems(vo);
        }

        public static void ValidatePurchaseOrderItem(ProcurementOrderManagementDto itemVO)
        {
            if (itemVO.PurchaseOrderItemIdPk <= 0)
                throw new ProcurementOrderManagementException("Purchase Order Item Id is mandatory");

            if (itemVO.ProductSupplierIdFk <= 0)
                throw new ProcurementOrderManagementException("Product Supplier Id is mandatory");

            if (itemVO.PurchasedQuantity <= 0)
                throw new ProcurementOrderManagementException("Purchase Quantity is mandatory");

            if (itemVO.UnitPrice <= 0)
                throw new ProcurementOrderManagementException("Unit Price should be greater than zero");
        }
    }
}
