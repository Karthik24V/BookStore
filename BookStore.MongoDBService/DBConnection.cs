using BookStore.Domain.Model;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.MongoDBService
{
    public static class DBConnection
    {
        public static IMongoDatabase GetDatabase(MongoDBConnectionInfo dbDetails)
        {
            Console.WriteLine(JsonConvert.SerializeObject(dbDetails));

            var settings = MongoClientSettings.FromUrl(new MongoUrl(dbDetails.ConnectionString));

            Console.WriteLine(dbDetails.ConnectionString);
            settings.MaxConnectionPoolSize = 10000;
            if (!dbDetails.IsLocalSever && dbDetails.DBType != "mongo")
            {
                string caContentString = System.IO.File.ReadAllText("./Cert/rds-combined-ca-bundle-dev.pem");
                X509Certificate2 caCert = new X509Certificate2(Encoding.ASCII.GetBytes(caContentString));
                settings.AllowInsecureTls = true;
                settings.SslSettings = new SslSettings()
                {
                    ClientCertificates = new[] { caCert }
                };
            }
            var client = new MongoClient(settings);
            return client.GetDatabase(dbDetails.DatabaseName);
        }
    }
}
