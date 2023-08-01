using DataAccess.Layer.Models;
using DataAccess.Layer.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace DataAccess.Layer.Repositories
{
    public struct Dossiers
    {
        public Guid? Id;
        public Dossier Dos;
    }
   
    public class DossierRepository: IDossierRepository
    {
        private readonly HttpClient _httpClient;
        private readonly DossierRepository _dossierRepository;


        public DossierRepository(HttpClient httpClient )
        {
             _httpClient = httpClient;
  
        }
        public List<Dossier> GetAllDossiers()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/Dossiers/ALLDossiers?supId=7E4FA0F5-0C6C-40D5-8204-2428DD92492C").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var dossiers = JsonConvert.DeserializeObject<List<DossierInfoGeneral>>(content);
                var dossfinal = new List<Dossier>(); 

                var dossierGroups = dossiers.GroupBy(d => d.DosId).ToList();

                var dossierInfoGeneral = dossierGroups.Select(group => new Dossier

                {
                    DosId = group.Key,
                    DosDossierNumber = group.FirstOrDefault().DosDossierNumber,
                    DosStatusLongName = group.FirstOrDefault().DosStatusLongName,
                    DosIntakeDate = group.FirstOrDefault().DosIntakeDate,
                    DosIncidentDate = group.FirstOrDefault().DosIncidentDate,
                    DosCreatedDate = group.FirstOrDefault().DosCreatedDate,
                    DosIncidentCountryId = group.FirstOrDefault().DosIncidentCountryId,
                    workingOrder = GetworkingOrderList(group.ToList())
                });
                
                return dossierInfoGeneral.ToList();
            }

                throw new Exception($"Unable to retrieve dossiers. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
            
        }
    private List<WorkingOrder> GetworkingOrderList(List<DossierInfoGeneral> d)
    {
        var workingorderlist = new List<WorkingOrder>();
        var m = d.GroupBy(c => c.WoWorkingOrderNumber);

        foreach (var group in m)
        {
            WorkingOrder wo = new WorkingOrder();
            wo.WoWorkingOrderNumber = group.Key;
                //group.FirstOrDefault().WoWorkingOrderNumber;

            var cost = group.GroupBy(x => x.idworkingOrder);
            List<workingorderCost> workingordercostlist = new List<workingorderCost>();

            foreach (var c in cost)
            {
                workingorderCost tt = new workingorderCost();
                tt.GrossAmount = c.FirstOrDefault().GrossAmount;
                tt.NetAmount = c.FirstOrDefault().NetAmount;
                tt.Discount = c.FirstOrDefault().Discount;
                tt.TaxAmount = c.FirstOrDefault().TaxAmount;
                tt.TaxRate = c.FirstOrDefault().TaxRate;
                tt.Quantity = c.FirstOrDefault().Quantity;
                tt.UnitPrice = c.FirstOrDefault().UnitPrice;


                tt.Services = new ServiceByWorkingorderCost();
                    tt.Services.ServiceID = c.FirstOrDefault().ServiceID;
                    tt.Services.ServiceShortName = c.FirstOrDefault().ServiceShortName;
                    tt.Services.ServiceLongName = c.FirstOrDefault().ServiceLongName;
                    tt.Services.ServiceCode = c.FirstOrDefault().ServiceCode;
                    
                workingordercostlist.Add(tt);
                   
            }
                wo.workingorderCosts = workingordercostlist;
                workingorderlist.Add(wo);
        }
        return workingorderlist;
       
      }

        public List<DossierInfoGeneral> GetDossierGeneral()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/Dossiers/ALLDossiers?supId=7E4FA0F5-0C6C-40D5-8204-2428DD92492C").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var dossierInfoGeneral = JsonConvert.DeserializeObject<List<DossierInfoGeneral>>(content);
                return dossierInfoGeneral;
            }

            throw new Exception($"Unable to retrieve dossier info details. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
        }

        public List<DossierInfoDetails> GetDossierDetails()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/Dossiers/ALLDossiers?supId=7E4FA0F5-0C6C-40D5-8204-2428DD92492C").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var dossierInfoDetails = JsonConvert.DeserializeObject<List<DossierInfoDetails>>(content);
                return dossierInfoDetails;
            }

            throw new Exception($"Unable to retrieve dossier info details. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
        }

        public List<WorkingOrder> GetWorkingOrder()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/Dossiers/ALLDossiers?supId=7E4FA0F5-0C6C-40D5-8204-2428DD92492C").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var workingOrder = JsonConvert.DeserializeObject<List<WorkingOrder>>(content);
                return workingOrder;
            }

            throw new Exception($"Unable to retrieve dossier info details. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
        }

        public List<ServiceByWorkingorderCost> GetServiceByWorkingorderCost()
        {
            var response = _httpClient.GetAsync("https://localhost:7077/api/Dossiers/ALLDossiers?supId=7E4FA0F5-0C6C-40D5-8204-2428DD92492C").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var ServiceCost = JsonConvert.DeserializeObject<List<ServiceByWorkingorderCost>>(content);
                return ServiceCost;
            }

            throw new Exception($"Unable to retrieve dossier info details. Status code: {response.StatusCode}. Error message: {response.ReasonPhrase}");
        }
    }

    
    
}
