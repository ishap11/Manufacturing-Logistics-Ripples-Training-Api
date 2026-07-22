using ManufacturingLogisticsMVC.Bo.StoreProfiles;
using ManufacturingLogisticsMVC.Controllers.Exceptions;
using ManufacturingLogisticsMVC.Facade.StoreProfiles;
using ManufacturingLogisticsMVC.Models;
using ManufacturingLogisticsMVC.Models.StoreManagement;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManufacturingLogisticsMVC.Controllers.StoreProfiles
{
    [ApiController]
    [Route("api")]
    public class StoreProfilesController : ControllerBase
    {
        private readonly StoreProfilesFacade _storeFacade;
        public StoreProfilesController(StoreProfilesFacade storeFacade) {
            _storeFacade = storeFacade;
        }

        // 1.Insert
        [Route("insert")]
        [HttpPost]
        //https://localhost:7271/api/insert
        public IActionResult InsertStore(StoreProfile store){
            try{
                bool result = _storeFacade.InsertStore(store);

                Log.Information("Store Inserted {@Store}", store);

                return Ok(new { message = "Store Added Successfully" });
            }
            catch (StoreAlreadyExistsException ex)
            {
                Log.Error("Store already exists. StoreCode: {StoreCode} | Error: {Error}",store?.StoreCode, ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (ManagerNotFoundException ex)
            {
                Log.Error("Manager not found. ManagerId: {ManagerId} | Error: {Error}",store?.ManagersIdFk, ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Log.Error("Unexpected insert error. StoreCode: {StoreCode} | Error: {Error}",store?.StoreCode, ex.Message);
                return StatusCode(500,new{error = ex.Message}); }
            }

        // 2.Find by ID
        [Route("find/{id}")]
        [HttpGet]
        //https://localhost:7271/api/find/
        public ActionResult<StoreProfile> FindStoreById(long id){
            try {
                StoreProfile? store = _storeFacade.FindStoreById(id);

                Log.Information("Store Found {@Store}", store);

                return Ok(new
                {
                    store.StoreIdPk,
                    store.StoreCode,
                    store.StoreName,
                    store.ManagersIdFk,
                    store.AddressIdFk,
                    store.StoreStatusIdFk,
                    store.CreatedByUserIdFk,
                    store.UpdatedByUserIdFk
                });
            }
            catch (StoreNotFoundException ex){
                Log.Error("Store not found. Id: {Id} | Error: {Error}",id, ex.Message);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {

                Log.Error("Unexpected find error. Id: {Id} | Error: {Error}",id, ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        
            
        }

        
        //3.Filter
        [Route("filter")]
        [HttpPost]
        //https://localhost:7271/api/filter
        public ActionResult<IEnumerable<object>> FilterStores([FromBody] StoreProfilesBO filterRequest){
            try{
                filterRequest.ValidateFilter(filterRequest.StoreName);
                Log.Information("Filter Stores by Name: {Name}",filterRequest.StoreName);

                var stores = _storeFacade.FilterStores(filterRequest.StoreName);
                

                return Ok(
                    stores.Select(store => new
                    {
                        store.StoreIdPk,
                        store.StoreCode,
                        store.StoreName,
                        store.ManagersIdFk,
                        store.AddressIdFk,
                        store.StoreStatusIdFk,
                        store.CreatedByUserIdFk,
                        store.UpdatedByUserIdFk
                    }));
            }
            catch (NoStoresFoundException ex)
            {
                Log.Error("No stores found. Name: {Name} | Error: {Error}", filterRequest.StoreName, ex.Message);
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Log.Error("Filter error. Name: {Name} | Error: {Error}",filterRequest.StoreName, ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }

        }

        // 4.Update
        [Route("update/{id}")]
        [HttpPost]
        //https://localhost:7271/api/update/
        public IActionResult UpdateStore(long id,StoreProfile store){
            try{
                bool result = _storeFacade.UpdateStore(id,store);

                Log.Information("Store Updated {@Store}", store);

                return Ok(new { message = "Store Updated Successfully" });
            }
            catch (StoreNotFoundException ex)
            {
                Log.Error("Store not found for update. Id: {Id} | Error: {Error}", id, ex.Message);
                return NotFound(new { error = ex.Message });
            }
            catch (ManagerNotFoundException ex)
            {
                Log.Error("Manager not found for update. ManagerId: {ManagerId} | Error: {Error}",store?.ManagersIdFk, ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (NoChangesFoundException ex)
            {
                Log.Error("No changes found for Store update. StoreId: {StoreId} | Error: {Error}",id,ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (StoreAlreadyExistsException ex)
            {
                Log.Error("Duplicate Store Code. StoreCode: {StoreCode} | Error: {Error}",store?.StoreCode, ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Log.Error("Update error. StoreCode: {StoreCode} | Error: {Error}", store?.StoreCode, ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }

        }



        //5.Find all by join
        [Route("findall")]
        [HttpGet]
        // https://localhost:7271/api/findall
        public ActionResult<IEnumerable<object>> FindAllStores(){
            try{
                var stores = _storeFacade.FindAllStores();

                Log.Information("All Stores Retrieved");

                return Ok(stores);
            }
            catch (Exception ex)
            {
                Log.Error("Find All Stores Error: {Error}",ex.Message);

                return StatusCode(500, new {error = ex.Message});
            }
        }


        // 6. Get All Managers (for dropdown)
        [Route("managers")]
        [HttpGet]
        // https://localhost:7271/api/managers
        public ActionResult<IEnumerable<object>> GetAllManagers()
        {
            try
            {
                var managers = _storeFacade.GetAllManagers();
                Log.Information("All Managers Retrieved");
                return Ok(managers);
            }
            catch (Exception ex)
            {
                Log.Error("Find All Managers Error: {Error}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // 7. Get All Addresses (for dropdown)
        [Route("addresses")]
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAllAddresses()
        {
            try
            {
                var addresses = _storeFacade.GetAllAddresses();
                Log.Information("All Addresses Retrieved");
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                Log.Error("Find All Addresses Error: {Error}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // 8. Get All Users (for Created By dropdown)
        [Route("users")]
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetAllUsers()
        {
            try
            {
                var users = _storeFacade.GetAllUsers();
                Log.Information("All Users Retrieved");
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error("Find All Users Error: {Error}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}