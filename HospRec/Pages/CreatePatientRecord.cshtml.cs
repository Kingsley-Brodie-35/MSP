using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;
using HospRec.Data;

namespace HospRec.Pages
{
    public class CreatePatientRecordModel : PageModel
    {
        [BindProperty]
        public PatientRecord PatientRecord { get; set; }

        public PatientRecordContext PatientRecordContext {get; set;}

        public CreatePatientRecordModel(PatientRecordContext prc)
        {
            PatientRecordContext = prc;
        }

        public IActionResult Post()
        {
            return Page();
        }
    }
}
