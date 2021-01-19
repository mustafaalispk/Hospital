using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Gateway.Models.DTO
{
    public class JournalEntryDto
    {
        public DateTime Date { get; set; }
        public string EntryBy { get; set; }
        public string Entry { get; set; }
    }
}
