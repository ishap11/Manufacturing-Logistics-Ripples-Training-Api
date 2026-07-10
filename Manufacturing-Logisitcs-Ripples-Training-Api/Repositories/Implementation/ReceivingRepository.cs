using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories.Implementation
{
    public class ReceivingRepository// : IReceivingRepository
    {/*
        private readonly ManufacturingLogisticsDbContext _context;

        public ReceivingRepository(ManufacturingLogisticsDbContext context)
        {
            _context = context;
        }

        private async Task<long> GetNextIdInternalAsync<T>(Expression<Func<T, long>> keySelector) where T : class
        {
            bool any = await _context.Set<T>().AnyAsync();
            if (!any) return 1;
            return (await _context.Set<T>().MaxAsync(keySelector)) + 1;
        }

        public async Task<IEnumerable<DC>> GetWarehousesAsync()
        {
            return await _context.DCs.ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> GetShipmentsAsync()
        {
            return await _context.Shipments
                .Include(s => s.ShipmentItems)
                    .ThenInclude(si => si.POItem)
                        .ThenInclude(poi => poi!.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<DcReceiving>> GetAllReceivingAsync()
        {
            return await _context.DcReceivings
                .Include(r => r.Dc)
                .Include(r => r.Shipment)
                .Include(r => r.ReceivingStatus)
                .Include(r => r.DcReceivingItems)
                    .ThenInclude(ri => ri.Product)
                .ToListAsync();
        }

        public async Task<DcReceiving?> GetReceivingByIdAsync(long id)
        {
            return await _context.DcReceivings
                .Include(r => r.Dc)
                .Include(r => r.Shipment)
                .Include(r => r.ReceivingStatus)
                .Include(r => r.DcReceivingItems)
                    .ThenInclude(ri => ri.Product)
                .FirstOrDefaultAsync(x => x.DcReceivingIdPk == id);
        }

        public async Task<DC?> FindDcByNameOrIdAsync(string warehouseStr)
        {
            if (warehouseStr.StartsWith("IDC-"))
            {
                if (long.TryParse(warehouseStr.Replace("IDC-", ""), out long id))
                {
                    var dcById = await _context.DCs.FindAsync(id);
                    if (dcById != null) return dcById;
                }
            }
            return await _context.DCs.FirstOrDefaultAsync(d => d.DCName == warehouseStr);
        }

        public async Task<Shipment?> FindShipmentByTrackingOrIdAsync(string shipmentStr)
        {
            if (shipmentStr.StartsWith("SHP-"))
            {
                if (long.TryParse(shipmentStr.Replace("SHP-", ""), out long id))
                {
                    var shpById = await _context.Shipments.FindAsync(id);
                    if (shpById != null) return shpById;
                }
            }
            return await _context.Shipments.FirstOrDefaultAsync(s => s.TrackingNumber == shipmentStr);
        }

        public async Task<Catalog?> FindCatalogStatusAsync(string status)
        {
            return await _context.Catalogs
                .FirstOrDefaultAsync(c => c.CatalogType == "ReceivingStatus" && c.CatalogKey == status);
        }

        public async Task<Product?> FindProductByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductName == name);
        }

        public async Task<ShipmentItem?> FindShipmentItemForProductAsync(long shipmentId, long productId)
        {
            return await _context.ShipmentItems
                .Include(si => si.POItem)
                .FirstOrDefaultAsync(si => si.ShipmentIdFk == shipmentId && si.POItem != null && si.POItem.ProductIdFk == productId);
        }

        public async Task<long> GetNextReceivingIdAsync()
        {
            return await GetNextIdInternalAsync<DcReceiving>(r => r.DcReceivingIdPk);
        }

        public async Task<long> GetNextReceivingItemIdAsync()
        {
            return await GetNextIdInternalAsync<DcReceivingItem>(ri => ri.DcReceivingItemsIdPk);
        }

        public async Task<long> GetNextCatalogIdAsync()
        {
            return await GetNextIdInternalAsync<Catalog>(c => c.CatalogIdPk);
        }

        public async Task<long> GetNextDcIdAsync()
        {
            return await GetNextIdInternalAsync<DC>(d => d.DCIdPk);
        }

        public async Task<long> GetNextShipmentIdAsync()
        {
            return await GetNextIdInternalAsync<Shipment>(s => s.ShipmentIdPk);
        }

        public void AddReceiving(DcReceiving receiving)
        {
            _context.DcReceivings.Add(receiving);
        }

        public void AddReceivingItem(DcReceivingItem item)
        {
            _context.DcReceivingItems.Add(item);
        }

        public void RemoveReceivingItems(IEnumerable<DcReceivingItem> items)
        {
            _context.DcReceivingItems.RemoveRange(items);
        }

        public void RemoveReceiving(DcReceiving receiving)
        {
            _context.DcReceivings.Remove(receiving);
        }

        public void AddCatalog(Catalog catalog)
        {
            _context.Catalogs.Add(catalog);
        }

        public void AddDc(DC dc)
        {
            _context.DCs.Add(dc);
        }

        public void AddShipment(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }*/
    }
}
