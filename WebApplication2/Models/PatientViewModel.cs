using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class PatientViewModel
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Allergy { get; set; }
        public string BloodGroup { get; set; }
        public string MartialStatus { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DischargeDate { get; set; }
    }
}