using System;
using System.Collections.Generic;
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
                    string qry = $"INSERT INTO patient_record (Patient_ID, Doctor_ID, Date, Symptoms, Diagnosis, Medication) VALUES ('{pr.Patient_ID}', '{pr.Doctor_ID}', '{pr.Date}', '{pr.Symptoms}', '{pr.Diagnosis}', '{pr.Medication}')";
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
        // Patient Records for individual
        public List<PatientRecord> GetByPatientId(string Id)
        {
            List<PatientRecord> records = new List<PatientRecord>();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                string qry = $"SELECT * FROM patient_record WHERE Patient_ID = {Id}";
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new PatientRecord
                        {
                            Record_ID = reader.GetInt32("Record_ID"),
                            Patient_ID = reader.GetInt32("Patient_ID"),
                            Doctor_ID = reader.GetInt32("Doctor_ID"),
                            Date = DateTime.Parse(reader.GetString("Date")).ToString("yyyy-MM-dd"),
                            Symptoms = reader.GetString("Symptoms"),
                            Diagnosis = reader.GetString("Diagnosis"),
                            Medication = reader.GetString("Medication")
                        });
                    }
                }
                conn.Close();                
            }
            return records;
        }
        public PatientRecord GetByID (string Id)
        {
            //connect and fetch patient by ID
            PatientRecord result = new PatientRecord();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM patient_record WHERE Record_ID = {Id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new PatientRecord{
                            Record_ID = reader.GetInt32("Record_ID"),
                            Patient_ID = reader.GetInt32("Patient_ID"),
                            Doctor_ID = reader.GetInt32("Doctor_ID"),
                            Date = DateTime.Parse(reader.GetString("Date")).ToString("yyyy-MM-dd"),
                            Symptoms = reader.GetString("Symptoms"),
                            Diagnosis = reader.GetString("Diagnosis"),
                            Medication = reader.GetString("Medication")
                        };
                    }
                }
                conn.Close();
            }
            return result;
        }
        public string UpdateRecord(PatientRecord pr) { 
            //connect and update patient record
            using (MySqlConnection conn = this.getConnection())
            {   
                try 
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE patient_record SET Doctor_ID='{pr.Doctor_ID}', Date='{pr.Date}', Symptoms='{pr.Symptoms}', Diagnosis='{pr.Diagnosis}', Medication='{pr.Medication}' WHERE Record_ID={pr.Record_ID.ToString()}", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Succesfuly updated patient profile";
                } catch (Exception e)
                {
                    return "Unable to update profile: " + e;
                }
            }
        }
        public List<PatientRecord> getPatientRecords(string whereClause)
        {
            string qry = "SELECT patient_record.Record_ID, patient_record.Patient_ID, patient_record.Doctor_ID, patient_record.Date, patient_record.Symptoms, patient_record.Diagnosis, patient_record.Medication FROM patient_record INNER JOIN patient ON patient_record.Patient_ID = patient.Patient_ID INNER JOIN doctor ON patient_record.Doctor_ID = doctor.Doctor_ID ";
            qry += whereClause;
            List<PatientRecord> records = new List<PatientRecord>();
            using (MySqlConnection conn = this.getConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new PatientRecord
                        {
                            Record_ID = reader.GetInt32("Record_ID"),
                            Patient_ID = reader.GetInt32("Patient_ID"),
                            Doctor_ID = reader.GetInt32("Doctor_ID"),
                            Date = DateTime.Parse(reader.GetString("Date")).ToString("yyyy-MM-dd"),
                            Symptoms = reader.GetString("Symptoms"),
                            Diagnosis = reader.GetString("Diagnosis"),
                            Medication = reader.GetString("Medication")
                        });
                    }
                }
                conn.Close();
            }
            return records;
        }
    }
}