using FoodCity.ModelDB;
using FoodCity.Models;
using FoodCity.AppConstrants;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhRegister : ContentPage
    {
        public mhRegister()
        {
            InitializeComponent();
        }

        private async void btnDangky_Clicked(object sender, EventArgs e)
        {
            if(txtUserId.Text != null && txtPass.Text != null)
            {
                User user = new User();
                user.usdt = txtUserId.Text;
                user.uname = txtUserName.Text;
                user.upassword = txtPass.Text;
                user.uavatar = "abcxxx";
                user.uaddress = "thiendang";
                string kq = await UserDB.setUser(user);
                user = JsonConvert.DeserializeObject<User>(kq);
                //await DisplayAlert("Thong Bao", kq, "Ok");
                if (user.usdt == "-1")
                {
                    await DisplayAlert("Thong Bao", "So dien thoai da duoc dang ky!", "Ok");
                    txtUserId.Focus();
                    txtPass.Text = "";
                }
                else
                {
                    CredentialsStore.SetCurrentUser(user);
                    Application.Current.MainPage = new NavigationPage(new mhMainView());
                }

            }
            else
            {
                await DisplayAlert("Thong Bao", "Vui lòng nhập vào sdt hoặc mật khẩu", "Ok");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}