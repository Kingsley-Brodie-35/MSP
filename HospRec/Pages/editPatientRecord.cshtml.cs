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
    public class editPatientRecordsModel : PageModel
    {

        [BindProperty]
        public PatientRecord PatientRecord { get; set; }
        //Dependencies
        private PatientRecordContext PatientRecordContext { get; set; }
        
        public editPatientRecordsModel(PatientRecordContext pcc)
        {
            PatientRecordContext = pcc;
        }

        public void OnGet(string patientRecordID)
        {
            PatientRecord = PatientRecordContext.GetByID(patientRecordID);
        }

        public IActionResult OnPost(string patientRecordID)
        {
            if (ModelState.IsValid)
            {
                // update and retrieve updated record
                PatientRecordContext.UpdateRecord(PatientRecord);
                PatientRecord = PatientRecordContext.GetByID(patientRecordID);                 
            }
            return Page();
        }
        public IActionResult OnPostCancel()
        {
            return Redirect("/patient/" + PatientRecord.Patient_ID);
        }
    }
}
