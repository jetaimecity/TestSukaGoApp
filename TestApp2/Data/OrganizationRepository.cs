using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using TestApp2.Data.Model;
using TestApp2.Models;

namespace TestApp2.Data
{
    public class OrganizationRepository : AzureRepository, IRepository
    {
        private readonly CloudTable table;
        public OrganizationRepository()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=michellesandbox;AccountKey=G8fKyaDRUR4nAd2DXYifItqDRF2SRdtlnbNhNST+GK7sBe5GnV9LwlvffB+0vnNUuQ56Zc42NHaMv9g3wDeaow==;EndpointSuffix=core.windows.net");
            var client = storageAccount.CreateCloudTableClient();
            CloudTable table = client.GetTableReference("Organization");
            table.CreateIfNotExistsAsync();
            this.table = table;
        }

        public ITableEntity ConvertModelToEntity(OrganizationViewModel model, string id = null)
        {
            return new OrganizationEntity(id ?? Guid.NewGuid().ToString())
            {
                Name = model.Name,
                MissionDescription = model.MissionDescription,
                Category = model.Category,
                Website = model.Website.ToString(),
                ContactNumber = model.ContactNumber,
                Address = model.Address,
                LogoReference = model.LogoReference
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
