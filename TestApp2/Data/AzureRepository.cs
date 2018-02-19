using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using System.Threading.Tasks;

namespace TestApp2.Data
{
    public abstract class AzureRepository
    {
        public void AddRecord(ITableEntity entity, CloudTable table)
        {
            var insertOperation = TableOperation.Insert(entity);
            table.ExecuteAsync(insertOperation);
        }

        public bool DeleteRecord(ITableEntity entity, CloudTable table)
        {
            var deleteEntity = this.RetrieveEntity(entity.PartitionKey, entity.RowKey, table);

            if (deleteEntity != null)
            {
                var deleteOperation = TableOperation.Delete(deleteEntity);
                return table.ExecuteAsync(deleteOperation).IsCompletedSuccessfully;
            }

            return true;
        }

        public virtual bool EditRecord(ITableEntity entity, CloudTable table)
        {
            var updateEntity = this.RetrieveEntity(entity.PartitionKey, entity.RowKey, table);

            if (updateEntity != null)
            {
                var updateOperation = TableOperation.Replace(updateEntity);
                return table.ExecuteAsync(updateOperation).IsCompletedSuccessfully;
            }

            return true;
        }

        private DynamicTableEntity RetrieveEntity(string partitionKey, string rowKey, CloudTable table)
        {
            var retrieveOperation = TableOperation.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            var entity = table.ExecuteAsync(retrieveOperation).GetAwaiter().GetResult();

            return (DynamicTableEntity)entity.Result;

        }
    }
}
