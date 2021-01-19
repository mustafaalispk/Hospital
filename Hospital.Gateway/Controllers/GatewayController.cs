using Hospital.Gateway.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {      
        // /patient/19900101-2010
        [HttpGet]
        public PatientDto GetPatient(string socialSecurityNumber)
        {
            // TODO: Anropa 
            return null;
        }
    }
}
