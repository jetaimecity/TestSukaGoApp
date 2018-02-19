using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp2.Models
{
    public class EventViewModel
    {
        // add an id
        public string Name { get; set; }

        public IList<EventOption> EventOptions{ get; set; }

        public IList<string> Location { get; set; }

        public Uri FacebookEventLink { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonNumber { get; set; }

        public string Objective { get; set; }

        public string Tasks { get; set; }

        public string Category { get; set; }
    }

    public class EventOption
    {
        public EventOption(DateTime date, string location)
        {
            this.EventDateTime = date;
            this.Location = location;
        }

        public DateTime EventDateTime { get; set; }

        public string Location { get; set; }
    }
}
