using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation
{
    public class ProcurementOrderManagementRepository : IProcurementOrderManagementRepository
    {
        private readonly ManufacturingLogisticsDbContext _context;

        public ProcurementOrderManagementRepository(
            ManufacturingLogisticsDbContext context)
        {
            _context = context;
        }
        public bool AddPurchaseOrder(ProcurementOrderManagementDto vo)
        {
            bool flag;
            try
            {
                    PurchaseOrder purchaseOrder = new PurchaseOrder();

                    purchaseOrder.PurchaseOrderIdPk = vo.PurchaseOrderIdPk;

                    purchaseOrder.SupplierIdFk = vo.SupplierIdFk;

                    purchaseOrder.OrderStatusIdFk = vo.PurchaseOrderStatusIdFk;

                    purchaseOrder.CurrencyIdFk = vo.CurrencyIdFk;

                    purchaseOrder.PoDate = vo.PurchaseOrderDate;

                    purchaseOrder.ExpectedDeliveryDate = vo.ExpectedDeliveryDate;

                    _context.PurchaseOrders.Add(purchaseOrder);

                    int rowsAffected = _context.SaveChanges();

                    if (rowsAffected <= 0)
                    {
                        throw new ProcurementOrderManagementException("Purchase Order insertion failed");
                    }
                    else
                    {
                        flag = true;
                    }

                    return flag;
            }
            catch (SqlException ex)
            {
                throw new ProcurementOrderManagementException("Database error occurred while inserting Purchase Order : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ProcurementOrderManagementException("Error occurred while inserting Purchase Order : " + ex.Message);
            }
        }

        public List<ProcurementOrderManagementDto> GetAllPurchaseOrders()
        {
            try
            {
                    var purchaseOrders = (from po in _context.PurchaseOrders
                                          select new ProcurementOrderManagementDto
                                          {
                                              PurchaseOrderIdPk = po.PurchaseOrderIdPk,

                                              SupplierIdFk = (long)po.SupplierIdFk,

                                              PurchaseOrderStatusIdFk = (long)po.OrderStatusIdFk,

                                              CurrencyIdFk = (long)po.CurrencyIdFk,

                                              PurchaseOrderDate = po.PoDate,

                                              ExpectedDeliveryDate = po.ExpectedDeliveryDate
                                          }
                        ).ToList();

                    if (purchaseOrders.Count <= 0)
                    {
                        throw new ProcurementOrderManagementException("No Purchase Orders available");
                    }

                    return purchaseOrders;
            }
            catch (SqlException ex)
            {
                throw new ProcurementOrderManagementException("Database error occurred while fetching Purchase Orders : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ProcurementOrderManagementException("Error occurred while fetching Purchase Orders : " + ex.Message);
            }
        }

        public List<ProcurementOrderManagementDto> GetPurchaseOrderByIdUsingJoins(long PurchaseOrderId)
        {
            try
            {
                    var productNames = (from poi in _context.PurchaseOrderItems
                                        join psm in _context.ProductSupplierMappings
                                        on poi.ProductSupplierIdFk equals psm.ProductSupplierIdPk
                                        join p in _context.Products
                                        on psm.ProductIdFk equals p.ProductIdPk
                                        where poi.PurchaseOrderIdFk == PurchaseOrderId
                                        select new ProcurementOrderManagementDto
                                        {
                                            ProductName = p.ProductName
                                        }
                    ).ToList();

                    if (productNames.Count <= 0)
                    {
                        throw new ProcurementOrderManagementException("No Purchase Order found");
                    }

                    return productNames;
            }
            catch (SqlException ex)
            {
                throw new ProcurementOrderManagementException("Database error occurred while fetching Purchase Orders : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ProcurementOrderManagementException("Error occurred while fetching Purchase Orders : " + ex.Message);
            }
        }

        public List<ProcurementOrderManagementDto> FetchAllUsingLazyLoading()
        {
            try
            {
                    List<ProcurementOrderManagementDto> voList = new List<ProcurementOrderManagementDto>();

                    var purchaseOrders = _context.PurchaseOrders.ToList();

                    foreach (var po in purchaseOrders)
                    {
                        foreach (var item in po.PurchaseOrderItems)
                        {
                            ProcurementOrderManagementDto vo = new ProcurementOrderManagementDto();

                            vo.PurchaseOrderIdPk = po.PurchaseOrderIdPk;

                            vo.SupplierIdFk = (long)po.SupplierIdFk;

                            vo.ProductName = item.ProductSupplierIdFk.ToString();

                            voList.Add(vo);
                        }
                    }

                    if (voList.Count <= 0)
                    {
                        throw new ProcurementOrderManagementException
                        (
                            "No records available"
                        );
                    }

                    return voList;
            }
            catch (SqlException ex)
            {
                throw new ProcurementOrderManagementException("Database error occurred while fetching Purchase Orders : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ProcurementOrderManagementException("Error occurred while fetching Purchase Orders : " + ex.Message);
            }
        }

        public bool InsertPurchaseOrderWithItems(ProcurementOrderManagementDto vo)
        {
            bool flag;
            try
            {
                    PurchaseOrder purchaseOrder = new PurchaseOrder()
                    {
                        PurchaseOrderIdPk = vo.PurchaseOrderIdPk,

                        SupplierIdFk = vo.SupplierIdFk,

                        OrderStatusIdFk = vo.PurchaseOrderStatusIdFk,

                        CurrencyIdFk = vo.CurrencyIdFk,

                        PoDate = vo.PurchaseOrderDate,

                        ExpectedDeliveryDate = vo.ExpectedDeliveryDate,

                        PurchaseOrderItems = new List<PurchaseOrderItem>()
                    };

                    foreach (ProcurementOrderManagementDto itemVO in vo.ItemList)
                    {
                        PurchaseOrderItem item = new PurchaseOrderItem();

                        item.PoItemIdPk = itemVO.PurchaseOrderItemIdPk;

                        item.ProductSupplierIdFk = itemVO.ProductSupplierIdFk;

                        item.PurchaseQuantity = itemVO.PurchasedQuantity;

                        item.UnitPrice = itemVO.UnitPrice;

                        purchaseOrder.PurchaseOrderItems.Add(item);
                    }

                    _context.PurchaseOrders.Add(purchaseOrder);

                    int rowsAffected = _context.SaveChanges();

                    if (rowsAffected <= 0)
                    {
                        throw new ProcurementOrderManagementException("Purchase Order insertion failed");
                    }
                    else
                    {
                        flag = true;
                    }

                    return flag;
            }
            catch (SqlException ex)
            {
                throw new ProcurementOrderManagementException("Database error occurred while inserting Purchase Order : " + ex.Message);
            }
            /*catch (Exception ex)
            {
                throw new ProcurementOrderManagementException("Error occurred while inserting Purchase Order : " + ex.Message);
            }*/
            catch (Exception ex)
            {
                string error = ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

                throw new ProcurementOrderManagementException(
                    "Error occurred while inserting Purchase Order : " + error);
            }
        }
    }
}
