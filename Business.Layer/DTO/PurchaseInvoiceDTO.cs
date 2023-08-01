
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public  class PurchaseInvoiceDTO
    {
        public string PurchaseInvoiceNumber { get; set; } = null!;

        public string DossierNumber { get; set; } = null!;

        public DateTime InvoiceDate { get; set; }
        public decimal TotalGrossAmount { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalNetAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public virtual ICollection<purchaseInvoiceLineDTO> PurchaseInvoiceLines { get; set; } = new List<purchaseInvoiceLineDTO>();

    }
}


