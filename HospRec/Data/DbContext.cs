using MySql.Data.MySqlClient;
using System.Configuration;
using HospRec;
using Microsoft.Extensions.DependencyInjection;

namespace HospRec.Data
{
    public class DBConnection
    {
        
        string value = ConfigurationManager.AppSettings["ConnectionStrings"];

        //properties
        public string ConnectionString { get; set; }
        //constructor
        public DBConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //methods
        protected  MySqlConnection getConnection() {
            //ConnectionString = configuration.GetConnectionString("DefaultConnection");
            return new MySqlConnection(ConnectionString);
        }
    }
    
}
