using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Models
{
    public class dossierTransfert
    {
        [Key]
        public Guid? DosId { get; set; }
        public string? DosDossierNumber { get; set; }

        //public byte[] DosTimeStamp { get; set; } = null!;
        //public Guid DosClientId { get; set; }
        //public Guid? DosMandateId { get; set; }
        //public Guid? DosAgentId { get; set; }
        //public Guid? DosContactPersonId { get; set; }
        // public Guid DosProductId { get; set; }
        // public Guid? DosEmployeeId { get; set; }
        //public Guid? DosTenantId { get; set; }
        //public short? DosDossierTypeId { get; set; }
        //public string? DosEntrySystem { get; set; }
        //public string? DosEntryNumber { get; set; }
        //public string? DosEntryBatch { get; set; }
        // public Guid? DosLegalEntityId { get; set; }
        // public Guid? DosDepartmentId { get; set; }
        //public Guid? DosCurrentStatusHistoryId { get; set; }
        //public DateTime? DosCurrentStatusHistoryStartDate { get; set; }

        //TABLE PRODUCT

        //public string? ProductCode { get; set; }
        // public string? ProductName { get; set; }

        //workingOrder
        public string? WoWorkingOrderNumber { get; set; }

        //WORKINGOrderCost
        public decimal? NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }



        //TABLE  Service
        public Guid ServiceID { get; set; }

        public string? ServiceCode { get; set; }

        public string? ServiceShortName { get; set; }

        public string? ServiceLongName { get; set; }




        //TABLE DOSSIER

        public string? DosCurrentStatusCode { get; set; }

        //public Guid? DosDossierPriorityId { get; set; }
        //public Guid? DosReporterId { get; set; }

        public DateTime? DosIntakeDate { get; set; }

        public DateTime? DosIncidentDate { get; set; }

        //public Guid? DosReasonId { get; set; }
        //public Guid? DosCauseId { get; set; }
        //public Guid? DosMainReasonId { get; set; }
        //public Guid? DosSubReasonId { get; set; }


        public DateTime DosCreatedDate { get; set; }

        // public string? DosCreatedBy { get; set; }
        // public DateTime DosLastModifiedDate { get; set; }
        //public string? DosLastModifiedBy { get; set; }

        public string? DosIncidentCountryId { get; set; }
    }
}
