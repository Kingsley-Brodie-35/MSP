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
        //public string InsertPatientData(Patient p)
        //{
        //    //connect and insert patient record
        //    using (MySqlConnection conn = this.getConnection())
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string qry = $"INSERT INTO patient (FirstName, LastName, EmailAddress, PhoneNumber, Gender, DOB) VALUES ('{p.firstName}', '{p.lastName}', '{p.email}', '{p.phoneNumber}', '{p.gender}', '{p.DOB}')";
        //            MySqlCommand cmd = new MySqlCommand(qry, conn);
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //            return "Succesfully added patient";
        //        } catch (Exception e)
        //        {
        //            return "Inavlid data entry: " + e;
        //        }
        //    }
        //}
        //public string UpdatePatientData(string fName, string lName, string phNum, string email, char g, string dob, int Id) { 
        //    //connect and update patient record
        //    using (MySqlConnection conn = this.getConnection())
        //    {   
        //        try 
        //        {
        //            conn.Open();
        //            MySqlCommand cmd = new MySqlCommand($"UPDATE patient SET FirstName='{fName}', LastName='{lName}', PhoneNumber='{phNum}', EmailAddress='{email}', Gender='{g}', DOB='{dob}' WHERE Patient_ID={Id}", conn);
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //            return "Succesfuly updated patient profile";
        //        } catch (Exception e)
        //        {
        //            return "Unable to update profile: " + e;
        //        }
        //    }
        //}
    }
    
}
