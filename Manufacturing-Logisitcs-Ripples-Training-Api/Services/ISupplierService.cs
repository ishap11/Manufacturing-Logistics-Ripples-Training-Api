using System.Collections.Generic;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDetailsDto>> FetchAllSuppliersAsync();
        Task<SupplierDetailsDto> FetchSupplierByIdAsync(long id);
        Task<SupplierResponseDto> AddSupplierAsync(SupplierCreateDto dto);
        Task<SupplierResponseDto> UpdateSupplierAsync(SupplierUpdateDto dto);
        Task<IEnumerable<SupplierDetailsDto>> FetchSupplierWithCityNameAsync(string cityName);
        Task<IEnumerable<string>> FetchAllSupplierTypesAsync();
        Task<IEnumerable<string>> FetchAllCountriesAsync();
        Task<IEnumerable<string>> FetchStatesByCountryAsync(string countryName);
        Task<IEnumerable<string>> FetchCitiesByStateAsync(string stateName);
    }
}
