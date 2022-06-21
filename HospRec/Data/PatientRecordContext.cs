using System;
using MySql.Data.MySqlClient;
using HospRec.Models;


namespace HospRec.Data
{
    public class PatientRecordContext : DBConnection
    {
        public PatientRecordContext(string connString) : base(connString) { }

        public string InsertPatientRecord(PatientRecord pr)
        {
            using (MySqlConnection conn = this.getConnection())
            {
                try
                {
                    conn.Open();
                    string qry = $"INSERT INTO patient_record (Patient_ID, Doctor_ID, Date, Symptoms, Diagnosis, Medication) VALUES ('{pr.Patient_ID}', '{pr.Doctor_ID}', '{pr.Date}', '{pr.Symptons}', '{pr.Diagnosis}', '{pr.Medication}')";
                    MySqlCommand cmd = new MySqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Succesfully added patientRecord";
                }
                catch (MySqlException e)
                {
                    int errorCode = e.Number;
                    if (errorCode == 1452)
                    {
                        return "Invalid data entry: Cannot find DoctorID or PatientID";
                    }
                    return "Invalid data entry: " + e;
                }
                catch (Exception e)
                {
                    return "Inavlid data entry: " + e;
                }
            }
        }
    }
}