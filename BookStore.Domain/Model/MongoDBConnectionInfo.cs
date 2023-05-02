using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Model
{
    public class MongoDBConnectionInfo
    {
        public string? ConnectionString { get; set; }
        public bool? IsEncoded { get; set; }
        public string? DatabaseName { get; set; }
        public bool IsLocalSever { get; set; }
        public string? DBType { get; set; }
    }
}
