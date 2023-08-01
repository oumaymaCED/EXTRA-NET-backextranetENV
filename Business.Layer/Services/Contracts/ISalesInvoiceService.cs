using Business.Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services.Contracts
{
    public interface ISalesInvoiceService
    {
        Task<List<SalesInvoiceDto>> GetAllSalesInvoices();
        Task<SalesInvoiceDto> GetSalesInvoicesById(Guid SalesId);

    }
}
