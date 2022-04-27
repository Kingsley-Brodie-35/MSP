using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HospRec.Models
{
    public class db
    {
        //properties
        public string ConnectionString { get; set; }
        //constructor
        public db(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //methods
        private MySqlConnection getConnection() {
            return new MySqlConnection(ConnectionString);
        }
    }
}
