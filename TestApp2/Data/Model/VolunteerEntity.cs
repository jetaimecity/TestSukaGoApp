using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace TestApp2.Data.Model
{
    public class VolunteerEntity : TableEntity
    {
        private string PartitionKeyName = "Organizations";
        public VolunteerEntity(string id)
        {
            this.PartitionKey = PartitionKeyName;
            this.RowKey = id;
        }

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
