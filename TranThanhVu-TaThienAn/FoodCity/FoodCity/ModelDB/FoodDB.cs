using FoodCity.Models;
using Newtonsoft.Json;
using FoodCity.AppConstrants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodCity.ModelDB
{
    class FoodDB
    {
        public static async Task<List<Food>> getFoodByType(int type)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Food/type?id=" + type);
            List<Food> lsFood = JsonConvert.DeserializeObject<List<Food>>(kq);
            return lsFood;
        }

        public static async Task<List<Food>> getFoodByResId(string id)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Food/ResId?id=" + id);
            List<Food> lsFood = JsonConvert.DeserializeObject<List<Food>>(kq);
            return lsFood;
        }

        public static async Task<List<Food>> getFoodBySearch(string txt)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Food/text?text=" + txt);
            List<Food> lsFood = JsonConvert.DeserializeObject<List<Food>>(kq);
            return lsFood;
        }
    }
}
