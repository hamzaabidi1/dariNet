using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class Annonce
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string categorie { get; set; }
        public double prix { get; set; }
        public List<object> photo { get; set; }
        public string adresse { get; set; }
        public string type { get; set; }
        public int surface { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public int nbreChambre { get; set; }
        public string region { get; set; }
        public string ville { get; set; }
        public List<object> rendezVous { get; set; }
        public List<object> Messages { get; set; }
        public List<object> operations { get; set; }
        public List<object> reviews { get; set; }
        public List<object> reclamations { get; set; }
        public List<object> messages { get; set; }
        public int numberOfVisits { get; set; }
    }
}