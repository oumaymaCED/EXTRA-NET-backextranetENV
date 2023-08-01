using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Business.Layer.Services.Contracts;
using DataAccess.Layer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using MongoDB.Driver.Core.Configuration;
using Business.Layer.DTO;
using AutoMapper;
using System.Net.Http;
using Newtonsoft.Json;

namespace API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]


    public class DossierController : ControllerBase
    {
        private readonly IDossierService _dossierService;
        private readonly HttpClient _httpClient;


        public DossierController(IDossierService dossierService, HttpClient httpClient)
        {
            _dossierService = dossierService;
            _httpClient = httpClient;


        }
        [Route("Dossier")]
        [HttpGet()]
        public async Task<ActionResult> GetAllDossiers()
        {
            var dossiers = _dossierService.GetAllDossiers();
            return Ok(dossiers);

        }
        // dossierById
        [HttpGet(("{dosId}"))]
        public async Task<ActionResult> GetDossierById(Guid dosId)
        {
            var dossiers = _dossierService.GetDossierById(dosId);
            return Ok(dossiers);

        }

        // [Route("DossierGeneral")]
        [HttpGet("DossierGeneral")]
        public async Task<ActionResult> GetDossierGeneral()
        {
            var dossierGeneral = _dossierService.GetDossierGeneral();
            return Ok(dossierGeneral);
        }

        [HttpGet("DossierDetails")]
          public async Task<ActionResult> GetDossierDetails()
         {
             var dossierDetails = _dossierService.GetDossierDetails();
             return Ok(dossierDetails);
         }

        [HttpGet("workingOrder")]
        public async Task<ActionResult> GetWorkingOrder()
        {
            var workinOrder = _dossierService.GetWorkingOrder();
            return Ok(workinOrder);
        }

        [HttpGet("Service")]
        public async Task<ActionResult> GetServiceByWorkingorderCost()
        {
            var serviceCost = _dossierService.GetServiceByWorkingorderCost();
            return Ok(serviceCost);
        }

    }
}
        
 
