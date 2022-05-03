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

        public int _id;
        public Patient p = new Patient();
        //edit form values
        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastName { get; set; }
        [BindProperty]
        public string phoneNum { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public char gender { get; set; }
        [BindProperty]
        public string DOB { get; set; }
        //methods
        public void OnGet(int patientID)
        {
            _id = patientID;
            getPatient();
        }
        public void getPatient()
        {
            p = p.GetPatientByID(_id);
        }
        public IActionResult OnPost()
        {
            //this.OnGet(_id);
            return Redirect("../patient/2");
            //p.UpdatePatientData(firstName, lastName, phoneNum, email, gender, DOB);
        }
    }
}
