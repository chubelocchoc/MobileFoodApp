using FoodCity.Models;
using FoodCity.AppConstrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using FoodCity.ModelDB;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhCart : ContentPage
    {
        public mhCart()
        {
            InitializeComponent();
            this.Appearing += MhCart_Appearing;
        }
        private void MhCart_Appearing(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            if (mhRestaurant.foods.Count > 0)
            {
                txtThongBao.IsVisible = false;
                lsDSreview.ItemsSource = null;
                List<Food> dsfood = mhRestaurant.foods;
                lsDSreview.ItemsSource = dsfood;
                btnDK.TextColor = Color.White;
                btnDK.BackgroundColor = Color.Orange;
            }
            else
            {
                txtThongBao.IsVisible = true;
                btnDK.TextColor = Color.Black;
                btnDK.BackgroundColor = (Color)Resources["coTextMo"];
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            var temp = CredentialsStore.GetCurrentUser();
            User user = JsonConvert.DeserializeObject<User>(temp);
            cart.usdt = user.usdt;
            cart.foods = mhRestaurant.foods;
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            mhRestaurant mh = tabbedPage.Children[0] as mhRestaurant;
            mh.Reset();
            if(CartDB.setCart(cart))
            {
                DisplayAlert("Thông Báo", "Đã đặt món thành công!", "Ok");
            }
            init();
        }
    }
}