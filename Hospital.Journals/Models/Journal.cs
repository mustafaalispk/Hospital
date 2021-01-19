using System.Collections.Generic;

namespace Hospital.Journals.Models
{
    public class Journal
    {
        public int Id { get; set; }        
        public string SocialSecurityNumber { get; set; }
        public IList<JournalEntry> Entries { get; set; }
    }
}
