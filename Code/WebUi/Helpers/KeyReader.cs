using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebUi.Helpers
{
    /// <summary>
    /// Use this class to access the Azure keys, the file will not be included in the source code
    /// the name of the file should not include the extension. The name will be azure.keys
    /// </summary>
    public class KeyReader
    {
        private static KeyData _keys;
        
        public static KeyData Get()
        {
            //We only do IO once
            if (_keys != null) return _keys;
            var content = GetFileContent("azure");
            var data = content.Split(",".ToCharArray());
            if(data.Length != 2) throw new ArgumentException(string.Format("Invalid file content: azure.keys"));
            _keys = new KeyData()
            {
                Account = data[0], SecretKey = data[1]
            };
            return _keys;
        }
        private static string GetFileContent(string fileName)
        {
            var filePath = HttpContext.Current.Server.MapPath(string.Format("~/Keys/{0}.keys", fileName));
            using (var stream = new StreamReader(filePath))
            {
                return stream.ReadToEnd();
            }
        }

    }

    public class KeyData
    {
        public string Account { get; set; }
        public string SecretKey { get; set; }
    }
}
