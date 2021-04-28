using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
	public class Reclamation
{
        public int id { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public List<object> categorie { get; set; }
        public string reponse { get; set; }
        public bool repondu { get; set; }
        public List<object> user { get; set; }
    }
}
