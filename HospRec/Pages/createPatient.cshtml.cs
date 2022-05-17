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
        public PatientContext PatientContext {get; set;} = new PatientContext();
        public string resultMsg;
        public IActionResult Post()
        {
            if (ModelState.IsValid)
            {
                
            }
            return Page();
        }
    }
}
