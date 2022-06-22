using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;
using HospRec.Data;

namespace HospRec.Pages
{
    public class createPatientModel : PageModel
    {
        [BindProperty]
        public Patient Patient {get; set;}
        public PatientContext PatientContext { get; set; }
        public string resultMsg;

        public createPatientModel (PatientContext pc)
        {
            PatientContext = pc;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ViewData["Result"] = PatientContext.InsertPatientData(Patient);
            }
            return Page();
        }
    }
}
