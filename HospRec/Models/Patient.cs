using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospRec;

namespace HospRec.Models
{
    public class Patient
    {   
        //fields
        private int _patientID;
        private int _ph;
        private string _email;
        private string _firstName;
        private char _gender;
        private string _dob;
        private DbClass _db;
        //properties
        public DbClass Db
        {
            get
            {
                return _db;
            }
        }
        //constructor
        public Patient(int id, int ph, string email, string firstName, char gender, string dob)
        {
            _patientID = id;
            _ph = ph;
            _email = email;
            _firstName = firstName;
            _gender = gender;
            _dob = dob;
        }
        public Patient() { }
    }
}
