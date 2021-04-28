using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class ResetPassword
    {
        
        public string token { get; set; }
        public string password { get; set; }
    }
}