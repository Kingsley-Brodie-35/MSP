using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HospRec.Models;
namespace HospRec.Data
{
    public class PatientContext : DbClass
    {
        public PatientContext() : base("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;") { }
        
        public Patient GetByID(string Id)
        {
            //connect and fetch patient by ID
            Patient result = new Patient();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM patient WHERE Patient_ID = {Id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new Patient{
                            Id = reader.GetInt32("Patient_ID"),
                            firstName = reader.GetString("FirstName"),
                            lastName = reader.GetString("LastName"),
                            email = reader.GetString("EmailAddress"),
                            phoneNumber = reader.GetString("PhoneNumber"),
                            gender = reader.GetChar("Gender"),
                            DOB = DateTime.Parse(reader.GetString("DOB")).ToString("yyyy-MM-dd")
                        };
                    }
                }
                conn.Close();
            }
            return result;
        }
        public List<Patient> select_conditions(string qry)
        {
            //connect and fetch patient records by field(s)
            List<Patient> result = new List<Patient>();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM patient " + qry, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Patient{
                            Id = reader.GetInt32("Patient_ID"),
                            firstName = reader.GetString("FirstName"),
                            lastName = reader.GetString("LastName"),
                            email = reader.GetString("EmailAddress"),
                            phoneNumber = reader.GetString("PhoneNumber"),
                            gender = reader.GetChar("Gender"),
                            DOB = DateTime.Parse(reader.GetString("DOB")).ToString("yyyy-MM-dd")
                        });
                    }
                }
                conn.Close();
            }
            return result;
        }
        public string InsertPatientData(Patient p)
        {
            //connect and insert patient record
            using (MySqlConnection conn = this.getConnection())
            {
                try
                {
                    conn.Open();
                    string qry = $"INSERT INTO patient (FirstName, LastName, EmailAddress, PhoneNumber, Gender, DOB) VALUES ('{p.firstName}', '{p.lastName}', '{p.email}', '{p.phoneNumber}', '{p.gender}', '{p.DOB}')";
                    MySqlCommand cmd = new MySqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Succesfully added patient";
                } catch (Exception e)
                {
                    return "Inavlid data entry: " + e;
                }
            }
        }
        public string UpdatePatientData(Patient p) { 
            //connect and update patient record
            using (MySqlConnection conn = this.getConnection())
            {   
                try 
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE patient SET FirstName='{p.firstName}', LastName='{p.lastName}', PhoneNumber='{p.phoneNumber}', EmailAddress='{p.email}', Gender='{p.gender}', DOB='{p.DOB}' WHERE Patient_ID={p.Id.ToString()}", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Succesfuly updated patient profile";
                } catch (Exception e)
                {
                    return "Unable to update profile: " + e;
                }
            }
        }
    }
    
}
