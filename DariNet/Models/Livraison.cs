using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class Livraison
    {
        public int id { get; set; }
        public string adresse { get; set; }
        public string tel { get; set; }
        public string methodePayement { get; set; }
        public string livraisonStatus { get; set; }
        public List<object> annonceMeuble { get; set; }
    }
}