using FoodCity.ModelDB;
using FoodCity.Models;
using FoodCity.AppConstrants;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhLogin : ContentPage
    {

        public mhLogin()
        {
            InitializeComponent();
        }

        private async void btnDangNhap_Clicked(object sender, EventArgs e)
        {
            if (txtUserName.Text != null && txtPass.Text != null)
            {
                User user = new User();
                user = await UserDB.getUser(txtUserName.Text, txtPass.Text);
                if (user.usdt != "0")
                {
                    CredentialsStore.SetCurrentUser(user);
                    Navigation.InsertPageBefore(new mhMainView(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    txtPass.Text = "";
                    txtPass.Focus();
                    await DisplayAlert("Thông Báo", "Vui lòng kiểm tra sdt và mật khẩu", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Thong Bao", "Vui lòng nhập vào sdt hoặc mật khẩu", "Ok");
            }
        }

        private void btnDangKy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new mhRegister());
        }
    }
}