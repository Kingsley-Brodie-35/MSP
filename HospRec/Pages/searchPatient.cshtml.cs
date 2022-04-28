using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;

namespace HospRec.Pages
{
    public class searchPatientModel : PageModel
    {
        private List<Patient> _patients = new List<Patient>();
        private DbClass _db = new DbClass("server=hosprecdb.mysql.database.azure.com;port=3306;database=hosprecdb;user=HopspRecAdmin;password=MSPteam123");

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
            return base.Content("<div>Hello</div>", "text/html");
        }

        public void Query()
        {
            _patients = _db.GetPatients(firstName);           
        }
    }
}
