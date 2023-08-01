using DataAccess.Layer.Models;
using Business.Layer.Services.Contracts;
using DataAccess.Layer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Layer.DTO;
using AutoMapper;
using DataAccess.Layer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Layer.Services
{
    public class purchaseInvoiceService : IPurchaseInvoiceServicecs
    {
        private readonly IPurchaseInvoiceRepository _purchaseInvoiceRepository;
        private readonly IMapper _mapper;



        public purchaseInvoiceService(IPurchaseInvoiceRepository purchaseInvoiceRepository, IMapper mapper)
        {
            _purchaseInvoiceRepository = purchaseInvoiceRepository;
            _mapper = mapper;

        }

        public string GetAllPurchaseInvoices()
        {
            return _purchaseInvoiceRepository.GetAll();
        }

        public string GetPurchaseInvoiceByNumber(string invoiceNumber)
        {
            return _purchaseInvoiceRepository.GetByNumber(invoiceNumber);
        }
        // l'ancienne méthode qui fonctionne 
        /* public void CreatePurchaseInvoice(PurchaseInvoice purchaseInvoice)
         {

               _purchaseInvoiceRepository.Create(purchaseInvoice);
         }*/

        /*  public void CreatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO)
          {
              var purchaseInvoice = _mapper.Map<PurchaseInvoice>(purchaseInvoiceDTO);

              purchaseInvoice.PurchaseInvoiceLines = _mapper.Map<List<PurchaseInvoiceLine>>(purchaseInvoiceDTO.PurchaseInvoiceLines);

              _purchaseInvoiceRepository.Create(purchaseInvoice);
          } */


        // pour  chaque purchase pardossiernumber !!
        public string GetByDossierNumber(string dossierNumber)
        {
            return _purchaseInvoiceRepository.GetByDossierNumber(dossierNumber);
        }


        public void CreatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO)
        {
            var purchaseInvoice = _mapper.Map<PurchaseInvoice>(purchaseInvoiceDTO);

            // Créez une nouvelle liste pour stocker les lignes de facture d'achat
            var purchaseInvoiceLines = new List<PurchaseInvoiceLine>();

            // Ajoutez les lignes de facture d'achat à la liste
            foreach (var lineDTO in purchaseInvoiceDTO.PurchaseInvoiceLines)
            {
                var line = _mapper.Map<PurchaseInvoiceLine>(lineDTO);
                purchaseInvoiceLines.Add(line);
            }

            // Associez la liste de lignes à l'entité PurchaseInvoice
            purchaseInvoice.PurchaseInvoiceLines = purchaseInvoiceLines;

            _purchaseInvoiceRepository.Create(purchaseInvoice);
        }







        public void UpdatePurchaseInvoice(PurchaseInvoice purchaseInvoice)
        {
            _purchaseInvoiceRepository.Update(purchaseInvoice);
        }

        //check the exixtence of the line 
        public bool GetIsTakenByServiceID(string dossierNumber, string serviceID)
        {
            return _purchaseInvoiceRepository.GetIsTakenByServiceID(dossierNumber, serviceID);
        }


    }
}
