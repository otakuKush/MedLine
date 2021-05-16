using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication2.Models
{
    public class DoctorViewModel
    {
        public int DoctorID { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter The First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter The Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter The Email Address")]
        [EmailAddress(ErrorMessage = "Enter A Valid Email Address")]
        [StringLength(150)]
        [Display(Name = "Email Address ")]
        public string EmailID { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You must provide a phone number,Phone Number at least 10 digit")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter The Address")]
        public string Address { get; set; }
        public int PatientID { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Enter The Department")]
        public int DepartmentID { get; set; }
        public string Qualification { get; set; }        
        public DateTime JoiningDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime LastDate { get; set; }
        public bool IsActive { get; set; }
    }
}