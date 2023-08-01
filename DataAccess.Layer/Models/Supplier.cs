using System;
using System.Collections.Generic;

namespace DataAccess.Layer.Models;

public partial class Supplier
{
    public Guid SupId { get; set; }

    public byte[] SupTimeStamp { get; set; } = null!;

    public string? SupExternalCode { get; set; }

    public Guid? SupPartnerId { get; set; }

    public string? SupCultureCodePreferredLanguage { get; set; }

    public string? SupPaymentBatchEmail { get; set; }

    public bool? SupIsPreferredSupplier { get; set; }

    public string? SupCurrencyCode { get; set; }

    public bool? SupInactive { get; set; }

    public DateTime SupCreatedDate { get; set; }

    public string? SupCreatedBy { get; set; }

    public DateTime SupLastModifiedDate { get; set; }

    public string? SupLastModifiedBy { get; set; }
}
