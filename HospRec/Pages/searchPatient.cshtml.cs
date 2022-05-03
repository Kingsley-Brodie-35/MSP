using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;
using MySql.Data.MySqlClient;

namespace HospRec.Pages
{
    public class searchPatientModel : PageModel
    {
        private Patients _p = new Patients("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;");
        public Patients Patients
        {
            get
            {
                return _p;
            }
        }
        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastName { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Query();
            return Page();
        }

        public void Query()
        {
            Patients.GetPatients(firstName, lastName);
        }
    }
}
