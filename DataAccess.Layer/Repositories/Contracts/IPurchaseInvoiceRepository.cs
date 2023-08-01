using DataAccess.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Repositories.Contracts
{
    public interface IPurchaseInvoiceRepository
    {

        //GetPI
        public string GetAll();
        //GetPIByDossier
        public string GetByDossierNumber(string dossierNumber);
        //GetPIbyNumberPI
        public string GetByNumber(string invoiceNumber);
        //CreationPI
        void Create(PurchaseInvoice purchaseInvoice);
        //UpdatePI
        void Update(PurchaseInvoice purchaseInvoice);
        //Check the Existence of the line 
        public bool GetIsTakenByServiceID(string dossierNumber, string serviceID);


    }
}
