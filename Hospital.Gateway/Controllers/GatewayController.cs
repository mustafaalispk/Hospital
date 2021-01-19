using Hospital.Gateway.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospital.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
         }
        // /patient/19900101-2020
        [HttpGet]
        public async Task<PatientDto> GetPatient(string socialSecurityNumber)
        {
            // TODO: Hämta patient-information från (tex: /patients/19900101-2020)

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60154/patients/" + socialSecurityNumber);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedPatient = await response.Content.ReadAsStringAsync();

            var serializedOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var patientDto = JsonSerializer.Deserialize<PatientDto>(serializedPatient, serializedOptions);


            // TODO: Hämta journal-information för patient (tex: /journal/19900101-2020

            // Aggregera information - bygg ihopp och returnera

            return new PatientDto();

            
        }
    }
}
