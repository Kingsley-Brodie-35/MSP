using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HospRec.Models;
namespace HospRec.Data
{
    public class DoctorContext : DBConnection
    {
        public DoctorContext() : base("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;") { }
        public List<Doctor> GetDoctorByFields(string extra_cmd)
        {
            List<Doctor> result = new List<Doctor>();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Dctor {extra_cmd}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Doctor{
                            // Id = reader.GetInt32("Patient_ID"),
                            // firstName = reader.GetString("FirstName"),
                            // lastName = reader.GetString("LastName"),
                            // email = reader.GetString("EmailAddress"),
                            // phoneNumber = reader.GetInt32("PhoneNumber"),
                            // gender = reader.GetChar("Gender"),
                            // DOB = reader.GetString("DOB")
                        });
                    }
                }
                conn.Close();
            }
            return result;
        }
    }
    
}
