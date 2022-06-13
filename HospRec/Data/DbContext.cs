using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace HospRec.Data
{
    public class DBConnection
    {
        //properties
        public string ConnectionString { get; set; }
        //constructor
        public DBConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //methods
        protected  MySqlConnection getConnection() {
            return new MySqlConnection(ConnectionString);
        }
    }
    
}
