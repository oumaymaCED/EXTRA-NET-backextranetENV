using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PurchaseInvoiceLine
{
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

    public string PurchaseInvoiceNumber { get; set; } = null!;

    public virtual PurchaseInvoice PurchaseInvoiceNumberNavigation { get; set; } = null!;
}
