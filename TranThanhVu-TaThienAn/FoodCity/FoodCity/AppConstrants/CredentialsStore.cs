using FoodCity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FoodCity.AppConstrants
{
    static class CredentialsStore
    {
        private const string _currentUser = null;

        static public void SetCurrentUser(User user)
        {
            var id = JsonConvert.SerializeObject(user);
            Preferences.Set(_currentUser, id);
        }

        static public string GetCurrentUser()
        {
            return Preferences.Get(_currentUser, null);

        }

        static public bool IsUserLogged()
        {
            var token = GetCurrentUser();
            return token != null;
        }

        static public void ClearCurrentUser()
        {
            Preferences.Remove(_currentUser);
        }
    }
}
