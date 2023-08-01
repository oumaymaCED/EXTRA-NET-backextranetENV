using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PurchaseInvoice
{
    public string PurchaseInvoiceNumber { get; set; } = null!;

    public string DossierNumber { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; } = new List<PurchaseInvoiceLine>();
}
