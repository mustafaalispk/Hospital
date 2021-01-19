using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Gateway.Models.DTO
{
    public class JournalDto
    {
        public int Id { get; set; }
        public string SocialSecurityNumber { get; set; }
        public IEnumerable<JournalEntryDto> Entries { get; set; }
    }
}
