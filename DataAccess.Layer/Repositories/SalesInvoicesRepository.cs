using DataAccess.Layer.Models;
using DataAccess.Layer.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Repositories
{
    public class SalesInvoicesRepository : IsalesInvoiceRepository
    {
        private readonly HttpClient _httpClient;
        private readonly DossierRepository _dossierRepository;


        public SalesInvoicesRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public List<SalesInvoices> GetAllSalesInvoices()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/SalesInvoices/ALLSalesInvoices?ClientID=472F8839-1104-47D9-8D45-0424B47D897F").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var salesInvoicesGeneralList = JsonConvert.DeserializeObject<List<SalesInvoicesGeneral>>(content);

                var salesInvoiceGroups = salesInvoicesGeneralList.GroupBy(d => d.SalesId).ToList();
                var salesInvoicesList = new List<SalesInvoices>();

                foreach (var group in salesInvoiceGroups)
                {
                    var salesInvoices = new SalesInvoices
                    {
                        SalesId = group.Key,
                        SalesNumber = group.FirstOrDefault().SalesNumber,
                        SalesIDate = group.FirstOrDefault().SalesIDate,
                        SalesTotalGrossAmount = group.FirstOrDefault().SalesTotalGrossAmount,
                        SalesTotalTaxAmount = group.FirstOrDefault().SalesTotalTaxAmount,
                        SalesTotalNetAmount = group.FirstOrDefault().SalesTotalNetAmount,
                        SalesDossierNumber = group.FirstOrDefault().SalesDossierNumber,
                        StatusCode = group.FirstOrDefault().StatusCode,
                        StatusName = group.FirstOrDefault().StatusName,
                        SalesInvoiceLines = GetSalesInvoiceLines(salesInvoicesGeneralList, group.Key)
                    };

                    salesInvoicesList.Add(salesInvoices);
                }

                return salesInvoicesList;
            }

            throw new Exception($"Unable to retrieve sales invoices. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
        }

        private List<SalesInvoicesLines> GetSalesInvoiceLines(List<SalesInvoicesGeneral> salesInvoicesGeneralList, Guid salesId)
        {
            var salesInvoiceLines = new List<SalesInvoicesLines>();

            foreach (var salesInvoicesGeneral in salesInvoicesGeneralList.Where(x => x.SalesId == salesId))
            {
                var salesInvoiceLine = new SalesInvoicesLines
                {
                    SalesInvoiceLineId = salesInvoicesGeneral.SalesInvoiceLineId,
                    UnitPriceLine = salesInvoicesGeneral.UnitPriceLine,
                    QuantityLine = salesInvoicesGeneral.QuantityLine,
                    NetAmountLine = salesInvoicesGeneral.NetAmountLine,
                    TaxRateLine = salesInvoicesGeneral.TaxRateLine,
                    TaxAmountLine = salesInvoicesGeneral.TaxAmountLine,
                    DiscountLine = salesInvoicesGeneral.DiscountLine,
                    GrossAmountLine = salesInvoicesGeneral.GrossAmountLine
                };

                salesInvoiceLines.Add(salesInvoiceLine);
            }

            return salesInvoiceLines;
        }




    }
}
