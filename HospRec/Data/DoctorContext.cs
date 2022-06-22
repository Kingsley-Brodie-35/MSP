using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HospRec.Models;

namespace HospRec.Data
{
    public class DoctorContext : DBConnection
    {
        public DoctorContext(string connString) : base(connString) { }
    }
    
}
