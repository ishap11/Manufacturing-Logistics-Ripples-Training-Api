using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Suppliers>> FetchAllSuppliersAsync();
        Task<Suppliers?> FetchSupplierByIdAsync(long supplierId);
        Task<bool> CompanyNameExistsAsync(string companyName, long? excludeId = null);
        Task<bool> PhoneExistsAsync(string phone, long? excludeId = null);
        Task<bool> EmailExistsAsync(string email, long? excludeId = null);
        Task<SupplierType> ResolveSupplierTypeAsync(string typeName);
        Task<Country> ResolveCountryAsync(string countryName);
        Task<State> ResolveStateAsync(string stateName, long countryId);
        Task<City> ResolveCityAsync(string cityName, long stateId);
        Task AddAddressAsync(Address address);
        Task AddSupplierAsync(Suppliers supplier);
        Task UpdateSupplierAsync(Suppliers supplier);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task SaveChangesAsync();
        
        // Helper methods for ID generation
        Task<long> GetNextSupplierIdAsync();
        Task<long> GetNextAddressIdAsync();
        Task<long> GetNextSupplierTypeIdAsync();
        Task<long> GetNextCountryIdAsync();
        Task<long> GetNextStateIdAsync();
        Task<long> GetNextCityIdAsync();

        Task<IEnumerable<string>> FetchAllSupplierTypesAsync();
        Task<IEnumerable<string>> FetchAllCountriesAsync();
        Task<IEnumerable<string>> FetchStatesByCountryAsync(string countryName);
        Task<IEnumerable<string>> FetchCitiesByStateAsync(string stateName);
    }
}
