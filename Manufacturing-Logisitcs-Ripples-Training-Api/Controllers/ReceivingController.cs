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
            try
            {
                var warehouses = await _receivingService.GetWarehousesAsync();
                return Ok(warehouses);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpGet("shipments")]
        public async Task<ActionResult<IEnumerable<ShipmentDto>>> GetShipments()
        {
            try
            {
                var shipments = await _receivingService.GetShipmentsAsync();
                return Ok(shipments);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceivingDto>>> GetAll([FromQuery] string? search, [FromQuery] string? status)
        {
            try
            {
                if (!string.IsNullOrEmpty(status))
                {
                    var result = await _receivingService.GetReceivingByStatusAsync(status);
                    return Ok(result);
                }
                var list = await _receivingService.SearchReceivingAsync(search);
                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceivingDto>> GetById(string id)
        {
            try
            {
                var record = await _receivingService.GetReceivingByIdAsync(id);
                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReceivingDto>> Create([FromBody] ReceivingDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Invalid payload");
                }
                var result = await _receivingService.AddReceivingAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.ReceivingId }, result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceivingDto>> Update(string id, [FromBody] ReceivingDto dto)
        {
            try
            {
                if (dto == null || id != dto.ReceivingId)
                {
                    return BadRequest("Mismatched ID");
                }
                var result = await _receivingService.UpdateReceivingAsync(dto);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var deleted = await _receivingService.DeleteReceivingAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, detail = ex.ToString() });
            }
        }
    }
}
