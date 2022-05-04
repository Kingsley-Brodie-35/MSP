using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace HospRec.Data
{
    public class DbClass
    {
        //properties
        public string ConnectionString { get; set; }
        //constructor
        public DbClass(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //methods
        protected  MySqlConnection getConnection() {
            return new MySqlConnection(ConnectionString);
        }
    }
    
}
