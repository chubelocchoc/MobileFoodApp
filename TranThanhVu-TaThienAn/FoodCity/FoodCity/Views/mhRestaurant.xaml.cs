using FoodCity.ModelDB;
using FoodCity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhRestaurant : ContentPage
    {
        private string rid;
        public static List<Food> foods = new List<Food>();
        public mhRestaurant()
        {
            InitializeComponent();
        }

        private async void getRestaurant(string id)
        {
            Restaurant res = await RestaurantDB.getRestaurantByid(id);
            lsDS.ItemsSource = res.foods;
            InitButton();
            BindingContext = res;

        }
        public mhRestaurant(string id)
        {
            rid = id;
            getRestaurant(id);
            InitializeComponent();
        }

        private void InitButton()
        {
            frDanhgia.IsVisible = false;
            frThongtin.IsVisible = false;

            btnDatmon.TextColor = Color.White;
            btnDatmon.BackgroundColor = Color.Orange;

            btnDanhgia.TextColor = (Color)Resources["coTextMo"];
            btnDanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btnThongtin.TextColor = (Color)Resources["coTextMo"];
            btnThongtin.BackgroundColor = (Color)Resources["coWhite"];

        }

        private async void btnDanhgia_Clicked(object sender, EventArgs e)
        {
            frDanhgia.IsVisible = true;
            frDatmon.IsVisible = false;
            frThongtin.IsVisible = false;

            btnDatmon.TextColor = (Color)Resources["coTextMo"];
            btnDatmon.BackgroundColor = (Color)Resources["coWhite"];

            btnDanhgia.TextColor = Color.White;
            btnDanhgia.BackgroundColor = Color.Orange;
            btnThongtin.TextColor = (Color)Resources["coTextMo"];
            btnThongtin.BackgroundColor = (Color)Resources["coWhite"];
            lsDSreview.ItemsSource = await ReviewDB.getReviewByResId(rid);
        }

        private void btnDatmon_Clicked(object sender, EventArgs e)
        {
            frDanhgia.IsVisible = false;
            frThongtin.IsVisible = false;
            frDatmon.IsVisible = true;

            btnDatmon.TextColor = Color.White;
            btnDatmon.BackgroundColor = Color.Orange;

            btnDanhgia.TextColor = (Color)Resources["coTextMo"];
            btnDanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btnThongtin.TextColor = (Color)Resources["coTextMo"];
            btnThongtin.BackgroundColor = (Color)Resources["coWhite"];
        }

        private void btnThongtin_Clicked(object sender, EventArgs e)
        {
            frDanhgia.IsVisible = false;
            frThongtin.IsVisible = true;
            frDatmon.IsVisible = false;

            btnDatmon.TextColor = (Color)Resources["coTextMo"];
            btnDatmon.BackgroundColor = (Color)Resources["coWhite"];

            btnDanhgia.TextColor = (Color)Resources["coTextMo"];
            btnDanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btnThongtin.TextColor = Color.White;
            btnThongtin.BackgroundColor = Color.Orange;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhHome() { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }

        private void btnThemVaoGio_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button.Text.Equals("Đã Thêm"))
            {
                Food food = button.Parent.Parent.Parent.Parent.Parent.BindingContext as Food;
                foods.Remove(food);
                button.TextColor = Color.Black;
                button.BackgroundColor = (Color)Resources["coTextMo"];
                button.Text = "Thêm vào giỏ";
            }
            else
            {
                Food food = button.Parent.Parent.Parent.Parent.Parent.BindingContext as Food;
                button.TextColor = Color.White;
                button.BackgroundColor = Color.Orange;
                button.Text = "Đã Thêm";
                foods.Add(food);
            }
            
        }

        public void Reset()
        {
            lsDS.ItemsSource = null;
            foods.Clear();
            getRestaurant(rid);
        }
    }
}