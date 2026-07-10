using Manufacturing_Logisitcs_Ripples_Training_Api.Facade;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Microsoft.AspNetCore.Mvc;
//using Serilog;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcurementOrderManagementController : ControllerBase
    {
        private readonly ProcurementOrderManagementFacade procurementOrderManagementFacade;

        public ProcurementOrderManagementController(
            ProcurementOrderManagementFacade procurementOrderManagementFacade)
        {
            this.procurementOrderManagementFacade =
                procurementOrderManagementFacade;
        }

        [HttpPost("AddPurchaseOrder")]
        public IActionResult AddPurchaseOrder(ProcurementOrderManagementDto vo)
        {
            try
            {
                //Log.Information("Adding Purchase Order : {@Vo}\n", vo);

                bool result =
                    procurementOrderManagementFacade.AddPurchaseOrder(vo);

                if (result)
                {
                    //Log.Information("Purchase Order inserted successfully\n");

                    return Ok("Purchase Order inserted successfully");
                }

                return BadRequest("Purchase Order insertion failed");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Exception occurred while inserting Purchase Order\n");

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllPurchaseOrders")]
        public IActionResult GetAllPurchaseOrders()
        {
            try
            {
                //Log.Information("Fetching All Purchase Orders\n");

                var purchaseOrders =
                    procurementOrderManagementFacade.GetAllPurchaseOrders();

                //Log.Information("Purchase Orders fetched successfully\n");

                return Ok(purchaseOrders);
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Exception occurred while fetching Purchase Orders\n");

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseOrderByIdUsingJoins/{purchaseOrderId}")]
        public IActionResult GetPurchaseOrderByIdUsingJoins(long purchaseOrderId)
        {
            try
            {
                //Log.Information("Fetching Purchase Order : {@PurchaseOrderId}\n",purchaseOrderId);

                var purchaseOrders =
                    procurementOrderManagementFacade
                    .GetPurchaseOrderByIdUsingJoins(purchaseOrderId);

                //Log.Information("Purchase Order fetched successfully\n");

                return Ok(purchaseOrders);
            }
            catch (Exception ex)
            {
                //Log.Error(ex,"Exception occurred while fetching Purchase Order\n");

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchAllUsingLazyLoading")]
        public IActionResult FetchAllUsingLazyLoading()
        {
            try
            {
                //Log.Information("Fetching records using Lazy Loading\n");

                var purchaseOrders =
                    procurementOrderManagementFacade
                    .FetchAllUsingLazyLoading();

                //Log.Information("Records fetched successfully using Lazy Loading\n");

                return Ok(purchaseOrders);
            }
            catch (Exception ex)
            {
                //Log.Error(ex,"Exception occurred while fetching records using Lazy Loading\n");

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertPurchaseOrderWithItems")]
        public IActionResult InsertPurchaseOrderWithItems(
            ProcurementOrderManagementDto vo)
        {
            try
            {
                //Log.Information("Inserting Purchase Order With Items : {@Vo}\n",vo);

                bool result =
                    procurementOrderManagementFacade
                    .InsertPurchaseOrderWithItems(
                        vo);

                if (result)
                {
                    //Log.Information("Purchase Order with Items inserted successfully\n");

                    return Ok("Purchase Order with Items inserted successfully");
                }

                return BadRequest("Purchase Order with Items insertion failed");
            }
            catch (Exception ex)
            {
                //Log.Error(ex,"Exception occurred while inserting Purchase Order with Items\n");

                return BadRequest(ex.Message);
            }
        }
    }
}
