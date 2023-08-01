using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class SalesInvoicesLines
    {
        

        //SalesInvoiceLines

        public Guid SalesInvoiceLineId { get; set; }

        public decimal? UnitPriceLine { get; set; }
        public double? QuantityLine { get; set; }
        public decimal? NetAmountLine { get; set; }
        public double? TaxRateLine { get; set; }
        public decimal? TaxAmountLine { get; set; }
        public decimal? DiscountLine { get; set; }
        public decimal? GrossAmountLine { get; set; }


    }
}
