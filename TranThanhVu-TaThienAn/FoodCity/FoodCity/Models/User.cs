using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCity.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public string usdt { get; set; }
        public string uavatar { get; set; }
        public string uname { get; set; }
        public string uaddress { get; set; }
        public string upassword { get; set; }

    }
}
