using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Students
    {
       public int SNo { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string DOB { get; set; }
        public int MobileNo { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
    }
}