
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class purchaseInvoiceLineDTO
    {

        public string WorkingOrdernumber { get; set; } = null!;

        public decimal NetAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public int Quantity { get; set; }

        public decimal TaxRate { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Discount { get; set; } = null!;

        public string? PurchaseInvoiceNumber { get; set; } = null!;
        public string ServiceID { get; set; } = null!;
        public bool IsTaken { get; set; } = true;



    }
}
