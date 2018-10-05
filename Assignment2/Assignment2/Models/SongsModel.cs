using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class SongsModel
    {
        public decimal sId { get; set; }
        public string sName { get; set; }
        public string aName { get; set; }
        public decimal year { get; set; }
        public bool own { get; set; }
    }
}