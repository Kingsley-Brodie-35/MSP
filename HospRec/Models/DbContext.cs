using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HospRec.Models
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
        private MySqlConnection getConnection() {
            return new MySqlConnection(ConnectionString);
        }
        public List<Patient> GetPatients(string firstName)
        {
            List<Patient> Patients = new List<Patient>();

            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM patient WHERE FirstName={firstName}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patients.Add(new Patient(reader.GetInt32("Patient_ID"), reader.GetInt32("PhoneNumber"), reader.GetString("EmailAddress"), reader.GetString("FirstName"), reader.GetChar("Gender"), reader.GetString("DOB")){  });
                    }
                }
            }
            return Patients;
        }
    }
}
