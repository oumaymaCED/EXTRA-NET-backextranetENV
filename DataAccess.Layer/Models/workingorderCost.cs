using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class workingorderCost
    {   public Guid? idworkingOrder { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        //Ajouté recennement 
        public double? Quantity { get; set; }
        public double? TaxRate { get; set; }
        public decimal? UnitPrice { get; set; }

        public ServiceByWorkingorderCost? Services { get; set; }

    }
}
