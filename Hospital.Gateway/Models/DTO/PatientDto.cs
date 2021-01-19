using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Gateway.Models.DTO
{
    public class PatientDto
    {
        public string SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<JournalEntryDto> Journal { get; set; }
    }
}
