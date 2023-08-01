using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Services.Contracts;
using DataAccess.Layer.Models;
using DataAccess.Layer.Repositories;
using DataAccess.Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Layer.Services
{
    public class DossierService : IDossierService
    {
        private readonly IDossierRepository _dossierRepository;
        private readonly IMapper _mapper;

        public DossierService(IDossierRepository dossierRepository, IMapper mapper)
        {
            _dossierRepository = dossierRepository;
            _mapper = mapper;
        }
        // Afficher tous les informations de dossiers

        public async Task<List<DossierDto>> GetAllDossiers()
        {
            var dossiers = _dossierRepository.GetAllDossiers();

            return _mapper.Map<List<DossierDto>>(dossiers); 
        }

        public async Task<DossierDto> GetDossierById(Guid dosId)
        {
            var dossier = _dossierRepository.GetAllDossiers().Where(item => item.DosId == dosId).FirstOrDefault();
            return _mapper.Map<DossierDto>(dossier);
        }



        //Afficher quelques informations de doosier en générale 

        public async Task<List<DossierDtoGeneral>> GetDossierGeneral()
        {
                 var dossierGeneral = _dossierRepository.GetDossierGeneral();
                 return _mapper.Map<List<DossierDtoGeneral>>(dossierGeneral);
          

        }

        //Afficher les informations détaillées de dossiers
        public  async Task<List<DossierDtoDetails>> GetDossierDetails()
        {
             var dossierDetails = _dossierRepository.GetDossierDetails();
             return _mapper.Map<List<DossierDtoDetails>>(dossierDetails);

            /* var   dossiers = _dossierRepository.GetAllDossiers();

            var dossierDetailsDtos = new List<DossierDtoDetails>(); 

            foreach (var dossier in dossiers)
            {
                var dossierInfoDetails =  _dossierRepository.GetDossierDetails();

                var dossierDetailsDto = _mapper.Map<DossierDtoDetails>(dossierInfoDetails);

                dossierDetailsDtos.Add(dossierDetailsDto);
            }

            return dossierDetailsDtos; */
        }
        public async Task<List<WorkingOrderDto>> GetWorkingOrder()
        {
            var WorkingOrder = _dossierRepository.GetWorkingOrder();
            return _mapper.Map<List<WorkingOrderDto>>(WorkingOrder);


        }
        public async Task<List<SeviceOrderCostDto>> GetServiceByWorkingorderCost()
        {
            var ServiceByCost = _dossierRepository.GetServiceByWorkingorderCost();
            return _mapper.Map<List<SeviceOrderCostDto>>(ServiceByCost);

        }






    }
}
