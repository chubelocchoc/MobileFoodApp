using FoodCity.Models;
using FoodCity.AppConstrants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodCity.ModelDB
{
    static class UserDB
    {
        public static async Task<User> getUser(string id, string pass)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(data.url + "DangNhap?id=" + id + "&code=" + pass);
            User user = JsonConvert.DeserializeObject<User>(kq);
            return user;
        }
        public static async Task<string> setUser(User user)
        {
            HttpClient http = new HttpClient();
            string query = JsonConvert.SerializeObject(user);
            StringContent httpContent = new StringContent(query, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync(data.url + "AddUser", httpContent);
            var kqstring = await kq.Content.ReadAsStringAsync();
            return kqstring;
        }
    }
}
