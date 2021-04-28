using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class SignUpRequest
    {
        public int userId { get; set; }
        public int cin { get; set; }
        public string name { get; set; }

        public string address { get; set; }
        public string email { get; set; }
        public string numTel { get; set; }
        public string sex { get; set; }
        
        public string password { get; set; }
        public int age { get; set; }
        public List<Role> roles{ get; set; }
       
    }

  
}