using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Sessions
{
    public class CommonProperties
    {
        #region Properties

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedDate { get; set; }
        public string DueDays { get; set; }
        
        #endregion
    }
}