using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;


namespace supportupdateAPI.Helper
{
    public class Config
    {
        SqlConnection con;

        public static string ConnectionString
        {
            get;
            private set;
        }

        public Config()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);

            ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }
    }

}
