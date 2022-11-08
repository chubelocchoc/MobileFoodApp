using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public string fid { get; set; }
        public string rsdt { get; set; }
        public string raddress { get; set; }
        public string fname { get; set; }
        public string fprice { get; set; }
        public int fsold { get; set; }
        public int ftype { get; set; }
        public string fdiscription { get; set; }
        public string hurl { get; set; }
    }
}
