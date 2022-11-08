using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    public class Advertisement 
    {
        [PrimaryKey, AutoIncrement]
        public string rsdt { get; set; }
        public string aimage { get; set; }

    }
}
