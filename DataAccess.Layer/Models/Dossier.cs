using System;
using System.Collections.Generic;

namespace DataAccess.Layer.Models;

public partial class Dossier
{
    //TABLE DOSSIER
    public Guid? DosId { get; set; }
    public string? DosDossierNumber { get; set; }

    public string? DosStatusLongName { get; set; }
    public DateTime? DosIntakeDate { get; set; }
     
    public DateTime? DosIncidentDate { get; set; }
    public DateTime DosCreatedDate { get; set; }
    public string? DosIncidentCountryId { get; set; }

    public List<WorkingOrder>? workingOrder { get; set; } 

    

   
}
