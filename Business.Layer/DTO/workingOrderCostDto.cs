using DataAccess.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class workingOrderCostDto
    {
        public Guid? idworkingOrder { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }

        // Ajouté recenement 
        public double? Quantity { get; set; }
        public double? TaxRate { get; set; }
        public decimal? UnitPrice { get; set; }

        public SeviceOrderCostDto? Services { get; set; }
    }
}
