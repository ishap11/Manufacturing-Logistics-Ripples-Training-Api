using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ManufacturingLogisticsDbContext _context;

        public SupplierRepository(ManufacturingLogisticsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Suppliers>> FetchAllSuppliersAsync()
        {
            return await _context.Suppliers
                .Include(s => s.SupplierType)
                .Include(s => s.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.State)
                            .ThenInclude(st => st.Country)
                .ToListAsync();
        }

        public async Task<Suppliers?> FetchSupplierByIdAsync(long supplierId)
        {
            return await _context.Suppliers
                .Include(s => s.SupplierType)
                .Include(s => s.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.State)
                            .ThenInclude(st => st.Country)
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }

        public async Task<bool> CompanyNameExistsAsync(string companyName, long? excludeId = null)
        {
            var query = _context.Suppliers.AsQueryable();
            if (excludeId.HasValue)
            {
                query = query.Where(s => s.SupplierId != excludeId.Value);
            }
            return await query.AnyAsync(s => s.CompanyName.ToLower() == companyName.Trim().ToLower());
        }

        public async Task<bool> PhoneExistsAsync(string phone, long? excludeId = null)
        {
            var query = _context.Suppliers.AsQueryable();
            if (excludeId.HasValue)
            {
                query = query.Where(s => s.SupplierId != excludeId.Value);
            }
            return await query.AnyAsync(s => s.PhoneNumber == phone.Trim());
        }

        public async Task<bool> EmailExistsAsync(string email, long? excludeId = null)
        {
            var query = _context.Suppliers.AsQueryable();
            if (excludeId.HasValue)
            {
                query = query.Where(s => s.SupplierId != excludeId.Value);
            }
            return await query.AnyAsync(s => s.Email.ToLower() == email.Trim().ToLower());
        }

        public async Task<SupplierType> ResolveSupplierTypeAsync(string typeName)
        {
            var cleanName = typeName.Trim();
            var supplierType = await _context.SupplierTypes
                .FirstOrDefaultAsync(st => st.SupplierTypeName.ToLower() == cleanName.ToLower());
            
            if (supplierType == null)
            {
                supplierType = new SupplierType
                {
                    SupplierTypeIdPk = await GetNextSupplierTypeIdAsync(),
                    SupplierTypeName = cleanName,
                    CreatedDateTime = DateTime.Now,
                    UpdatedDateTime = DateTime.Now
                };
                _context.SupplierTypes.Add(supplierType);
                await _context.SaveChangesAsync();
            }
            return supplierType;
        }

        public async Task<Country> ResolveCountryAsync(string countryName)
        {
            var cleanName = countryName.Trim();
            var country = await _context.Countries
                .FirstOrDefaultAsync(c => c.CountryName.ToLower() == cleanName.ToLower());
            
            if (country == null)
            {
                country = new Country
                {
                    CountryIdPk = await GetNextCountryIdAsync(),
                    CountryName = cleanName,
                    CreatedDateTime = DateTime.Now,
                    UpdatedDateTime = DateTime.Now
                };
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
            }
            return country;
        }

        public async Task<State> ResolveStateAsync(string stateName, long countryId)
        {
            var cleanName = stateName.Trim();
            var state = await _context.States
                .FirstOrDefaultAsync(s => s.StateName.ToLower() == cleanName.ToLower() && s.CountryIdFk == countryId);
            
            if (state == null)
            {
                state = new State
                {
                    StateIdPk = await GetNextStateIdAsync(),
                    StateName = cleanName,
                    CountryIdFk = countryId,
                    CreatedDateTime = DateTime.Now,
                    UpdatedDateTime = DateTime.Now
                };
                _context.States.Add(state);
                await _context.SaveChangesAsync();
            }
            return state;
        }

        public async Task<City> ResolveCityAsync(string cityName, long stateId)
        {
            var cleanName = cityName.Trim();
            var city = await _context.Cities
                .FirstOrDefaultAsync(c => c.CityName.ToLower() == cleanName.ToLower() && c.StateIdFk == stateId);
            
            if (city == null)
            {
                city = new City
                {
                    CityIdPk = await GetNextCityIdAsync(),
                    CityName = cleanName,
                    StateIdFk = stateId,
                    CreatedDateTime = DateTime.Now,
                    UpdatedDateTime = DateTime.Now
                };
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();
            }
            return city;
        }

        public async Task AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task AddSupplierAsync(Suppliers supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(Suppliers supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Helper methods for ID generation
        public async Task<long> GetNextSupplierIdAsync()
        {
            bool any = await _context.Suppliers.AnyAsync();
            if (!any) return 1;
            return await _context.Suppliers.MaxAsync(s => s.SupplierId) + 1;
        }

        public async Task<long> GetNextAddressIdAsync()
        {
            bool any = await _context.Addresses.AnyAsync();
            if (!any) return 1;
            return await _context.Addresses.MaxAsync(a => a.AddressIdPk) + 1;
        }

        public async Task<long> GetNextSupplierTypeIdAsync()
        {
            bool any = await _context.SupplierTypes.AnyAsync();
            if (!any) return 1;
            return await _context.SupplierTypes.MaxAsync(st => st.SupplierTypeIdPk) + 1;
        }

        public async Task<long> GetNextCountryIdAsync()
        {
            bool any = await _context.Countries.AnyAsync();
            if (!any) return 1;
            return await _context.Countries.MaxAsync(c => c.CountryIdPk) + 1;
        }

        public async Task<long> GetNextStateIdAsync()
        {
            bool any = await _context.States.AnyAsync();
            if (!any) return 1;
            return await _context.States.MaxAsync(s => s.StateIdPk) + 1;
        }

        public async Task<long> GetNextCityIdAsync()
        {
            bool any = await _context.Cities.AnyAsync();
            if (!any) return 1;
            return await _context.Cities.MaxAsync(c => c.CityIdPk) + 1;
        }
    }
}
