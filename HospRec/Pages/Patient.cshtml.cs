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
        private PatientContext PatientContext {get; set;} = new PatientContext();
        //edit form values
        //methods
        public void OnGet(string patientID)
        {
            Patient = PatientContext.GetByID(patientID);
        }
        public void OnPost(string patientID)
        {
            // update patient information
            PatientContext.UpdatePatientData(Patient);
            // retrieve updated profile
            Patient = PatientContext.GetByID(patientID);
        }
    }
}
