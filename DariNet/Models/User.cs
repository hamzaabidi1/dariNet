using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
	public class User
	{
        public int userId { get; set; }
        public int cin { get; set; }
        public string name { get; set; }
       
        public string address { get; set; } 
        public string email { get; set; }
        public string numTel { get; set; }
        public string sex { get; set; }
        public int codeVerif { get; set; }
        public int counterLogin { get; set; }
        public bool desactivate { get; set; }
        public string lastLoginDate { get; set; }
        public string dateCreate { get; set; }
        public int point { get; set; }
        public int lastyearaddpoint { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public List<Role> roles { get; set; }
        public List<object> listeAnnanceMeuble { get; set; }
        public List<object> listeAnnance { get; set; }
        public List<object> listeAbannement { get; set; }
        public List<object> listeReclamation { get; set; }
        public List<object> listeRecherche { get; set; }
        public List<object> listeOperation { get; set; }
        public List<object> listeMessage { get; set; }
        public List<object> listeReviews { get; set; }
        public bool connected { get; set; }
        public bool verified { get; set; }
        public string accessToken { get; set; }
    }

 
}


