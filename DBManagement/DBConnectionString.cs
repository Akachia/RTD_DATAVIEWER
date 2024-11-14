using Dapper;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagemnet
{
    public class DBConnectionString
    {
        bool isConnection = false;

        public DBConnectionString(string Server, string Database, string DatabaseProvider, string UserId, string Password, string AreaID, string PlantID, (string, string) TrayID, string SystemTypeCode)
        {
            this.Server = Server;
            this.Database = Database;
            this.DatabaseProvider = DatabaseProvider;
            this.UserId = UserId;
            this.Password = Password;
            this.AreaID = AreaID;
            this.PlantID = PlantID;
            this.TrayID = TrayID;
            this.SystemTypeCode = SystemTypeCode;
        }

        public string Server { get; }
        public string Database { get; }
        public string DatabaseProvider { get; }
        public string UserId { get; }
        public string Password { get; }
        public string AreaID { get; }
        public string PlantID { get; }

        public  (string, string) TrayID { get; }
        public string SystemTypeCode { get; }

        public bool IsConnection
        {
            get => isConnection;
        }

        public string ConnectionString()
        {
            return $@"Data Source = {Server}; User Id = {UserId}; Password = {Password};";
            //return $@"Data Source = {Server};Initial catalog = {Database}; User Id={UserId}; Password={Password};";
        }
        public string MssqlConnectionString()
        {
            return $@"Data Source = {Server};Initial catalog = {Database}; User Id={UserId}; Password={Password}; TrustServerCertificate = True";

        }

        public bool TestConnection()
        {
            try
            {

                if (DatabaseProvider.ToString() == "ORACLE")
                {
                    string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                    using (var connection = new OracleConnection(ConnectionString()))
                    {
                        try
                        {
                            connection.Query(testcquery).ToList();
                            return true;
                        }
                        catch (Exception)
                        {

                            return false;
                        }


                    }
                }
                else if (DatabaseProvider.ToString() == "MSSQL")
                {
                    using (SqlConnection connection = new SqlConnection(MssqlConnectionString()))
                    {
                        connection.Open(); // 데이터베이스 연결 시도
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            // 연결 상태 확인
                            isConnection = true;
                            return true;
                        }
                        else
                        {
                            isConnection = false;
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                isConnection = false;
                // 연결 시도 중 오류 발생
                throw ex;
            }
        }

    }
}
