using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Layer.DataContext;
using DataAccess.Layer.Models;
using Business.Layer.DTO;


namespace Business.Layer.Services.Contracts
{
    public interface IDossierService
    {
        Task<List<DossierDto>>GetAllDossiers();
        Task<List<DossierDtoGeneral>> GetDossierGeneral();
        Task<List<DossierDtoDetails>> GetDossierDetails();
        Task <List<WorkingOrderDto>> GetWorkingOrder();
        Task<List<SeviceOrderCostDto>> GetServiceByWorkingorderCost(); 

        Task<DossierDto> GetDossierById( Guid dosId);

    }
}
