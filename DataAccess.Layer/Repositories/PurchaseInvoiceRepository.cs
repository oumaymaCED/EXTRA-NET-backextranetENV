using DataAccess.Layer.Models;
using DataAccess.Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.Text.Json;

namespace DataAccess.Layer.Repositories
{
    public class PurchaseInvoiceRepository : IPurchaseInvoiceRepository
    {
        private readonly NewRepairDbContext _dbContext;
        public PurchaseInvoiceRepository(NewRepairDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public string GetAll()
        {
            var purchaseInvoices = _dbContext.PurchaseInvoices
                .Include(pi => pi.PurchaseInvoiceLines)
                .ToList();

            var result = new List<object>();
            foreach (var invoice in purchaseInvoices)
            {
                var invoiceObj = new
                {
                    PurchaseInvoiceNumber = invoice.PurchaseInvoiceNumber,
                    DossierNumber = invoice.DossierNumber,
                    InvoiceDate = invoice.InvoiceDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    TotalGrossAmount = invoice.TotalGrossAmount,
                    TotalTaxAmount = invoice.TotalTaxAmount,
                    TotalNetAmount = invoice.TotalNetAmount,
                    TotalDiscount = invoice.TotalDiscount,
                    PurchaseInvoiceLines = invoice.PurchaseInvoiceLines
                        .Select(line => new
                        {
                            PurchaseInvoiceLineId = line.PurchaseInvoiceLineId,
                            WorkingOrdernumber = line.WorkingOrdernumber,
                            ServiceID = line.ServiceID,
                            NetAmount = line.NetAmount,
                            TaxAmount = line.TaxAmount,
                            GrossAmount = line.GrossAmount,
                            Quantity = line.Quantity,
                            TaxRate = line.TaxRate,
                            UnitPrice = line.UnitPrice,
                            Discount = line.Discount,
                            IsTaken = line.IsTaken

                        })
                        .ToList()
                };

                result.Add(invoiceObj);
            }

            var json = new
            {
                result
            };

            return JsonSerializer.Serialize(json);
        }



        public string GetByNumber(string invoiceNumber)
        {
            var purchaseInvoice = _dbContext.PurchaseInvoices
         .Include(pi => pi.PurchaseInvoiceLines)
         .FirstOrDefault(pi => pi.PurchaseInvoiceNumber == invoiceNumber);

            if (purchaseInvoice == null)
            {
                return string.Empty; // Ou une autre indication d'erreur si nécessaire
            }

            var invoiceObj = new
            {
                PurchaseInvoiceNumber = purchaseInvoice.PurchaseInvoiceNumber,
                DossierNumber = purchaseInvoice.DossierNumber,
                InvoiceDate = purchaseInvoice.InvoiceDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                TotalGrossAmount = purchaseInvoice.TotalGrossAmount,
                TotalTaxAmount = purchaseInvoice.TotalTaxAmount,
                TotalNetAmount = purchaseInvoice.TotalNetAmount,
                TotalDiscount = purchaseInvoice.TotalDiscount,
                PurchaseInvoiceLines = purchaseInvoice.PurchaseInvoiceLines
                    .Select(line => new
                    {
                        PurchaseInvoiceLineId = line.PurchaseInvoiceLineId,
                        WorkingOrdernumber = line.WorkingOrdernumber,
                        ServiceID = line.ServiceID,
                        NetAmount = line.NetAmount,
                        TaxAmount = line.TaxAmount,
                        GrossAmount = line.GrossAmount,
                        Quantity = line.Quantity,
                        TaxRate = line.TaxRate,
                        UnitPrice = line.UnitPrice,
                        Discount = line.Discount,
                        IsTaken = line.IsTaken

                    })
                    .ToList()
            };

            var json = new
            {
                result = invoiceObj
            };

            return JsonSerializer.Serialize(json);
        }

        // Récupérer les Purchase Invoices de dossier !!
        public string GetByDossierNumber(string dossierNumber)
        {
            var purchaseInvoices = _dbContext.PurchaseInvoices
                .Include(pi => pi.PurchaseInvoiceLines)
                .Where(pi => pi.DossierNumber == dossierNumber)
                .ToList();

            var result = purchaseInvoices.Select(invoice => new
            {
                PurchaseInvoiceNumber = invoice.PurchaseInvoiceNumber,
                DossierNumber = invoice.DossierNumber,
                InvoiceDate = invoice.InvoiceDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                TotalGrossAmount = invoice.TotalGrossAmount,
                TotalTaxAmount = invoice.TotalTaxAmount,
                TotalNetAmount = invoice.TotalNetAmount,
                TotalDiscount = invoice.TotalDiscount,
                PurchaseInvoiceLines = invoice.PurchaseInvoiceLines
                    .Select(line => new
                    {
                        PurchaseInvoiceLineId = line.PurchaseInvoiceLineId,
                        WorkingOrdernumber = line.WorkingOrdernumber,
                        ServiceID=line.ServiceID,
                        NetAmount = line.NetAmount,
                        TaxAmount = line.TaxAmount,
                        GrossAmount = line.GrossAmount,
                        Quantity = line.Quantity,
                        TaxRate = line.TaxRate,
                        UnitPrice = line.UnitPrice,
                        Discount = line.Discount,
                        IsTaken  = line.IsTaken

    })
                    .ToList()
            }).ToList();

            var json = new
            {
                result
            };

            return JsonSerializer.Serialize(json);
        }



        //Creation of Purchase Invoice
        public void Create(PurchaseInvoice purchaseInvoice)
        {
            _dbContext.PurchaseInvoices.Add(purchaseInvoice);
            _dbContext.SaveChanges();
        }

        // Update of PurchaseInvoice
        public void Update(PurchaseInvoice purchaseInvoice)
        {
            var existingPurchaseInvoice = _dbContext.PurchaseInvoices
                .Include(pi => pi.PurchaseInvoiceLines)
                .FirstOrDefault(pi => pi.PurchaseInvoiceNumber == purchaseInvoice.PurchaseInvoiceNumber);

            if (existingPurchaseInvoice != null)
            {
                // Exclude the 'PurchaseInvoiceNumber' property from being updated
                _dbContext.Entry(existingPurchaseInvoice).Property(pi => pi.PurchaseInvoiceNumber).IsModified = false;

                // Update the scalar properties of the PurchaseInvoice entity
                existingPurchaseInvoice.TotalGrossAmount = purchaseInvoice.TotalGrossAmount;
                existingPurchaseInvoice.TotalTaxAmount = purchaseInvoice.TotalTaxAmount;
                existingPurchaseInvoice.TotalNetAmount = purchaseInvoice.TotalNetAmount;
                existingPurchaseInvoice.TotalDiscount = purchaseInvoice.TotalDiscount;

                // Create a list to track the lines to be removed
                var linesToRemove = new List<PurchaseInvoiceLine>();

                // Update or add the PurchaseInvoiceLines that are in the updated entity
                foreach (var existingLine in existingPurchaseInvoice.PurchaseInvoiceLines.ToList())
                {
                    var updatedLine = purchaseInvoice.PurchaseInvoiceLines
                        .FirstOrDefault(l => l.PurchaseInvoiceLineId == existingLine.PurchaseInvoiceLineId);

                    if (updatedLine != null)
                    {
                        // Update the scalar properties of the PurchaseInvoiceLine entity
                        existingLine.NetAmount = updatedLine.NetAmount;
                        existingLine.TaxAmount = updatedLine.TaxAmount;
                        existingLine.GrossAmount = updatedLine.GrossAmount;
                        existingLine.Quantity = updatedLine.Quantity;
                        existingLine.TaxRate = updatedLine.TaxRate;
                        existingLine.UnitPrice = updatedLine.UnitPrice;
                        existingLine.Discount = updatedLine.Discount;
                    }
                    else
                    {
                        // Mark the line for removal
                        linesToRemove.Add(existingLine);
                    }
                }

                // Remove the lines that are not present in the updated entity
                foreach (var lineToRemove in linesToRemove)
                {
                    lineToRemove.PurchaseInvoiceNumber = existingPurchaseInvoice.PurchaseInvoiceNumber;
                    // for the purchaseInvoiceNumber Existing
                    _dbContext.Entry(lineToRemove).State = EntityState.Deleted;
                    existingPurchaseInvoice.PurchaseInvoiceLines.Remove(lineToRemove);
                }

                _dbContext.SaveChanges();
            }
        }



        ////// to check Line

        public bool GetIsTakenByServiceID(string dossierNumber, string serviceID)
        {
            var purchaseInvoice = _dbContext.PurchaseInvoices
                .Include(pi => pi.PurchaseInvoiceLines)
                .FirstOrDefault(pi => pi.DossierNumber == dossierNumber &&
                                     pi.PurchaseInvoiceLines.Any(line => line.ServiceID == serviceID));

            if (purchaseInvoice != null)
            {
                var purchaseInvoiceLine = purchaseInvoice.PurchaseInvoiceLines
                    .FirstOrDefault(line => line.ServiceID == serviceID);

                if (purchaseInvoiceLine != null)
                {
                    return true; // Retourne true si la ligne correspondante existe, indépendamment de la valeur de IsTaken
                }
            }

            return false; // Aucun PurchaseInvoice ou PurchaseInvoiceLine correspondant n'est trouvé
        }







    }


}
