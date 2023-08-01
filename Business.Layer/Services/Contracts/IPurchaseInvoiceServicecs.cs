using DataAccess.Layer.Models;
using Business.Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services.Contracts
{
    public interface IPurchaseInvoiceServicecs
    {
       string GetAllPurchaseInvoices();

        string GetPurchaseInvoiceByNumber(string invoiceNumber);
        string GetByDossierNumber(string dossierNumber);


        void CreatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoice);

        void UpdatePurchaseInvoice(PurchaseInvoice purchaseInvoice);
        // check the exixtence of the line

        public bool GetIsTakenByServiceID(string dossierNumber, string serviceID);


    }
}
