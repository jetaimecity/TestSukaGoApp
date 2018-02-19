using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using TestApp2.Data.Model;
using TestApp2.Models;

namespace TestApp2.Data
{
    public class EventRepository : AzureRepository, IRepository
    {
        private readonly CloudTable table;
        public EventRepository()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=michellesandbox;AccountKey=G8fKyaDRUR4nAd2DXYifItqDRF2SRdtlnbNhNST+GK7sBe5GnV9LwlvffB+0vnNUuQ56Zc42NHaMv9g3wDeaow==;EndpointSuffix=core.windows.net");
            var client = storageAccount.CreateCloudTableClient();
            CloudTable table = client.GetTableReference("Event");
            table.CreateIfNotExistsAsync();
            this.table = table;
        }

        public ITableEntity ConvertModelToEntity(EventViewModel model, string id = null)
        {
            return new EventEntity(id ?? Guid.NewGuid().ToString())
            {
                Title = model.Name,
                ImpactDescription = model.Objective,
                Category = model.Category,
                RequirementsDescription = model.Tasks,
                Frequency = "1",
                EventOptions = JsonConvert.SerializeObject(model.EventOptions),
            };
        }

        public void AddRecord(ITableEntity entity)
        {
            var insertOperation = TableOperation.Insert(entity);
            table.ExecuteAsync(insertOperation);
        }

        public bool DeleteRecord(ITableEntity entity)
        {
            var deleteEntity = this.RetrieveEntity(entity.PartitionKey, entity.RowKey);

            if (deleteEntity != null)
            {
                var deleteOperation = TableOperation.Delete(deleteEntity);
                return table.ExecuteAsync(deleteOperation).IsCompletedSuccessfully;
            }

            return true;
        }

        public virtual bool EditRecord(ITableEntity entity)
        {
            var updateEntity = this.RetrieveEntity(entity.PartitionKey, entity.RowKey);

            if (updateEntity != null)
            {
                var updateOperation = TableOperation.InsertOrReplace(entity);
                return table.ExecuteAsync(updateOperation).IsCompletedSuccessfully;
            }

            return true;
        }

        private DynamicTableEntity RetrieveEntity(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            var entity = table.ExecuteAsync(retrieveOperation).GetAwaiter().GetResult();

            return (DynamicTableEntity)entity.Result;

        }
    }
}
