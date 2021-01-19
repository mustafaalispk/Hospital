using Hospital.Patients.Models.Domains;
using Hospital.Patients.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Patients.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private static readonly List<Patient> Patients = new List<Patient>
        {
           new Patient
            (
               id: 1,
               firstName: "John",
               lastName: "Doe",
               socialSecurityNumber: "19900101-2020")
           
        };
       

        //GET /patients/19800101-1010
        [HttpGet("{socialSecurityNumber}")]
        public ActionResult<PatientDto> GetPatient(string socialSecurityNumber)
        {
            var foundPatients = Patients
                .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (foundPatients is null)
            {
                return NotFound(); // 404 Not Found
            }

            var dto = new PatientDto
            {
                Id = foundPatients.Id,
                FirstName = foundPatients.FirstName,
                LastName = foundPatients.LastName,
                SocialSecurityNumber = foundPatients.SocialSecurityNumber

            };              
            
            return dto;
        }
    }
}
