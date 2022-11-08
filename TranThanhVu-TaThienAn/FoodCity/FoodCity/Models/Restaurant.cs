using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public string rsdt { get; set; }
        public  string rname { get; set; }
        public string raddress { get; set; }
        public int rtype { get; set; }
        public string hurl { get; set; }
        public List<Food> foods { get; set; }
    }
}
