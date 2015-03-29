using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebUi.Models
{
    public class Contact : TableEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Prepare()
        {
            PartitionKey = LastName;
            RowKey = Name;
        }
    }
}
