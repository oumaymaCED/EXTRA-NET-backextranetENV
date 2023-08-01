using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Services.Contracts;
using DataAccess.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Layer;
using System.Xml;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseInvoiceController : ControllerBase
    {
        private readonly IPurchaseInvoiceServicecs _purchaseInvoiceService;


        public PurchaseInvoiceController(IPurchaseInvoiceServicecs purchaseInvoiceService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseInvoice>> GetAllPurchaseInvoices()
        {
            var purchaseInvoices = _purchaseInvoiceService.GetAllPurchaseInvoices();
            return Ok(purchaseInvoices);
        }

        [HttpGet("{invoiceNumber}")]
        public ActionResult<PurchaseInvoice> GetPurchaseInvoiceByNumber(string invoiceNumber)
        {
            var purchaseInvoice = _purchaseInvoiceService.GetPurchaseInvoiceByNumber(invoiceNumber);

            if (purchaseInvoice == null)
            {
                return NotFound();
            }

            return Ok(purchaseInvoice);
        }

        [HttpGet("dossier/{dossierNumber}")]
        public ActionResult<List<PurchaseInvoice>> GetPurchaseInvoicesByDossierNumber(string dossierNumber)
        {
            var purchaseInvoices = _purchaseInvoiceService.GetByDossierNumber(dossierNumber);

            if (purchaseInvoices == null)
            {
                return NotFound();
            }

            return Ok(purchaseInvoices);
        }


        [HttpPost("CreatePurchaseInvoice")]
        public IActionResult CreatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoice)
        {
            _purchaseInvoiceService.CreatePurchaseInvoice(purchaseInvoice);

            return CreatedAtAction(nameof(GetPurchaseInvoiceByNumber), new { invoiceNumber = purchaseInvoice.PurchaseInvoiceNumber }, purchaseInvoice);
        }

        [HttpPut("{invoiceNumber}")]
        public IActionResult UpdatePurchaseInvoice(string invoiceNumber, PurchaseInvoice purchaseInvoice)
        {
            var existingPurchaseInvoice = _purchaseInvoiceService.GetPurchaseInvoiceByNumber(invoiceNumber);

            if (existingPurchaseInvoice == null)
            {
                return NotFound();
            }

            purchaseInvoice.PurchaseInvoiceNumber = invoiceNumber;
            _purchaseInvoiceService.UpdatePurchaseInvoice(purchaseInvoice);

            return NoContent();
        }

        [HttpGet("istaken/{dossierNumber}/{serviceID}")]
        public IActionResult IsServiceTaken(string dossierNumber, string serviceID)
        {
            bool isTaken = _purchaseInvoiceService.GetIsTakenByServiceID(dossierNumber, serviceID);

            return Ok(isTaken);
        }


        /////
        [HttpPost("send")]
        public IActionResult SendPurchaseInvoice(PurchaseInvoice purchaseInvoice)
        {
            // Générez le XML à partir de l'objet purchaseInvoice
            var xmlDoc = new XmlDocument();
            var rootElement = xmlDoc.CreateElement("PurchaseInvoice");

            var purchaseInvoiceNumberElement = xmlDoc.CreateElement("PurchaseInvoiceNumber");
            purchaseInvoiceNumberElement.InnerText = purchaseInvoice.PurchaseInvoiceNumber;
            rootElement.AppendChild(purchaseInvoiceNumberElement);

            var dossierNumberElement = xmlDoc.CreateElement("DossierNumber");
            dossierNumberElement.InnerText = purchaseInvoice.DossierNumber;
            rootElement.AppendChild(dossierNumberElement);

            var invoiceDateElement = xmlDoc.CreateElement("InvoiceDate");
            invoiceDateElement.InnerText = purchaseInvoice.InvoiceDate.ToString("yyyy-MM-ddTHH:mm:ss");
            rootElement.AppendChild(invoiceDateElement);

            var TotalGrossAmountElement = xmlDoc.CreateElement("TotalGrossAmount");
            TotalGrossAmountElement.InnerText = purchaseInvoice.TotalGrossAmount.ToString();
            rootElement.AppendChild(TotalGrossAmountElement);

            var TotalTaxAmountElement = xmlDoc.CreateElement("TotalTaxAmount");
            TotalTaxAmountElement.InnerText = purchaseInvoice.TotalTaxAmount.ToString();
            rootElement.AppendChild(TotalTaxAmountElement);

            var TotalNetAmountElement = xmlDoc.CreateElement("TotalNetAmount");
            TotalNetAmountElement.InnerText = purchaseInvoice.TotalNetAmount.ToString();
            rootElement.AppendChild(TotalNetAmountElement);

            var TotalDiscountElement = xmlDoc.CreateElement("TotalDiscount");
            TotalDiscountElement.InnerText = purchaseInvoice.TotalDiscount.ToString();
            rootElement.AppendChild(TotalDiscountElement);


            // Ajoutez les autres éléments de la facture d'achat
            // ...

            var purchaseInvoiceLinesElement = xmlDoc.CreateElement("PurchaseInvoiceLines");

            foreach (var line in purchaseInvoice.PurchaseInvoiceLines)
            {
                var lineElement = xmlDoc.CreateElement("PurchaseInvoiceLine");

                var purchaseInvoiceLineIdElement = xmlDoc.CreateElement("PurchaseInvoiceLineId");
                purchaseInvoiceLineIdElement.InnerText = line.PurchaseInvoiceLineId.ToString();
                lineElement.AppendChild(purchaseInvoiceLineIdElement);

                var workingOrdernumberElement = xmlDoc.CreateElement("WorkingOrdernumber");
                workingOrdernumberElement.InnerText = line.WorkingOrdernumber;
                lineElement.AppendChild(workingOrdernumberElement);

                var netAmountElement = xmlDoc.CreateElement("NetAmount");
                netAmountElement.InnerText = line.NetAmount.ToString();
                lineElement.AppendChild(netAmountElement);

                var TaxAmountElement = xmlDoc.CreateElement("TaxAmount");
                TaxAmountElement.InnerText = line.TaxAmount.ToString();
                lineElement.AppendChild(TaxAmountElement);

                var GrossAmountElement = xmlDoc.CreateElement("GrossAmount");
                GrossAmountElement.InnerText = line.GrossAmount.ToString();
                lineElement.AppendChild(GrossAmountElement);

                var QuantityElement = xmlDoc.CreateElement("Quantity");
                QuantityElement.InnerText = line.Quantity.ToString();
                lineElement.AppendChild(QuantityElement);

                var TaxRateElement = xmlDoc.CreateElement("TaxRate");
                TaxRateElement.InnerText = line.TaxRate.ToString();
                lineElement.AppendChild(QuantityElement);

                var UnitPriceElement = xmlDoc.CreateElement("UnitPrice");
                UnitPriceElement.InnerText = line.UnitPrice.ToString();
                lineElement.AppendChild(UnitPriceElement);

                var DiscountElement = xmlDoc.CreateElement("Discount");
                DiscountElement.InnerText = line.Discount;
                lineElement.AppendChild(DiscountElement);


                // Ajoutez ici les autres éléments de la ligne de facture d'achat

                purchaseInvoiceLinesElement.AppendChild(lineElement);
            }

            rootElement.AppendChild(purchaseInvoiceLinesElement);
            xmlDoc.AppendChild(rootElement);

            // Enregistrez le XML dans un emplacement souhaité
            //string filePath = "C:\\Users\\oumayma.khemissi\\Desktop\\XML";
            //xmlDoc.Save(filePath);
            //
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "XMLFiles", "fichier.xml");
            xmlDoc.Save(filePath);

            return Ok(filePath); // Ou toute autre réponse appropriée
        }

    

        





    }
}
