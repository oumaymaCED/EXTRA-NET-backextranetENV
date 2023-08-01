using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class PurchaseInvoiceGeneral
    {
        public string PurchaseInvoiceNumber { get; set; } = null!;

        public string DossierNumber { get; set; } = null!;

        public DateTime InvoiceDate { get; set; }
        public int PurchaseInvoiceLineId { get; set; }

        public string WorkingOrdernumber { get; set; } = null!;

        public decimal NetAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public int Quantity { get; set; }

        public decimal TaxRate { get; set; }

        public decimal UnitPrice { get; set; }

        public string Discount { get; set; } = null!;

        public decimal TotalGrossAmount { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalNetAmount { get; set; }

        public decimal TotalDiscount { get; set; }


        public virtual PurchaseInvoice PurchaseInvoiceNumberNavigation { get; set; } = null!;
    }
}
