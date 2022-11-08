using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FoodCity.AppConstrants;
using FoodCity.Models;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhInfoUser : ContentPage
    {
        public mhInfoUser()
        {
            InitializeComponent();
            User user = new User();
            var userString = CredentialsStore.GetCurrentUser();
            user = JsonConvert.DeserializeObject<User>(userString);
            this.BindingContext = user;
        }

        private void btnDangxuat_Clicked(object sender, EventArgs e)
        {
            CredentialsStore.ClearCurrentUser();
            Application.Current.MainPage = new NavigationPage(new mhLogin());
        }
    }
}