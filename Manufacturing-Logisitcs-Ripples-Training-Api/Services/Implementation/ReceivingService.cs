using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;
using Manufacturing_Logisitcs_Ripples_Training_Api.Repositories;
using Manufacturing_Logisitcs_Ripples_Training_Api.GlobalExceptions;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services.Implementation
{
    public class ReceivingService : IReceivingService
    {
        private readonly IReceivingRepository _repository;

        public ReceivingService(IReceivingRepository repository)
        {
            _repository = repository;
        }

        private async Task<long> GetOrCreateCatalogIdAsync(string catalogType, string catalogKey, string catalogValue)
        {
            var catalog = await _repository.FindCatalogTypeAndKeyAsync(catalogType, catalogKey);
            if (catalog != null)
            {
                return catalog.CatalogIdPk;
            }

            long nextCatalogId = await _repository.GetNextCatalogIdAsync();
            var newCatalog = new Catalog
            {
                CatalogIdPk = nextCatalogId,
                CatalogType = catalogType,
                CatalogKey = catalogKey,
                CatalogValue = catalogValue,
                CreatedDateTime = DateTime.Now
            };
            _repository.AddCatalog(newCatalog);
            await _repository.SaveChangesAsync();
            return nextCatalogId;
        }

        private async Task<long> GetOrCreateStatusIdAsync(string status)
        {
            var catalog = await _repository.FindCatalogStatusAsync(status);
            if (catalog != null)
            {
                return catalog.CatalogIdPk;
            }

            var key = status.ToUpper();
            var value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(status.ToLower());
            return await GetOrCreateCatalogIdAsync("ReceivingStatus", key, value);
        }

        private async Task<long> GetOrCreateUomIdAsync(string uom)
        {
            var catalog = await _repository.FindCatalogUomAsync(uom);
            if (catalog != null)
            {
                return catalog.CatalogIdPk;
            }

            var key = uom.ToUpper();
            var value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(uom.ToLower());
            return await GetOrCreateCatalogIdAsync("UnitOfMeasurement", key, value);
        }

        public async Task<IEnumerable<WarehouseDto>> GetWarehousesAsync()
        {
            var dcs = await _repository.GetWarehousesAsync();
            return dcs.Select(d => new WarehouseDto
            {
                Id = d.DCIdPk,
                Code = $"IDC-00{d.DCIdPk}",
                Name = d.DCName
            });
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipmentsAsync()
        {
            var shipments = await _repository.GetShipmentsAsync();
            var allReceivings = await _repository.GetAllReceivingAsync();

            var list = new List<ShipmentDto>();
            foreach (var s in shipments)
            {
                var productsList = new List<ShipmentProductDto>();
                foreach (var si in s.ShipmentItems.Where(si => si.POItem != null && si.POItem.Product != null))
                {
                    long prodId = si.POItem!.Product!.ProductIdPk;
                    int shippedQty = (int)si.ShippedQuantity;

                    // Calculate total accepted quantity in previous receiving logs for this shipment
                    int totalAccepted = allReceivings
                        .Where(r => r.ShipmentIdFk == s.ShipmentIdPk && 
                                    r.ReceivingStatus?.CatalogKey?.ToUpper() != "CANCELLED")
                        .SelectMany(r => r.DcReceivingItems)
                        .Where(ri => ri.ProductIdFk == prodId)
                        .Sum(ri => ri.AcceptedQuantity);

                    int pendingQty = shippedQty - totalAccepted;
                    if (pendingQty > 0)
                    {
                        productsList.Add(new ShipmentProductDto
                        {
                            Id = prodId,
                            ProductId = $"PRD-{prodId:D3}",
                            ProductName = si.POItem.Product.ProductName ?? "Unknown Product",
                            OrderedQty = pendingQty
                        });
                    }
                }

                if (productsList.Count > 0)
                {
                    list.Add(new ShipmentDto
                    {
                        Id = s.ShipmentIdPk,
                        ShipmentId = s.TrackingNumber ?? $"SHP-{s.ShipmentIdPk:D4}",
                        Products = productsList
                    });
                }
            }

            return list;
        }

        public async Task<IEnumerable<AvailableProductDto>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();
            return products.Select(p => new AvailableProductDto
            {
                Id   = $"PRD-{p.ProductIdPk:D3}",
                Name = p.ProductName!
            });
        }

        public async Task<IEnumerable<string>> GetReceivingStatusesAsync()
        {
            var catalogs = await _repository.GetCatalogsByTypeAsync("ReceivingStatus");
            return catalogs.Select(c => c.CatalogValue ?? c.CatalogKey ?? "Unknown");
        }

        public async Task<IEnumerable<string>> GetQcStatusesAsync()
        {
            var catalogs = await _repository.GetCatalogsByTypeAsync("QcStatus");
            return catalogs.Select(c => c.CatalogValue ?? c.CatalogKey ?? "Unknown");
        }

        public async Task<IEnumerable<ReceivingDto>> SearchReceivingAsync(string? keyword)
        {
            var receivings = await _repository.GetAllReceivingAsync();
            var list = new List<ReceivingDto>();

            foreach (var r in receivings)
            {
                list.Add(await MapToDtoAsync(r));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var key = keyword.ToLower();
                list = list.Where(dto =>
                    dto.ReceivingId.ToLower().Contains(key) ||
                    dto.Shipment.ToLower().Contains(key) ||
                    dto.Warehouse.ToLower().Contains(key) ||
                    dto.Items.Any(i => i.ProductName.ToLower().Contains(key))
                ).ToList();
            }

            return list;
        }

        public async Task<IEnumerable<ReceivingDto>> GetReceivingByStatusAsync(string status)
        {
            var all = await SearchReceivingAsync(null);
            if (string.Equals(status, "All", StringComparison.OrdinalIgnoreCase))
            {
                return all;
            }
            return all.Where(r => string.Equals(r.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<ReceivingDto?> GetReceivingByIdAsync(string receivingId)
        {
            long id = ParseReceivingId(receivingId);
            var r = await _repository.GetReceivingByIdAsync(id);
            if (r == null) return null;
            return await MapToDtoAsync(r);
        }

        public async Task<ReceivingDto> AddReceivingAsync(ReceivingDto receivingDto)
        {
            ValidateReceiving(receivingDto);

            long nextId = await _repository.GetNextReceivingIdAsync();

            var dc = await ResolveDcAsync(receivingDto.Warehouse);
            var shipment = await ResolveShipmentAsync(receivingDto.Shipment);
            long statusId = await GetOrCreateStatusIdAsync(receivingDto.Status);

            var model = new DcReceiving
            {
                DcReceivingIdPk = nextId,
                DcIdFk = dc.DCIdPk,
                ShipmentIdFk = shipment.ShipmentIdPk,
                ReceivingStatusIdFk = statusId,
                Remarks = $"Received via Frontend App. Total Products: {receivingDto.TotalProducts}",
                CreatedDateTime = DateTime.Now
            };

            _repository.AddReceiving(model);
            await _repository.SaveChangesAsync();

            long itemNextId = await _repository.GetNextReceivingItemIdAsync();
            foreach (var itemDto in receivingDto.Items)
            {
                var product = await ResolveProductAsync(itemDto.ProductId);

                int acceptedQty = 0;
                if (itemDto.QcStatus == "Passed")
                {
                    acceptedQty = itemDto.ReceivedQty;
                }

                var itemModel = new DcReceivingItem
                {
                    DcReceivingItemsIdPk = itemNextId++,
                    DcReceivingIdFk = nextId,
                    ProductIdFk = product.ProductIdPk,
                    ReceivedQuantity = itemDto.ReceivedQty,
                    DamagedQuantity = itemDto.DamagedQty,
                    AcceptedQuantity = acceptedQty,
                    CreatedDateTime = DateTime.Now
                };
                _repository.AddReceivingItem(itemModel);
            }

            await _repository.SaveChangesAsync();

            var created = await GetReceivingByIdAsync($"RCV-{nextId}");
            return created ?? receivingDto;
        }

        public async Task<ReceivingDto> UpdateReceivingAsync(ReceivingDto receivingDto)
        {
            ValidateReceiving(receivingDto);

            long id = ParseReceivingId(receivingDto.ReceivingId);
            var model = await _repository.GetReceivingByIdAsync(id);

            if (model == null)
            {
                throw new KeyNotFoundException($"Receiving record with ID {receivingDto.ReceivingId} not found.");
            }

            var dc = await ResolveDcAsync(receivingDto.Warehouse);
            long statusId = await GetOrCreateStatusIdAsync(receivingDto.Status);

            model.DcIdFk = dc.DCIdPk;
            model.ReceivingStatusIdFk = statusId;
            model.UpdatedDateTime = DateTime.Now;

            _repository.RemoveReceivingItems(model.DcReceivingItems);

            long itemNextId = await _repository.GetNextReceivingItemIdAsync();
            foreach (var itemDto in receivingDto.Items)
            {
                var product = await ResolveProductAsync(itemDto.ProductId);

                int acceptedQty = 0;
                if (itemDto.QcStatus == "Passed")
                {
                    acceptedQty = itemDto.ReceivedQty;
                }

                var itemModel = new DcReceivingItem
                {
                    DcReceivingItemsIdPk = itemNextId++,
                    DcReceivingIdFk = id,
                    ProductIdFk = product.ProductIdPk,
                    ReceivedQuantity = itemDto.ReceivedQty,
                    DamagedQuantity = itemDto.DamagedQty,
                    AcceptedQuantity = acceptedQty,
                    UpdatedDateTime = DateTime.Now
                };
                _repository.AddReceivingItem(itemModel);
            }

            await _repository.SaveChangesAsync();

            var updated = await GetReceivingByIdAsync(receivingDto.ReceivingId);
            return updated ?? receivingDto;
        }

        public async Task<bool> DeleteReceivingAsync(string receivingId)
        {
            long id = ParseReceivingId(receivingId);
            var model = await _repository.GetReceivingByIdAsync(id);

            if (model == null) return false;

            _repository.RemoveReceivingItems(model.DcReceivingItems);
            _repository.RemoveReceiving(model);
            await _repository.SaveChangesAsync();
            return true;
        }

        private async Task<ReceivingDto> MapToDtoAsync(DcReceiving r)
        {
            var warehouseName = r.Dc?.DCName ?? "Unknown DC";
            var shipmentCode = r.Shipment?.TrackingNumber ?? $"SHP-{r.ShipmentIdFk:D4}";

            var dto = new ReceivingDto
            {
                ReceivingId = $"RCV-{r.DcReceivingIdPk:D4}",
                Shipment = shipmentCode,
                Warehouse = $"IDC-00{r.DcIdFk}",
                TotalProducts = r.DcReceivingItems.Count,
                TotalQuantity = r.DcReceivingItems.Sum(ri => ri.ReceivedQuantity),
                Status = r.ReceivingStatus?.CatalogKey ?? "COMPLETED",
                CreatedDate = (r.CreatedDateTime ?? DateTime.Now).ToString("dd-MMM-yyyy"),
                Items = new List<ReceivingItemDto>()
            };

            foreach (var ri in r.DcReceivingItems)
            {
                string qc = "Pending";
                if (ri.AcceptedQuantity > 0)
                {
                    qc = "Passed";
                }
                else if (ri.ReceivedQuantity > 0 || (ri.DamagedQuantity ?? 0) > 0)
                {
                    qc = "Failed";
                }

                int orderedQty = 0;
                var shipItem = await _repository.FindShipmentItemForProductAsync(r.ShipmentIdFk, ri.ProductIdFk);
                if (shipItem != null)
                {
                    orderedQty = (int)shipItem.ShippedQuantity;
                }

                dto.Items.Add(new ReceivingItemDto
                {
                    ProductId = $"PRD-{ri.ProductIdFk:D3}",
                    ProductName = ri.Product?.ProductName ?? "Unknown Product",
                    OrderedQty = orderedQty,
                    ReceivedQty = ri.ReceivedQuantity,
                    DamagedQty = ri.DamagedQuantity ?? 0,
                    QcStatus = qc
                });
            }

            return dto;
        }

        private long ParseReceivingId(string idStr)
        {
            if (idStr.StartsWith("RCV-", StringComparison.OrdinalIgnoreCase))
            {
                idStr = idStr.Substring(4);
            }
            return long.TryParse(idStr, out long val) ? val : 0;
        }

        private async Task<DC> ResolveDcAsync(string warehouseStr)
        {
            if (string.IsNullOrWhiteSpace(warehouseStr) || !warehouseStr.StartsWith("IDC-", StringComparison.OrdinalIgnoreCase))
            {
                throw new GlobalException("Warehouse must be a valid code starting with IDC- (e.g., IDC-001). Name is not accepted.");
            }

            var dc = await _repository.FindDcByNameOrIdAsync(warehouseStr);
            if (dc == null)
            {
                throw new GlobalException($"Warehouse with code '{warehouseStr}' does not exist.");
            }
            return dc;
        }

        private async Task<Product> ResolveProductAsync(string productIdStr)
        {
            if (string.IsNullOrWhiteSpace(productIdStr) || !productIdStr.StartsWith("PRD-", StringComparison.OrdinalIgnoreCase))
            {
                throw new GlobalException("Product ID must be a valid code starting with PRD- (e.g., PRD-001). Name is not accepted.");
            }

            if (!long.TryParse(productIdStr.Substring(4), out long id))
            {
                throw new GlobalException($"Invalid Product ID format: '{productIdStr}'.");
            }

            var product = await _repository.FindProductByIdAsync(id);
            if (product == null)
            {
                throw new GlobalException($"Product with ID '{productIdStr}' does not exist in the database.");
            }
            return product;
        }

        private async Task<Shipment> ResolveShipmentAsync(string shipmentStr)
        {
            var shipment = await _repository.FindShipmentByTrackingOrIdAsync(shipmentStr);
            if (shipment == null)
            {
                long nextShipmentId = await _repository.GetNextShipmentIdAsync();

                // Resolve Carrier ID
                var carrierName = "DHL Express";
                var carrier = await _repository.FindCarrierByNameAsync(carrierName);
                if (carrier == null)
                {
                    long nextCarrierId = await _repository.GetNextCarrierIdAsync();
                    carrier = new Carriers
                    {
                        CarrierIdPk = nextCarrierId,
                        CarrierName = carrierName,
                        CreatedDateTime = DateTime.Now
                    };
                    _repository.AddCarrier(carrier);
                    await _repository.SaveChangesAsync();
                }

                // Resolve Purchase Order
                long poId = 1;
                var po = await _repository.FindPurchaseOrderByIdAsync(poId);
                if (po == null)
                {
                    long nextPoId = await _repository.GetNextPurchaseOrderIdAsync();
                    po = new PurchaseOrder
                    {
                        PurchaseOrderIdPk = nextPoId,
                        PoDate = DateTime.Now.AddDays(-7),
                        ExpectedDeliveryDate = DateTime.Now.AddDays(3),
                        OrderStatusIdFk = await GetOrCreateCatalogIdAsync("OrderStatus", "APPROVED", "Approved"),
                        CurrencyIdFk = await GetOrCreateCatalogIdAsync("Currency", "USD", "USD"),
                        CreatedDateTime = DateTime.Now
                    };
                    _repository.AddPurchaseOrder(po);
                    await _repository.SaveChangesAsync();
                    poId = nextPoId;
                }

                long shipmentStatusId = await GetOrCreateCatalogIdAsync("ShipmentStatus", "INTRANSIT", "In Transit");
                long transportModeId = await GetOrCreateCatalogIdAsync("TransportMode", "ROAD", "Road");

                shipment = new Shipment
                {
                    ShipmentIdPk = nextShipmentId,
                    PurchaseOrderIdFk = poId,
                    ShipmentStatusIdFk = shipmentStatusId,
                    TransportModeIdFk = transportModeId,
                    CarrierIdFk = carrier.CarrierIdPk,
                    TrackingNumber = shipmentStr,
                    DispatchDate = DateTime.Now.AddDays(-2),
                    EstimatedArrival = DateTime.Now.AddDays(2),
                    CurrentLocationIdFk = 1,
                    OriginLocationIdFk = 1,
                    CreatedDateTime = DateTime.Now
                };
                _repository.AddShipment(shipment);
                await _repository.SaveChangesAsync();
            }
            return shipment;
        }

        private void ValidateReceiving(ReceivingDto receivingDto)
        {
            if (receivingDto == null)
            {
                throw new GlobalException("Receiving payload cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(receivingDto.Warehouse))
            {
                throw new GlobalException("Warehouse/DC is required.");
            }
            if (!receivingDto.Warehouse.StartsWith("IDC-", StringComparison.OrdinalIgnoreCase))
            {
                throw new GlobalException("Warehouse must be a valid code starting with IDC- (e.g., IDC-001). Name is not accepted.");
            }
            if (string.IsNullOrWhiteSpace(receivingDto.Shipment))
            {
                throw new GlobalException("Shipment tracking number is required.");
            }
            if (receivingDto.Items == null || receivingDto.Items.Count == 0)
            {
                throw new GlobalException("At least one product item is required for receiving.");
            }

            foreach (var item in receivingDto.Items)
            {
                if (string.IsNullOrWhiteSpace(item.ProductId))
                {
                    throw new GlobalException("Product ID is required.");
                }
                var productIdentifier = !string.IsNullOrWhiteSpace(item.ProductName) 
                    ? $"{item.ProductId} ({item.ProductName})" 
                    : item.ProductId;

                if (item.ReceivedQty < 0)
                {
                    throw new GlobalException($"Received quantity for product '{productIdentifier}' cannot be negative.");
                }
                if (item.DamagedQty < 0)
                {
                    throw new GlobalException($"Damaged quantity for product '{productIdentifier}' cannot be negative.");
                }
                if (item.ReceivedQty + item.DamagedQty != item.OrderedQty)
                {
                    throw new GlobalException($"Total received and damaged quantity ({item.ReceivedQty + item.DamagedQty}) must match the ordered quantity ({item.OrderedQty}) for product '{productIdentifier}'.");
                }
            }
        }
    }
}
