using System;
using System.Collections.Generic;

namespace TestApp2.Models
{
    public class VolunteerViewModel
    {
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public Uri PhotoReference { get; set; }

        public bool NonSpecificArea { get; set; }

        public IList<string> MainVolunteerAreas { get; set; }

        public IList<string> Interests { get; set; }

        public IList<string> Skills { get; set; }

        public bool Volunteered { get; set; }

        public string VolunteerExperience { get; set; }

        public string VolunteerExperienceDescription { get; set; }
    }
}
