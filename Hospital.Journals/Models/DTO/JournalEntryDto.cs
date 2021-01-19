using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Journals.Models.DTO
{
    public class JournalEntryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string EntryBy { get; set; }
        public string Entry { get; set; }
    }
}
