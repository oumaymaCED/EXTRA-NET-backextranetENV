using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Layer.Models;

namespace Business.Layer.DTO
{
    public class WorkingOrderDto
    {
        public string? WoWorkingOrderNumber { get; set; }
        public List<workingOrderCostDto> workingorderCosts { get; set; } = new List<workingOrderCostDto>();
    }
}
