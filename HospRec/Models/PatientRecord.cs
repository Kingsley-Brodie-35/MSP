using System;
using System.ComponentModel.DataAnnotations;

namespace HospRec.Models
{
    public class PatientRecord
    {
        [Key]
        public int Record_ID { get; set; }
        [Key]
        [Required]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Must be a number")]
        public int Patient_ID { get; set; }
        [Key]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Must be a number")]
        public int Doctor_ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string Date { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Medication { get; set; }
    }
}
