using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp2.Data
{
    public interface IRepository
    {
        void AddRecord(ITableEntity entity);

        bool EditRecord(ITableEntity entity);

        bool DeleteRecord(ITableEntity entity);
    }
}
