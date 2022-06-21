using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;
using HospRec.Data;

namespace HospRec.Pages
{
    public class PatientModel : PageModel
    {

        [BindProperty]
        public Patient Patient {get; set;} 
        public List<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();

        //Dependencies
        private PatientContext PatientContext {get; set;}
        private PatientRecordContext PatientRecordContext { get; set; }
        
        public PatientModel(PatientContext pc, PatientRecordContext pcc)
        {
            PatientContext = pc;
            PatientRecordContext = pcc;
        }

        public void OnGet(string patientID)
        {
            // Get Patient Details and Records
            Patient = PatientContext.GetByID(patientID);
            PatientRecords = PatientRecordContext.GetByPatientId(patientID);
        }

        public IActionResult OnPost(string patientID)
        {
            if (ModelState.IsValid)
            {
                // Update and retrieve updated details
                PatientContext.UpdatePatientData(Patient);
                Patient = PatientContext.GetByID(patientID);
            }
            return Page();
        }
    }
}
