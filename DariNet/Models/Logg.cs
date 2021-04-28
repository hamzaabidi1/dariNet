using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariNet.Models
{
    public class Logg
    {
        public int id { get; set; }
        public string tableName { get; set; }
        public string actionName { get; set; }
        public int userId { get; set; }
        public string dateAction { get; set; }
    }
}
