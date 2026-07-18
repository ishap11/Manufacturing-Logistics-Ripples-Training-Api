using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SupplierDetailsDto>> FetchAllSuppliersAsync()
        {
            var suppliers = await _repository.FetchAllSuppliersAsync();
            if (suppliers == null || !suppliers.Any())
            {
                throw new SupplierManagementException("No supplier records found.");
            }
            return suppliers.Select(s => MapToDetailsDto(s)).ToList();
        }

        public async Task<SupplierDetailsDto> FetchSupplierByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new SupplierManagementException("Invalid Supplier ID.");
            }

            var supplier = await _repository.FetchSupplierByIdAsync(id);
            if (supplier == null)
            {
                throw new SupplierNotFoundException($"Supplier with ID {id} not found.");
            }

            return MapToDetailsDto(supplier);
        }

        public async Task<SupplierResponseDto> AddSupplierAsync(SupplierCreateDto dto)
        {
            if (dto == null)
            {
                throw new SupplierManagementException("Supplier data is null.");
            }

            // 1. Validate request
            ValidateSupplier(dto.CompanyName, dto.ContactPerson, dto.Age, dto.Phone, dto.Email, dto.SupplierType, dto.Address, dto.City, dto.State, dto.Country, dto.Pincode);

            // Everything should happen inside a single transaction
            using (var transaction = await _repository.BeginTransactionAsync())
            {
                try
                {
                    // 2. Check duplicate Company Name
                    if (await _repository.CompanyNameExistsAsync(dto.CompanyName))
                    {
                        throw new SupplierManagementException("Supplier Name already exists.");
                    }

                    // 3. Check duplicate Email
                    if (await _repository.EmailExistsAsync(dto.Email))
                    {
                        throw new SupplierManagementException("Supplier with this email already exists.");
                    }

                    // 4. Check duplicate Phone Number
                    if (await _repository.PhoneExistsAsync(dto.Phone))
                    {
                        throw new SupplierManagementException("Supplier with this phone number already exists.");
                    }

                    // 5 & 6. Check Supplier Type / Insert if not available
                    var resolvedType = await _repository.ResolveSupplierTypeAsync(dto.SupplierType);

                    // 7 & 8. Check Country / Insert if not available
                    var resolvedCountry = await _repository.ResolveCountryAsync(dto.Country);

                    // 9 & 10. Check State / Insert if not available
                    var resolvedState = await _repository.ResolveStateAsync(dto.State, resolvedCountry.CountryIdPk);

                    // 11 & 12. Check City / Insert if not available
                    var resolvedCity = await _repository.ResolveCityAsync(dto.City, resolvedState.StateIdPk);

                    // 13. Insert Address
                    var addressId = await _repository.GetNextAddressIdAsync();
                    var newAddress = new Address
                    {
                        AddressIdPk = addressId,
                        AddressLine1 = dto.Address.Trim(),
                        CityIdFk = resolvedCity.CityIdPk,
                        Pincode = dto.Pincode.Trim(),
                        CreatedDateTime = DateTime.Now,
                        UpdatedDateTime = DateTime.Now
                    };
                    await _repository.AddAddressAsync(newAddress);

                    // 14. Insert Supplier
                    var supplierId = await _repository.GetNextSupplierIdAsync();
                    var newSupplier = new Suppliers
                    {
                        SupplierId = supplierId,
                        CompanyName = dto.CompanyName.Trim(),
                        ContactPerson = dto.ContactPerson.Trim(),
                        Age = dto.Age,
                        PhoneNumber = dto.Phone.Trim(),
                        Email = dto.Email.Trim(),
                        SupplierTypeId = resolvedType.SupplierTypeIdPk,
                        AddressId = addressId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    await _repository.AddSupplierAsync(newSupplier);

                    await transaction.CommitAsync();

                    return MapToResponseDto(newSupplier, resolvedType.SupplierTypeName, dto.Address.Trim(), resolvedCity.CityName, resolvedState.StateName, resolvedCountry.CountryName, dto.Pincode.Trim());
                }
                catch (SupplierManagementException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new SupplierManagementException($"An error occurred while saving the supplier: {ex.Message}");
                }
            }
        }

        public async Task<SupplierResponseDto> UpdateSupplierAsync(SupplierUpdateDto dto)
        {
            if (dto == null)
            {
                throw new SupplierManagementException("Supplier data is null.");
            }

            // 1. Validate request
            ValidateSupplier(dto.CompanyName, dto.ContactPerson, dto.Age, dto.Phone, dto.Email, dto.SupplierType, dto.Address, dto.City, dto.State, dto.Country, dto.Pincode);

            using (var transaction = await _repository.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve existing supplier
                    var existingSupplier = await _repository.FetchSupplierByIdAsync(dto.SupplierId);
                    if (existingSupplier == null)
                    {
                        throw new SupplierNotFoundException($"Supplier with ID {dto.SupplierId} not found.");
                    }

                    // Check duplicate Company Name
                    if (await _repository.CompanyNameExistsAsync(dto.CompanyName, dto.SupplierId))
                    {
                        throw new SupplierManagementException("Supplier Name already exists.");
                    }

                    // Check duplicate Email
                    if (await _repository.EmailExistsAsync(dto.Email, dto.SupplierId))
                    {
                        throw new SupplierManagementException("Supplier with this email already exists.");
                    }

                    // Check duplicate Phone Number
                    if (await _repository.PhoneExistsAsync(dto.Phone, dto.SupplierId))
                    {
                        throw new SupplierManagementException("Supplier with this phone number already exists.");
                    }

                    // Resolve Supplier Type
                    var resolvedType = await _repository.ResolveSupplierTypeAsync(dto.SupplierType);

                    // Resolve Country, State, City
                    var resolvedCountry = await _repository.ResolveCountryAsync(dto.Country);
                    var resolvedState = await _repository.ResolveStateAsync(dto.State, resolvedCountry.CountryIdPk);
                    var resolvedCity = await _repository.ResolveCityAsync(dto.City, resolvedState.StateIdPk);

                    // Update Address
                    var address = existingSupplier.Address;
                    if (address == null)
                    {
                        var addressId = await _repository.GetNextAddressIdAsync();
                        address = new Address
                        {
                            AddressIdPk = addressId,
                            AddressLine1 = dto.Address.Trim(),
                            CityIdFk = resolvedCity.CityIdPk,
                            Pincode = dto.Pincode.Trim(),
                            CreatedDateTime = DateTime.Now,
                            UpdatedDateTime = DateTime.Now
                        };
                        await _repository.AddAddressAsync(address);
                        existingSupplier.AddressId = addressId;
                    }
                    else
                    {
                        address.AddressLine1 = dto.Address.Trim();
                        address.CityIdFk = resolvedCity.CityIdPk;
                        address.Pincode = dto.Pincode.Trim();
                        address.UpdatedDateTime = DateTime.Now;
                    }

                    // Update Supplier fields
                    existingSupplier.CompanyName = dto.CompanyName.Trim();
                    existingSupplier.ContactPerson = dto.ContactPerson.Trim();
                    existingSupplier.Age = dto.Age;
                    existingSupplier.PhoneNumber = dto.Phone.Trim();
                    existingSupplier.Email = dto.Email.Trim();
                    existingSupplier.SupplierTypeId = resolvedType.SupplierTypeIdPk;
                    existingSupplier.UpdatedDate = DateTime.Now;

                    await _repository.UpdateSupplierAsync(existingSupplier);
                    await transaction.CommitAsync();

                    return MapToResponseDto(existingSupplier, resolvedType.SupplierTypeName, dto.Address.Trim(), resolvedCity.CityName, resolvedState.StateName, resolvedCountry.CountryName, dto.Pincode.Trim());
                }
                catch (SupplierNotFoundException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (SupplierManagementException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new SupplierManagementException($"An error occurred while updating the supplier: {ex.Message}");
                }
            }
        }

        public async Task<IEnumerable<SupplierDetailsDto>> FetchSupplierWithCityNameAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new SupplierManagementException("City name is required.");
            }

            var cleanCityName = cityName.Trim().ToLower();
            var suppliers = await _repository.FetchAllSuppliersAsync();
            var filtered = suppliers.Where(s => 
                s.Address?.City?.CityName != null && 
                s.Address.City.CityName.Trim().ToLower() == cleanCityName
            );

            if (!filtered.Any())
            {
                throw new SupplierManagementException($"No suppliers found in city '{cityName}'.");
            }

            return filtered.Select(s => MapToDetailsDto(s)).ToList();
        }

        // Validators and helpers
        private void ValidateSupplier(string companyName, string contactPerson, int age, string phone, string email, string supplierType, string address, string city, string state, string country, string pincode)
        {
            if (string.IsNullOrWhiteSpace(companyName))
                throw new SupplierManagementException("Supplier Name is required.");
            if (companyName.Length < 3 || companyName.Length > 100)
                throw new SupplierManagementException("Company name must be between 3 and 100 characters.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(companyName, @"^[a-zA-Z0-9\s&\-\.]+$"))
                throw new SupplierManagementException("Company name can only contain alphabets, numbers, spaces, &, -, and .");

            if (string.IsNullOrWhiteSpace(contactPerson))
                throw new SupplierManagementException("Contact person name is required.");
            if (contactPerson.Length < 3 || contactPerson.Length > 100)
                throw new SupplierManagementException("Contact person name must be between 3 and 100 characters.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(contactPerson, @"^[a-zA-Z\s]+$"))
                throw new SupplierManagementException("Contact Person name must contain only alphabetic characters.");

            if (age < 18 || age > 70)
                throw new SupplierManagementException("Age must be between 18 and 70.");

            if (string.IsNullOrWhiteSpace(phone))
                throw new SupplierManagementException("Phone Number is required.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9]{10}$"))
                throw new SupplierManagementException("Invalid Phone Number.");

            if (string.IsNullOrWhiteSpace(email))
                throw new SupplierManagementException("Email is required.");
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                    throw new SupplierManagementException("Invalid Email format.");
            }
            catch
            {
                throw new SupplierManagementException("Invalid Email format.");
            }

            if (string.IsNullOrWhiteSpace(supplierType))
                throw new SupplierManagementException("Supplier type is required.");

            if (string.IsNullOrWhiteSpace(address))
                throw new SupplierManagementException("Address is required.");

            if (string.IsNullOrWhiteSpace(city))
                throw new SupplierManagementException("City is required.");

            if (string.IsNullOrWhiteSpace(state))
                throw new SupplierManagementException("State is required.");

            if (string.IsNullOrWhiteSpace(country))
                throw new SupplierManagementException("Country is required.");

            if (string.IsNullOrWhiteSpace(pincode))
                throw new SupplierManagementException("Pincode is required.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(pincode, @"^[0-9]{6}$"))
                throw new SupplierManagementException("Invalid Pincode.");
        }

        private SupplierDetailsDto MapToDetailsDto(Suppliers s)
        {
            return new SupplierDetailsDto
            {
                SupplierId = s.SupplierId,
                CompanyName = s.CompanyName,
                ContactPerson = s.ContactPerson,
                Age = s.Age,
                Phone = s.PhoneNumber,
                Email = s.Email,
                SupplierType = s.SupplierType?.SupplierTypeName ?? "",
                Address = s.Address?.AddressLine1 ?? "",
                City = s.Address?.City?.CityName ?? "",
                State = s.Address?.City?.State?.StateName ?? "",
                Country = s.Address?.City?.State?.Country?.CountryName ?? "",
                Pincode = s.Address?.Pincode ?? ""
            };
        }

        private SupplierResponseDto MapToResponseDto(Suppliers s, string typeName, string address, string city, string state, string country, string pincode)
        {
            return new SupplierResponseDto
            {
                SupplierId = s.SupplierId,
                CompanyName = s.CompanyName,
                ContactPerson = s.ContactPerson,
                Age = s.Age,
                Phone = s.PhoneNumber,
                Email = s.Email,
                SupplierType = typeName,
                Address = address,
                City = city,
                State = state,
                Country = country,
                Pincode = pincode
            };
        }

        public async Task<IEnumerable<string>> FetchAllSupplierTypesAsync()
        {
            return await _repository.FetchAllSupplierTypesAsync();
        }

        public async Task<IEnumerable<string>> FetchAllCountriesAsync()
        {
            return await _repository.FetchAllCountriesAsync();
        }

        public async Task<IEnumerable<string>> FetchStatesByCountryAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                return Enumerable.Empty<string>();
            }
            return await _repository.FetchStatesByCountryAsync(countryName);
        }

        public async Task<IEnumerable<string>> FetchCitiesByStateAsync(string stateName)
        {
            if (string.IsNullOrWhiteSpace(stateName))
            {
                return Enumerable.Empty<string>();
            }
            return await _repository.FetchCitiesByStateAsync(stateName);
        }
    }
}
