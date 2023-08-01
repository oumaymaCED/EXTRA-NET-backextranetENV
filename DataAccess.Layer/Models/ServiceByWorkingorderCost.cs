using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class ServiceByWorkingorderCost
    {
        public Guid? ServiceID { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceShortName { get; set; }
        public string? ServiceLongName { get; set; }
    }
}
