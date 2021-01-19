using System.Collections.Generic;

namespace Hospital.Journals.Models.DTO
{
    public class JournalDto
    {
        public int Id { get; set; }        
        public string SocialSecurityNumber { get; set; }
        public IEnumerable<JournalEntryDto> Entries { get; set; }
    }
}
