namespace ManufacturingLogisticsMVC.Models.StoreManagement
{
    // ─── Request DTOs ───────────────────────────────────────────────────────────

    public class StoreProfileInsertRequest
    {
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public long? StoreManagerIdFk { get; set; }
        public long? AddressIdFk { get; set; }
        public long? StoreStatusIdFk { get; set; }
        public long? CreatedByUserIdFk { get; set; }
    }

    public class StoreProfileUpdateRequest
    {
        public long StoreIdPK { get; set; }
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public long? StoreManagerIdFk { get; set; }
        public long? AddressIdFk { get; set; }
        public long? StoreStatusIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }

    public class StoreProfileFilterRequest
    {
        public string? StoreName { get; set; }
        public string? StoreManagerName { get; set; }
        public long? StoreStatusIdFk { get; set; }
    }

    // ─── Response DTOs ──────────────────────────────────────────────────────────

    public class StoreProfileResponse
    {
        public long StoreIdPK { get; set; }
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public long? StoreManagerIdFk { get; set; }
        public long? AddressIdFk { get; set; }
        public long? StoreStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }

    public class StoreProfileWithManagerResponse
    {
        public long StoreIdPK { get; set; }
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public long? StoreStatusIdFk { get; set; }
        public long? AddressIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        // Joined Manager fields
        public long? StoreManagerIdFk { get; set; }
        public string? StoreManagerName { get; set; }
        public string? StoreManagerContactPhone { get; set; }
        public string? StoreManagerContactEmail { get; set; }
    }
}
