using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceivingController : ControllerBase
    {
        private readonly IReceivingService _receivingService;

        public ReceivingController(IReceivingService receivingService)
        {
            _receivingService = receivingService;
        }

        [HttpGet("warehouses")]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
        {
            var warehouses = await _receivingService.GetWarehousesAsync();
            return Ok(warehouses);
        }

        [HttpGet("shipments")]
        public async Task<ActionResult<IEnumerable<ShipmentDto>>> GetShipments()
        {
            var shipments = await _receivingService.GetShipmentsAsync();
            return Ok(shipments);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<AvailableProductDto>>> GetProducts()
        {
            var products = await _receivingService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("receiving-statuses")]
        public async Task<ActionResult<IEnumerable<string>>> GetReceivingStatuses()
        {
            var statuses = await _receivingService.GetReceivingStatusesAsync();
            return Ok(statuses);
        }

        [HttpGet("qc-statuses")]
        public async Task<ActionResult<IEnumerable<string>>> GetQcStatuses()
        {
            var statuses = await _receivingService.GetQcStatusesAsync();
            return Ok(statuses);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceivingDto>>> GetAll([FromQuery] string? search, [FromQuery] string? status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                var result = await _receivingService.GetReceivingByStatusAsync(status);
                return Ok(result);
            }
            var list = await _receivingService.SearchReceivingAsync(search);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceivingDto>> GetById(string id)
        {
            var record = await _receivingService.GetReceivingByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<ReceivingDto>> Create([FromBody] ReceivingDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid payload");
            }
            var result = await _receivingService.AddReceivingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.ReceivingId }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceivingDto>> Update(string id, [FromBody] ReceivingDto dto)
        {
            if (dto == null || id != dto.ReceivingId)
            {
                return BadRequest("Mismatched ID");
            }
            var result = await _receivingService.UpdateReceivingAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _receivingService.DeleteReceivingAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
