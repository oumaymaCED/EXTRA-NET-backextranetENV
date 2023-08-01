using System;
using System.Collections.Generic;

namespace DataAccess.Layer.Models;

public partial class Client
{
    public Guid ClId { get; set; }

    public byte[] ClTimeStamp { get; set; } = null!;

    public string? ClExternalCode { get; set; }

    public string? ClCultureCodePreferredLanguage { get; set; }

    public string? ClCurrencyCode { get; set; }

    public bool? ClInactive { get; set; }

    public DateTime ClCreatedDate { get; set; }

    public string? ClCreatedBy { get; set; }

    public DateTime ClLastModifiedDate { get; set; }

    public string? ClLastModifiedBy { get; set; }
}
