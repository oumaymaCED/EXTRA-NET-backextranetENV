using System;
using System.Collections.Generic;

namespace DataAccess.Layer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public partial class PurchaseInvoiceLine
{
    [Key]
    public int? PurchaseInvoiceLineId { get; set; }

    public string? WorkingOrdernumber { get; set; } = null!;

    public decimal NetAmount { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? GrossAmount { get; set; }

    public int Quantity { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? UnitPrice { get; set; }

    public string? Discount { get; set; } = null!;

    
    public string? PurchaseInvoiceNumber { get; set; } = null!;
    public string ServiceID { get; set; } = null!;
    public bool IsTaken { get; set; } = true;


    public virtual PurchaseInvoice? PurchaseInvoiceNumberNavigation { get; set; } = null!;
}
