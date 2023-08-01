using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Services.Contracts;
using DataAccess.Layer.Repositories;
using DataAccess.Layer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly IsalesInvoiceRepository _SalesRepository;
        private readonly IMapper _mapper;

        public SalesInvoiceService(IsalesInvoiceRepository SalesRepository, IMapper mapper)
        {
            _SalesRepository = SalesRepository;
            _mapper = mapper;
        }
        public async Task<List<SalesInvoiceDto>> GetAllSalesInvoices()
        {
            var salesInvoices = _SalesRepository.GetAllSalesInvoices();

            return _mapper.Map<List<SalesInvoiceDto>>(salesInvoices);
        }

        public async Task<SalesInvoiceDto> GetSalesInvoicesById(Guid SalesId)
        {
            var salesInvoice = _SalesRepository.GetAllSalesInvoices().Where(item => item.SalesId == SalesId).FirstOrDefault();
            return _mapper.Map<SalesInvoiceDto>(salesInvoice);
        }
    }
}
