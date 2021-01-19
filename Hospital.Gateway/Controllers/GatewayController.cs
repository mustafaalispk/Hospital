using Hospital.Gateway.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospital.Gateway.Controllers
{
    // /api/patients/{socialSecurityNumber}
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        // GET //19900101-2020
        // [Route("patients")]
        [HttpGet("{socialSecurityNumber}")]
        public async Task<PatientDto> GetPatient(string socialSecurityNumber)
        {
            // TODO: Hämta patient-information från (tex: /patients/19900101-2020)

            var request = new HttpRequestMessage(HttpMethod.Get, "http://hospital.patients/patients/" + socialSecurityNumber);

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

            request = new HttpRequestMessage(HttpMethod.Get, "http://hospital.journals/journals/" + socialSecurityNumber);

            request.Headers.Add("Accept", "application/json");

            response = await client.SendAsync(request);

            var serializedJournal = await response.Content.ReadAsStringAsync();

            var journalDto = JsonSerializer.Deserialize<JournalDto>(serializedJournal, serializedOptions);

            // Aggregera information - bygg ihopp och returnera

            patientDto.Journal = journalDto.Entries.ToList();                      

            return patientDto;

            
        }
    }
}
