using System;
using System.Collections.Generic;

namespace DataAccess.Layer.Models
{
public  class WorkingOrder
{
    
    //public Guid DosId { get; set; }
    public string? WoWorkingOrderNumber { get; set; }
    public List<workingorderCost> workingorderCosts { get; set; } = new List<workingorderCost>();

   
}
}
