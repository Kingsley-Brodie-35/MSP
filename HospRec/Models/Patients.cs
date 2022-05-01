using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HospRec.Models
{
    public class Patients : DbClass
    {
        //fields
        private List<Patient> _patients = new List<Patient>();
        //properties
        public List<Patient> PatientList
        {
            get {
                return _patients;
            }
        }
        //constructor
        public Patients(string connectionString) : base(connectionString) { }
        //methods
        public void GetPatients(string firstName)
        {    
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM patient WHERE FirstName='{firstName}'", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _patients.Add(new Patient(reader.GetInt32("Patient_ID"), reader.GetInt32("PhoneNumber"), reader.GetString("EmailAddress"), reader.GetString("FirstName"), reader.GetString("LastName"), reader.GetChar("Gender"), reader.GetString("DOB")) { });
                    }
                }
                conn.Close();
            }
        }

        public void AddPatients(string firstname, string phonenumber, string email, string gender, string DOB) 
        {
            using (MySqlConnection conn = getConnection()) 
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO patient (FirstName,PhoneNumber,EmailAddress,Gender,DOB) VALUES ({firstname},{phonenumber},{email},{gender},{DOB})", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
        }
    }
}
