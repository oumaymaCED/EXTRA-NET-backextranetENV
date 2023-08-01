using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class DossierInfoDetails
    {
        //workingOrder
        public string? WoWorkingOrderNumber { get; set; }

        //WORKINGOrderCost
        public decimal? NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }

        //TABLE  Service
        public Guid ServiceID { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceShortName { get; set; }
        public string? ServiceLongName { get; set; }
    }
}
