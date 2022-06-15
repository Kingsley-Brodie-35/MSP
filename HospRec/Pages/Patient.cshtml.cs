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
        //Dependencies
        private PatientContext PatientContext {get; set;}
        
        public PatientModel(PatientContext pc)
        {
            PatientContext = pc;
        }

        public void OnGet(string patientID)
        {
            Patient = PatientContext.GetByID(patientID);
            @ViewData["date"] = Patient.DOB; 
        }


        public IActionResult OnPost(string patientID)
        {
            if (ModelState.IsValid)
            {
                // update patient information
                PatientContext.UpdatePatientData(Patient);
                // retrieve updated profile
                Patient = PatientContext.GetByID(patientID);
            }
            return Page();
        }
    }
}
