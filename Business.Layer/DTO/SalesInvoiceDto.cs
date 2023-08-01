using DataAccess.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class SalesInvoiceDto
    {
        public Guid SalesId { get; set; }
        public string? SalesNumber { get; set; }
        public DateTime? SalesIDate { get; set; }
        public decimal? SalesTotalGrossAmount { get; set; }
        public decimal? SalesTotalTaxAmount { get; set; }
        public decimal? SalesTotalNetAmount { get; set; }
        public string? SalesDossierNumber { get; set; }
        public string? StatusCode { get; set; }
        public string? StatusName { get; set; }

        public List<SalesInvoiceLinesDto>? SalesInvoiceLines { get; set; }
    }
}
