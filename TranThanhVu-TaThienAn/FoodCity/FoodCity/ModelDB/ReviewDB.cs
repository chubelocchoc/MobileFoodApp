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
    class ReviewDB
    {
        public static async Task<List<Review>> getReviewByResId(string id)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Review/ResId?id=" + id);
            List<Review> Rev = JsonConvert.DeserializeObject<List<Review>>(kq);
            return Rev;
        }
    }
}
