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
        private Patients _context = new Patients("server=hosprecdb.mysql.database.azure.com;UserID=HospRecAdmin;Password=MSPteam123;Database=hosprecdb;");

        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastname { get; set; }
        [BindProperty]
        public string phonenumber { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string gender { get; set; }
        [BindProperty]
        public string DOB { get; set; }
        public void OnPost()
        {
            
        }
    }
}
