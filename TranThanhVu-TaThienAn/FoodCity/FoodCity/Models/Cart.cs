using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int maso { get; set; }
        public string usdt { get; set; }
        public List<Food> foods { get; set; }
    }
}
