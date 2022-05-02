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
        public void OnGet(int patientID)
        {
            _id = patientID;
            getPatient();
        }
        public void getPatient()
        {
            p = p.GetPatientByID(_id);
        }
    }
}
