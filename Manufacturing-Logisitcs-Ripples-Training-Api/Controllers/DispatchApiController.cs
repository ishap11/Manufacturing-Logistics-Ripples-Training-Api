using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Facade;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class DispatchApiController : ControllerBase
    {
        private readonly
           DispatchFacade facade;

        public DispatchApiController(
            DispatchFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]

        [Route("FetchAllDispatches")]
        public IActionResult
    FetchAllDispatches()
        {
            try
            {
                var result =
                    facade
                        .FetchAllDispatches();

                return Ok(result);
            }

            catch (
                DispatchManagementException ex)
            {
                return BadRequest(
                    ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    ex.Message);
            }
        }
        [HttpGet]

        [Route("FetchDispatchById/{id}")]
        public IActionResult
    FetchDispatchById(long id)
        {
            try
            {
                return Ok(
                    facade
                    .FetchDispatchById(id));
            }
            catch (DispatchNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DispatchManagementException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]

        [HttpPost]
        [Route("AddDispatch")]
        public IActionResult AddDispatch(
    Dispatch dispatch)
        {
            try
            {
                bool result =
                    facade.AddDispatch(
                        dispatch);

                return Ok("Dispatch added successfully");
            }
            catch (
                DispatchManagementException ex)
            {
                return BadRequest(
                    ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
        [HttpGet]
        [Route("FilterByDcId/{dcId}")]
        public IActionResult
    FilterByDcId(long dcId)
        {
            try
            {
                IEnumerable<Dispatch>
                    dispatchList =
                    facade
                    .FilterByDcId(dcId);

                return Ok(dispatchList);
            }
            catch (
                DispatchManagementException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    ex.Message);
            }
        }
        [HttpGet]
        [Route("FetchDispatchUsingEagerLoading")]
        public IActionResult
    FetchDispatchUsingEagerLoading()
        {
            try
            {
                IEnumerable<DispatchStatusService>
                    dispatchList =
                    facade
                    .FetchDispatchUsingEagerLoading();

                return Ok(dispatchList);
            }
            catch (
                DispatchManagementException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    ex.Message);
            }
        }
    }
}