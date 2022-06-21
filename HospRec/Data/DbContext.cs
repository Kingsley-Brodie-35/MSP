using MySql.Data.MySqlClient;
using System.Configuration;
using HospRec;
using Microsoft.Extensions.DependencyInjection;

namespace HospRec.Data
{
    public class DBConnection
    {
        //properties
        public string ConnectionString { get; set; }
        ////constructor
        public DBConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //methods
        protected MySqlConnection getConnection() {
            return new MySqlConnection(ConnectionString);
        }
    }
    
}
