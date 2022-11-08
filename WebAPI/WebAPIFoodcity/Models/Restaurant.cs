using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIFoodcity.Models
{
    public class Restaurant
    {
        public string rsdt { get; set; }
        public string rname { get; set; }
        public string raddress { get; set; }
        public int rtype { get; set; }
        public string hurl { get; set; }
    }
}