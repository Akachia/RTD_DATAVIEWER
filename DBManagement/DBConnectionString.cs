using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagemnet
{
    public  class DBConnectionString
    {
        public DBConnectionString(string Server, string Database, string DatabaseProvider, string UserId, string Password, string AreaID, string PlantID, string SystemTypeCode)
        {
            this.Server = Server;
            this.Database = Database;
            this.DatabaseProvider = DatabaseProvider;
            this.UserId = UserId;
            this.Password = Password;
            this.AreaID = AreaID;
            this.PlantID = PlantID;
            this.SystemTypeCode = SystemTypeCode;
        }

        public string Server { get;  }
        public string Database { get;  }
        public string DatabaseProvider { get; }
        public string UserId { get;  }
        public string Password { get;  }
        public string AreaID { get;  }
        public string PlantID { get;  }

        public string SystemTypeCode { get; }

        public string ConnectionString()
        {
            return $@"Data Source = {Server}; User Id = {UserId}; Password = {Password};";
            //return $@"Data Source = {Server};Initial catalog = {Database}; User Id={UserId}; Password={Password};";
        }
        public string MssqlConnectionString()
        {
            return $@"Data Source = {Server};Initial catalog = {Database}; User Id={UserId}; Password={Password}; TrustServerCertificate = True";

        }
    }
}
