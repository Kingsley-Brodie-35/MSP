using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Data;
using HospRec.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospRec.Pages
{
    [BindProperties]
    public class SearchPatientRecordsModel : PageModel
    {
        //search 
        public string Record_ID { get; set;}

        public string Patient_ID { get; set; }

        public string Doctor_ID { get; set; }

        public string P_First_Name { get; set; }

        public string P_Last_Name { get; set; }

        public string D_First_Name { get; set; }

        public string D_Last_Name { get; set; }


        private PatientRecordContext PatientRecordContext;

        public List<PatientRecord> PatientRecords = new List<PatientRecord>();

        public SearchPatientRecordsModel(PatientRecordContext prc)
        {
            PatientRecordContext = prc;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string sqlWhere = "WHERE ";
            if (Record_ID != null)
            {
                sqlWhere += $"patient_record.Record_ID = \"{Record_ID}\" AND ";
            }
            if (Patient_ID != null)
            {
                sqlWhere += $"patient_record.Patient_ID = \"{Patient_ID}\" AND ";
            }
            if (Doctor_ID != null)
            {
                sqlWhere += $"patient_record.Doctor_ID = \"{Doctor_ID}\" AND ";
            }
            if (P_First_Name != null)
            {
                sqlWhere += $"patient.FirstName = \"{P_First_Name}\" AND ";
            }
            if (P_Last_Name != null)
            {
                sqlWhere += $"patient.LastName = \"{P_First_Name}\" AND ";
            }
            if (D_First_Name != null)
            {
                sqlWhere += $"doctor.FirstName = \"{D_First_Name}\" AND ";
            }
            if (D_Last_Name != null)
            {
                sqlWhere += $"doctor.LastName = \"{D_Last_Name}\" AND ";
            }
            if (sqlWhere.Length > 6)
            {
                sqlWhere = sqlWhere.Remove(sqlWhere.Length - 4, 4);
            }
            //no parameters entered return page
            else
            {
                ViewData["Results"] = "please enter a search parameter";
                return Page();
            }
            sqlWhere.TrimEnd();
            PatientRecords = PatientRecordContext.getPatientRecords(sqlWhere);
            if (PatientRecords.Count == 0)
            {
                ViewData["Results"] = "No results returned";
            }
            return Page();
        }
    }
}
