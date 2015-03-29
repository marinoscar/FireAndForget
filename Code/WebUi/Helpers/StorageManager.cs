using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using WebUi.Models;

namespace WebUi.Helpers
{
    public class StorageManager
    {
        private readonly CloudTable _table;

        public StorageManager()
        {
            var key = KeyReader.Get();
            var storageAccount = new CloudStorageAccount(new StorageCredentials(key.Account, key.SecretKey), true);
            var client = storageAccount.CreateCloudTableClient();
            _table = client.GetTableReference("FireAndForget");
            _table.CreateIfNotExists();
        }

        public void Add(Contact contact)
        {
            var operation = TableOperation.Insert(contact);
            _table.Execute(operation);
        }
    }
}
