using Hospital.Journals.Models;
using Hospital.Journals.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Journals.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalsController : ControllerBase
    {
        private static readonly List<Journal> Journals = new List<Journal>
        {
            new Journal
            {
                Id = 1,
                SocialSecurityNumber = "19900101-2020",
                Entries = new List<JournalEntry>
                {
                    new JournalEntry
                    {
                        Id = 1,
                        Date = new DateTime(2020,12,20,12,15,0),
                        EntryBy = "Dr. Jane Doe",
                        Entry = "Patient suffers from serious headaches"

                    },
                       new JournalEntry
                    {
                        Id = 2,
                        Date = new DateTime(2021,1,2,8,20,0),
                        EntryBy = "Dr. Jane Doe",
                        Entry = "Patient received COVID-19 vaccine"

                    }
                }
            }
        };        

        [HttpGet("{socialSecurityNumber}")]
        public ActionResult<JournalDto> GetJournal(string socialSecurityNumber)
        {
            var foundJournal = Journals
                .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (foundJournal is null)
            {
                return NotFound(); // 404 Not Found
            }

            var dto = new JournalDto
            {
                Id = foundJournal.Id,
                SocialSecurityNumber = foundJournal.SocialSecurityNumber,
                Entries = foundJournal.Entries.Select(x => new JournalEntryDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    EntryBy = x.EntryBy,
                    Entry = x.Entry

                })
            };
            return dto; 
        }
    }
}
