using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAO
{
    public class AD_Conector
    {
        private IConfiguration _configuration;
        public string CxSQLFacturacion()
        {
            var builder = new ConfigurationBuilder() //CONSTRUCTOR
                                       //              .SetBasePath("/app")  //con docker
                                      .SetBasePath(Directory.GetCurrentDirectory()) //con VSC
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            _configuration = builder.Build();
            return _configuration.GetConnectionString("ConexionBDCovid");

        }
    }
}
