using System;
using System.Collections.Generic;
using System.Text;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ProcurementOrderManagementDto
    {
        public long PurchaseOrderIdPk { get; set; }

        public long SupplierIdFk { get; set; }

        public long PurchaseOrderStatusIdFk { get; set; }

        public long CurrencyIdFk { get; set; }

        public DateTime PurchaseOrderDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public long? ApprovedByUserIdFk { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public long CreatedByUserIdFk { get; set; }

        public long UpdatedByUserIdFk { get; set; }

        public string? ProductName { get; set; }

        public int ItemsCount { get; set; }

        public short PurchasedQuantity { get; set; }

        public decimal UnitPrice { get; set; }

        public long PurchaseOrderItemIdPk { get; set; }

        public long ProductSupplierIdFk { get; set; }

        public List<ProcurementOrderManagementDto>? ItemList { get; set; }

        public override string ToString()
        {
            string result = "";

            if (PurchaseOrderIdPk != 0)
                result += "PurchaseOrderIdPk : " + PurchaseOrderIdPk + ", ";

            if (SupplierIdFk != 0)
                result += "SupplierIdFk : " + SupplierIdFk + ", ";

            if (PurchaseOrderStatusIdFk != 0)
                result += "PurchaseOrderStatusIdFk : " + PurchaseOrderStatusIdFk + ", ";

            if (CurrencyIdFk != 0)
                result += "CurrencyIdFk : " + CurrencyIdFk + ", ";

            if (PurchaseOrderDate != DateTime.MinValue)
                result += "PODate : " + PurchaseOrderDate + ", ";

            if (ExpectedDeliveryDate != DateTime.MinValue)
                result += "ExpectedDeliveryDate : " + ExpectedDeliveryDate + ", ";

            if (ApprovedByUserIdFk != null)
                result += "ApprovedByUserIdFk : " + ApprovedByUserIdFk + ", ";

            if (CreatedDateTime != DateTime.MinValue)
                result += "CreatedDateTime : " + CreatedDateTime + ", ";

            if (UpdatedDateTime != DateTime.MinValue)
                result += "UpdatedDateTime : " + UpdatedDateTime + ", ";

            if (CreatedByUserIdFk != 0)
                result += "CreatedByUserIdFk : " + CreatedByUserIdFk + ", ";

            if (UpdatedByUserIdFk != 0)
                result += "UpdatedByUserIdFk : " + UpdatedByUserIdFk + ", ";

            if (!string.IsNullOrEmpty(ProductName))
                result += "ProductName : " + ProductName + ", ";

            if (ItemsCount != 0)
                result += "ItemsCount : " + ItemsCount + ", ";

            if (PurchasedQuantity != 0)
                result += "PurchasedQuantity : " + PurchasedQuantity + ", ";

            if (UnitPrice != 0)
                result += "UnitPrice : " + UnitPrice + ", ";

            if (PurchaseOrderItemIdPk != 0)
                result += "PurchaseOrderItemIdPk : " + PurchaseOrderItemIdPk + ", ";

            if (ProductSupplierIdFk != 0)
                result += "ProductSupplierIdFk : " + ProductSupplierIdFk + ", ";

            return result.TrimEnd(',', ' ');
        }
    }
}
