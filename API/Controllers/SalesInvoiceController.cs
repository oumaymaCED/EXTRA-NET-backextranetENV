using Business.Layer.Services;
using Business.Layer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SalesInvoiceController : ControllerBase
    {
        private readonly ISalesInvoiceService _salesInvoiceService;
        private readonly HttpClient _httpClient;


        public SalesInvoiceController(ISalesInvoiceService SalesInvoiceService, HttpClient httpClient)
        {
            _salesInvoiceService = SalesInvoiceService;
            _httpClient = httpClient;


        }
        [Route("SalesInvoice")]
        [HttpGet()]
        public async Task<ActionResult> GetAllSalesInvoices()
        {
            var SalesInvoices = _salesInvoiceService.GetAllSalesInvoices();
            return Ok(SalesInvoices);

        }
        // dossierById 
        [HttpGet(("{saleId}"))]
        public async Task<ActionResult> GetSaleInvoiceById(Guid saleId)
        {
            var SaleInvoice = _salesInvoiceService.GetSalesInvoicesById(saleId);
            return Ok(SaleInvoice);

        }


    }
}
