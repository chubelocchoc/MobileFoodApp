using FoodCity.Models;
using FoodCity.AppConstrants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FoodCity.ModelDB
{
    class AdvertisementDB
    {
        public static async Task<List<Advertisement>> getAdvertisement()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "Advertisement");
            List<Advertisement> lsAd = JsonConvert.DeserializeObject<List<Advertisement>>(kq);
            return lsAd;
        }
    }
}
