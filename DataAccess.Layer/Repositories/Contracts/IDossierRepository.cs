using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Layer.Models;

namespace DataAccess.Layer.Repositories.Contracts
{
    public interface IDossierRepository
    {
        List<Dossier> GetAllDossiers();
        List<DossierInfoGeneral>GetDossierGeneral();
        List<DossierInfoDetails>GetDossierDetails();

        List<WorkingOrder> GetWorkingOrder(); 

        List<ServiceByWorkingorderCost> GetServiceByWorkingorderCost();
    }
    

}
