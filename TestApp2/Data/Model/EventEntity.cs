using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp2.Data.Model
{
    public class EventEntity : TableEntity
    {
        private string PartitionKeyName = "Events";
        public EventEntity(string id)
        {
            this.PartitionKey = PartitionKeyName;
            this.RowKey = id;
        }

        public EventEntity() { }

        public string Title { get; set; }

        public string ImpactDescription { get; set; }

        public string Category { get; set; }

        public string RequirementsDescription { get; set; }

        public string Frequency { get; set; }

        public string EventOptions{ get; set; }

        public List<string> Locations { get; set; }

        public Uri PhotoReference { get; set; }
    }
}
