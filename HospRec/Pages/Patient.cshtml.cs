using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;

namespace HospRec.Pages
{
    public class PatientModel : PageModel
    {
        [BindProperty]
        public int patientID { get; set; }
        public void OnGet()
        {
            //getPatient(patientID);
        }
    }
}
