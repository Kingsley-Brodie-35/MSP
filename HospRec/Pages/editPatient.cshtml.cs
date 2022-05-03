using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospRec.Pages
{
    public class editPatientModel : PageModel
    {
        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastname { get; set; }
        [BindProperty]
        public string phoneNum { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public char gender { get; set; }
        [BindProperty]
        public string DOB { get; set; }
        public void OnGet(int patientID)
        {
        
        }
        public void OnPost()
        {

        }
    }
}
