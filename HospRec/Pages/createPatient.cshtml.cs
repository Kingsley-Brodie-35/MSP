using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

        public IActionResult Post()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
