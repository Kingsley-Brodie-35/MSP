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
        private string _lastName;
        private char _gender;
        private string _dob;
        private DbClass _db;
        public int PatientID
        {
            get
            {
                return _patientID;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }
        //properties
        public DbClass Db
        {
            get
            {
                return _db;
            }
        }
        //constructor
        public Patient(int id, int ph, string email, string firstName, string lastName, char gender, string dob)
        {
            _patientID = id;
            _ph = ph;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _dob = dob;
        }
        public Patient() { }
    }
}
