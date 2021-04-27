using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class AnnonceMeuble
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string region { get; set; }
        public string ville { get; set; }
        public string adresse { get; set; }
        public List<String> images { get; set; }
        public double prix { get; set; }
    }
}