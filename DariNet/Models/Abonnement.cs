using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class Abonnement
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string delais { get; set; }
        public string type { get; set; }
        public string contrat { get; set; }
        public object user { get; set; }
    }
}
