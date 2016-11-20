using System;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Syns;

namespace AzureBlobSynsStore
{
    public class AzureBlobSynsStore : ISynsStore
    {
        private readonly CloudStorageAccount m_StorageAccount;

        public AzureBlobSynsStore()
        {
            m_StorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }

        public decimal GetTodaySyns(User user)
        {
            var readOperation = TableOperation.Retrieve<SynsRow>(user.Username, DateTime.Today.ToString("yyyy-MM-dd"));
            var result = GetSynsTable().Execute(readOperation);
            var synsRow = (SynsRow)result.Result;

            return synsRow.Syns;
        }

        public void SetTodaySyns(User user, decimal todaySyns)
        {
            var synsRow = new SynsRow(user.Username, DateTime.Today, todaySyns);

            GetSynsTable().Execute(TableOperation.InsertOrReplace(synsRow));
        }

        private CloudTable GetSynsTable()
        {
            var tableClient = m_StorageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("syns");
            table.CreateIfNotExists();

            return table;
        }

        private class SynsRow : TableEntity
        {
            public SynsRow() { }

            public SynsRow(string username, DateTime date, decimal syns)
            {
                PartitionKey = username;
                RowKey = date.ToString("yyyy-MM-dd");
                Syns = syns;
            }

            public decimal Syns { get; set; }
        }
    }
}
