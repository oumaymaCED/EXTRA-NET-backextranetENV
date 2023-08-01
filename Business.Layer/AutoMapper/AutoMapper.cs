using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Layer.Models;
using Business.Layer.DTO;
using AutoMapper;

namespace Business.Layer.AutoMapper
{
    public class AutoMapper : Profile
    {  
        public AutoMapper() {

            CreateMap<DossierDto, Dossier>();
            CreateMap<Dossier, DossierDto>();
            


            CreateMap<DossierInfoGeneral, Dossier>();
            CreateMap<Dossier, DossierInfoGeneral>();
           /* .ForMember(dest => dest.DosId, opt => opt.MapFrom(src => src.DosId))
            .ForMember(dest => dest.DosDossierNumber, opt => opt.MapFrom(src => src.DosDossierNumber))
            .ForMember(dest => dest.DosCurrentStatusCode, opt => opt.MapFrom(src => src.DosCurrentStatusCode))
            .ForMember(dest => dest.DosIntakeDate, opt => opt.MapFrom(src => src.DosIntakeDate))
            .ForMember(dest => dest.DosIncidentDate, opt => opt.MapFrom(src => src.DosIncidentDate))
            .ForMember(dest => dest.DosCreatedDate, opt => opt.MapFrom(src => src.DosCreatedDate))
            .ForMember(dest => dest.DosIncidentCountryId, opt => opt.MapFrom(src => src.DosIncidentCountryId));
           */
            
            CreateMap<DossierInfoGeneral, DossierDtoGeneral>();
            CreateMap<DossierDtoGeneral, DossierInfoGeneral>();

            CreateMap<DossierInfoDetails, Dossier>();
            CreateMap<Dossier, DossierInfoDetails>();
            
            CreateMap<DossierInfoDetails, DossierDtoDetails>();
            CreateMap<DossierDtoDetails, DossierInfoDetails>();

            CreateMap<ServiceByWorkingorderCost, SeviceOrderCostDto>();
            CreateMap<SeviceOrderCostDto, ServiceByWorkingorderCost>();

            CreateMap<WorkingOrder, WorkingOrderDto>();
            CreateMap<WorkingOrderDto, WorkingOrder>();

            CreateMap<workingorderCost, workingOrderCostDto>();
            CreateMap<workingOrderCostDto, workingorderCost>();

            CreateMap<SalesInvoiceDto, SalesInvoices>();
            CreateMap<SalesInvoices, SalesInvoiceDto>();

            CreateMap<SalesInvoiceLinesDto,SalesInvoicesLines>();
            CreateMap<SalesInvoicesLines, SalesInvoiceLinesDto>();





            CreateMap<DataAccess.Layer.Models.PurchaseInvoice, PurchaseInvoiceDTO>();
            CreateMap<PurchaseInvoiceDTO, DataAccess.Layer.Models.PurchaseInvoice>();

            CreateMap<purchaseInvoiceLineDTO, DataAccess.Layer.Models.PurchaseInvoiceLine>();
            CreateMap<DataAccess.Layer.Models.PurchaseInvoiceLine, purchaseInvoiceLineDTO>();



        }


    }
        
}
