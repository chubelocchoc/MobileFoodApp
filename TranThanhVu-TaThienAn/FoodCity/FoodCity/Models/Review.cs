using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    class Review
    {
        [PrimaryKey, AutoIncrement]
        public int stt { get; set; }
        public string rsdt { get; set; }
        public string usdt { get; set; }
        public string uname { get; set; }
        public string uavatar { get; set; }
        public string rating { get; set; }
        public string content { get; set; }
    }
}
