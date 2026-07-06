using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceivingDto>>> Get([FromQuery] string? search, [FromQuery] string? status)
        {
            try
            {
                IEnumerable<ReceivingDto> result;
                if (!string.IsNullOrEmpty(status) && !status.Equals("All", StringComparison.OrdinalIgnoreCase))
                {
                    result = await _receivingService.GetReceivingByStatusAsync(status);
                }
                else
                {
                    result = await _receivingService.SearchReceivingAsync(search);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
                    return NotFound($"Receiving record with ID {id} not found.");
                }
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("warehouses")]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
        {
            try
            {
                var warehouses = await _receivingService.GetWarehousesAsync();
                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReceivingDto>> Create([FromBody] ReceivingDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Receiving data is null.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _receivingService.AddReceivingAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.ReceivingId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceivingDto>> Update(string id, [FromBody] ReceivingDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Receiving data is null.");
                }
                if (id != dto.ReceivingId)
                {
                    return BadRequest("ID mismatch in URL and request body.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updated = await _receivingService.UpdateReceivingAsync(dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
                    return NotFound($"Receiving record with ID {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
