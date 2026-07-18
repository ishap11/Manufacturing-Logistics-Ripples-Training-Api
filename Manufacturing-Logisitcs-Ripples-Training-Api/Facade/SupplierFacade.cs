using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Services;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Facade
{
    public class SupplierFacade
    {
        private readonly ISupplierService _supplierService;

        public SupplierFacade(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IEnumerable<SupplierDetailsDto>> FetchAllSuppliersAsync()
        {
            try
            {
                return await _supplierService.FetchAllSuppliersAsync();
            }
            catch (SupplierManagementException)
            {
                throw;
            }
        }

        public async Task<SupplierDetailsDto> FetchSupplierByIdAsync(long supplierId)
        {
            try
            {
                return await _supplierService.FetchSupplierByIdAsync(supplierId);
            }
            catch (SupplierNotFoundException)
            {
                throw;
            }
            catch (SupplierManagementException)
            {
                throw;
            }
        }

        public async Task<SupplierResponseDto> AddSupplierAsync(SupplierCreateDto supplierDto)
        {
            try
            {
                return await _supplierService.AddSupplierAsync(supplierDto);
            }
            catch (SupplierManagementException)
            {
                throw;
            }
        }

        public async Task<SupplierResponseDto> UpdateSupplierAsync(SupplierUpdateDto supplierDto)
        {
            try
            {
                return await _supplierService.UpdateSupplierAsync(supplierDto);
            }
            catch (SupplierNotFoundException)
            {
                throw;
            }
            catch (SupplierManagementException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SupplierDetailsDto>> FetchSupplierWithCityNameAsync(string cityName)
        {
            try
            {
                return await _supplierService.FetchSupplierWithCityNameAsync(cityName);
            }
            catch (SupplierManagementException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> FetchAllSupplierTypesAsync()
        {
            return await _supplierService.FetchAllSupplierTypesAsync();
        }

        public async Task<IEnumerable<string>> FetchAllCountriesAsync()
        {
            return await _supplierService.FetchAllCountriesAsync();
        }

        public async Task<IEnumerable<string>> FetchStatesByCountryAsync(string countryName)
        {
            return await _supplierService.FetchStatesByCountryAsync(countryName);
        }

        public async Task<IEnumerable<string>> FetchCitiesByStateAsync(string stateName)
        {
            return await _supplierService.FetchCitiesByStateAsync(stateName);
        }
    }
}
