using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyGodStore
{
    public class SettingInfo
    {
        public static string SecretKey
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();
                return config["AppSettings:SecretKey"];
            }
        }
        public static byte[] SecretKeyByte
        {
            get
            {
                var secretKey = SecretKey;
                return Encoding.UTF8.GetBytes(secretKey);
            }
        }
    }
}
