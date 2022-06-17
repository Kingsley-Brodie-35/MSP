using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospRec.Models;
using HospRec.Data;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Authorization;

namespace HospRec.Pages
{
    //[Authorize("Doctor")]
    public class searchPatientModel : PageModel
    {
        // POST variables
        [BindProperty]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "ID is only numerical")]
        public string Id {get; set;}
        [BindProperty]
        [StringLength(15, ErrorMessage = "First name must be 15 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must be alphabetical")]
        public string firstName {get; set;}
        [BindProperty]
        [StringLength(15, ErrorMessage = "Last name must be 15 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must be alphabetical")]
        public string lastName {get; set;}
        [BindProperty]
        [DataType(DataType.Date)]
        public string DOB {get; set;}

        public Patient Patient {get; set;}
        public List<Patient> Patients {get; set;} = new List<Patient>();
        private PatientContext PatientContext {get; set;}

        //private DBConnection _db { get; set; }
       
        
        public searchPatientModel(PatientContext pc)
        {
            PatientContext = pc;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            string viewSearchInputs= "";

            //Patients = context.GetByField("");
            if (ModelState.IsValid)
            {                     
                // create query
                if (Id != null)
                {
                    // if given ID search check if id exists
                    Patients.Add(PatientContext.GetByID(Id));
                    viewSearchInputs = "Id " + Id;
                }
                else
                {
                    // create query based on input fields
                    string query = "";
                    switch (firstName, lastName, DOB)
                    {
                        case (not null, null, null):
                            query = $"WHERE FirstName ='{firstName}'";
                            viewSearchInputs = firstName;
                            break;
                        case (not null, not null, null):
                            query = $"WHERE FirstName = '{firstName}' AND LastName = '{lastName}'";
                            viewSearchInputs = firstName + " " + lastName;
                            break;
                        case (not null, not null, not null):
                            query = $"WHERE FirstName = '{firstName}' AND LastName= '{lastName}' AND DOB = '{DOB}'";
                            viewSearchInputs = firstName + " " + lastName + " " + DOB;
                            break;
                        case (null, null, not null):
                            query = $"WHERE DOB = '{DOB}'";
                            viewSearchInputs = DOB;
                            break;
                        case (null, not null, not null):
                            query = $"WHERE LastName = '{lastName}' AND DOB = '{DOB}'";
                            viewSearchInputs = lastName + " " + DOB;
                            break;
                        case (not null, null, not null):
                            query = $"WHERE FirstName = '{firstName}' AND DOB = '{DOB}'";
                            viewSearchInputs = firstName + " " + DOB;
                            break;
                        case (null, not null, null):
                            query = $"WHERE LastName = '{lastName}'";
                            viewSearchInputs = lastName;
                            break;
                        default:
                            break;
                    }
                    Patients = PatientContext.select_conditions(query);
                }
            }

            // view user search inputs
            ViewData["filters"] = viewSearchInputs;

            // clear form input
            Id = "";
            firstName = "";
            lastName = "";
            DOB = "";
            ModelState.Clear();
            return Page();
        }
    }
}
