using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Layer.Models;

public partial class PurchaseInvoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ajouter cet attribut

    public string PurchaseInvoiceNumber { get; set; } = null!;

    public string DossierNumber { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public decimal? TotalGrossAmount { get; set; }

    public decimal? TotalTaxAmount { get; set; }

    public decimal? TotalNetAmount { get; set; }

    public decimal? TotalDiscount { get; set; }

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = new List<PurchaseInvoiceLine>();
}
