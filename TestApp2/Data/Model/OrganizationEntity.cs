using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp2.Data.Model
{
    public class OrganizationEntity : TableEntity
    {
        private string PartitionKeyName = "Organizations";
        public OrganizationEntity(string id)
        {
            this.PartitionKey = PartitionKeyName;
            this.RowKey = id;
        }

        public OrganizationEntity() { }

        public string Name { get; set; }

        public string MissionDescription { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public Uri LogoReference { get; set; }
    }
}
