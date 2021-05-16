using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Sessions
{
    public class LogOnSession : CommonProperties
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
        public string DeactivatedDate { get; set; }
        public bool IsLeadUser { get; set; }
        public string UserType { get; set; }

        public static readonly string UserLogOnSession = "LogOnSession";
    }
}