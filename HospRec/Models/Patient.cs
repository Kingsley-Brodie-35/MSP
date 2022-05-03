using MySql.Data.MySqlClient;
using System;

namespace HospRec.Models
{
    public class Patient : DbClass
    {   
        //fields
        private int _patientID;
        private long _ph;
        private string _email;
        private string _firstName;
        private string _lastName;
        private char _gender;
        private string _dob;
        //constructor
        public int PatientID
        {
            get
            {
                return _patientID;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }
        public long PhNumber
        {
            get
            {
                return _ph;
            }
        }
        public char Gender
        {
            get
            {
                return _gender;
            }
        }
        public string DOB
        {
            get
            {
                return _dob;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }
        //constructor
        public Patient(int id, long ph, string email, string firstName, string lastName, char gender, string dob) : base("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;")
        {
            _patientID = id;
            _ph = ph;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _dob = dob;
        }
        public Patient() : base("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;") { }

        public Patient GetPatientByID(int id)
        {
            Patient p = new Patient();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM patient WHERE Patient_ID={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       p = new Patient(reader.GetInt32("Patient_ID"), reader.GetInt32("PhoneNumber"), reader.GetString("EmailAddress"), reader.GetString("FirstName"), reader.GetString("LastName"), reader.GetChar("Gender"), reader.GetString("DOB")) { };
                    }
                }
            }
            return p;
        }
        public void InsertPatientData()
        {
            ////connect and insert patient record
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO patient (PhoneNumber, EmailAddress, FirstName, Gender, DOB, LastName) VALUES ({this.PhNumber},{this.Email}, {this.FirstName}, {this.Gender}, {this.DOB}, {this.LastName})", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
