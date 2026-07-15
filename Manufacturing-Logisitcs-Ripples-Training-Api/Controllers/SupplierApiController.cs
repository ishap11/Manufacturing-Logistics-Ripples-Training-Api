using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Facade;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierApiController : ControllerBase
    {
        private readonly SupplierFacade _facade;
        private readonly ILogger<SupplierApiController> _logger;

        public SupplierApiController(SupplierFacade facade, ILogger<SupplierApiController> logger)
        {
            _facade = facade;
            _logger = logger;
        }

        [HttpGet]
        [Route("FetchAllSuppliers")]
        public async Task<IActionResult> FetchAllSuppliers()
        {
            try
            {
                _logger.LogInformation("Fetching all suppliers.");
                var result = await _facade.FetchAllSuppliersAsync();
                return Ok(new ApiResponse<IEnumerable<SupplierDetailsDto>>
                {
                    Success = true,
                    Message = "Suppliers retrieved successfully.",
                    Data = result
                });
            }
            catch (SupplierManagementException ex)
            {
                _logger.LogWarning(ex, "Supplier management exception while fetching all suppliers.");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while fetching all suppliers.");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred while fetching suppliers."
                });
            }
        }

        [HttpGet]
        [Route("FetchSupplierById/{id}")]
        public async Task<IActionResult> FetchSupplierById(long id)
        {
            try
            {
                _logger.LogInformation("Fetching supplier by ID: {Id}", id);
                var result = await _facade.FetchSupplierByIdAsync(id);
                return Ok(new ApiResponse<SupplierDetailsDto>
                {
                    Success = true,
                    Message = "Supplier retrieved successfully.",
                    Data = result
                });
            }
            catch (SupplierNotFoundException ex)
            {
                _logger.LogWarning(ex, "Supplier with ID {Id} was not found.", id);
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (SupplierManagementException ex)
            {
                _logger.LogWarning(ex, "Supplier management exception while fetching supplier by ID: {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while fetching supplier by ID: {Id}", id);
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred."
                });
            }
        }

        [HttpPost]
        [Route("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierCreateDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetModelStateErrors();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Please correct the highlighted fields.",
                    Errors = errors
                });
            }

            try
            {
                _logger.LogInformation("Adding new supplier with company name: {CompanyName}", supplierDto?.CompanyName);
                var result = await _facade.AddSupplierAsync(supplierDto!);
                return CreatedAtAction(nameof(FetchSupplierById), new { id = result.SupplierId }, new ApiResponse<SupplierResponseDto>
                {
                    Success = true,
                    Message = "Supplier added successfully.",
                    Data = result
                });
            }
            catch (SupplierManagementException ex)
            {
                _logger.LogWarning(ex, "Supplier validation failed during Add operation.");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = GetBusinessValidationErrors(ex.Message)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while adding supplier.");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred."
                });
            }
        }

        [HttpPut]
        [Route("UpdateSupplier/{id}")]
        public async Task<IActionResult> UpdateSupplier(long id, [FromBody] SupplierUpdateDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetModelStateErrors();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Please correct the highlighted fields.",
                    Errors = errors
                });
            }

            try
            {
                if (supplierDto == null)
                {
                    return BadRequest(new ApiResponse<object> { Success = false, Message = "Supplier data is null." });
                }
                supplierDto.SupplierId = id;
                _logger.LogInformation("Updating supplier with ID: {Id}", id);
                var result = await _facade.UpdateSupplierAsync(supplierDto);
                return Ok(new ApiResponse<SupplierResponseDto>
                {
                    Success = true,
                    Message = "Supplier updated successfully.",
                    Data = result
                });
            }
            catch (SupplierNotFoundException ex)
            {
                _logger.LogWarning(ex, "Supplier with ID {Id} not found during Update operation.", id);
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (SupplierManagementException ex)
            {
                _logger.LogWarning(ex, "Supplier validation failed during Update operation for ID {Id}.", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = GetBusinessValidationErrors(ex.Message)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while updating supplier with ID {Id}.", id);
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred."
                });
            }
        }

        [HttpGet]
        [Route("FetchSupplierWithCityName")]
        public async Task<IActionResult> FetchSupplierWithCityName([FromQuery] string cityName)
        {
            try
            {
                _logger.LogInformation("Fetching suppliers for city: {CityName}", cityName);
                var result = await _facade.FetchSupplierWithCityNameAsync(cityName);
                return Ok(new ApiResponse<IEnumerable<SupplierDetailsDto>>
                {
                    Success = true,
                    Message = "Suppliers for the specified city retrieved successfully.",
                    Data = result
                });
            }
            catch (SupplierManagementException ex)
            {
                _logger.LogWarning(ex, "Failed to retrieve suppliers for city: {CityName}", cityName);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while fetching suppliers for city: {CityName}", cityName);
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred."
                });
            }
        }

        private Dictionary<string, string[]> GetModelStateErrors()
        {
            return ModelState
                .Where(entry => entry.Value?.Errors.Count > 0)
                .ToDictionary(
                    entry => ToCamelCase(entry.Key.Split('.').Last()),
                    entry => entry.Value!.Errors.Select(error => error.ErrorMessage).ToArray());
        }

        private static Dictionary<string, string[]> GetBusinessValidationErrors(string message)
        {
            var normalized = message.ToLowerInvariant();
            var field = normalized.Contains("company") || normalized.Contains("supplier name") ? "companyName"
                : normalized.Contains("contact person") ? "contactPerson"
                : normalized.Contains("phone") ? "phone"
                : normalized.Contains("email") ? "email"
                : normalized.Contains("supplier type") ? "supplierType"
                : normalized.Contains("address") ? "address"
                : normalized.Contains("city") ? "city"
                : normalized.Contains("state") ? "state"
                : normalized.Contains("country") ? "country"
                : normalized.Contains("pincode") ? "pincode"
                : normalized.Contains("age") ? "age"
                : null;

            return field == null ? new Dictionary<string, string[]>() : new Dictionary<string, string[]> { [field] = new[] { message } };
        }

        private static string ToCamelCase(string value) => string.IsNullOrEmpty(value) ? value : char.ToLowerInvariant(value[0]) + value[1..];
    }
}
