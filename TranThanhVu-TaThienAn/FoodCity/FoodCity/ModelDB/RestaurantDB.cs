using FoodCity.Models;
using FoodCity.AppConstrants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodCity.ModelDB
{
    class RestaurantDB
    {
        public static async Task<Restaurant> getRestaurantByid(string id)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Restaurant/id?id=" + id);
            Restaurant Res = JsonConvert.DeserializeObject<Restaurant>(kq);
            Res.foods = await FoodDB.getFoodByResId(id);
            return Res;
        }
    }
}
