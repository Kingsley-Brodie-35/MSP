using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using HospRec.Models;

namespace HospRec.Pages
{
    public class createPatientModel : PageModel
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
        public long phNum { get; set; }
        public string resultMsg;
        public IActionResult OnPost()
        {
            try
            {
                phNum = Int64.Parse(phoneNum);
            } catch (FormatException) { }
            Patient p = new Patient(0, phNum, email, firstName, lastname, gender, DOB);
            resultMsg = p.InsertPatientData();
            return Page();
        }
    }
}
