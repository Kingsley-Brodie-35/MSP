using System;
using System.ComponentModel.DataAnnotations;

namespace HospRec.Models
{
    public class PatientRecord
    {
        
        public int Record_ID { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }
        public DateTime Date { get; set; }
        public string Symptons { get; set; }
        public string Diagnosis { get; set; }
        public string Medication { get; set; }

    }
}
