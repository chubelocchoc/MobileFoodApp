using FoodCity.ModelDB;
using FoodCity.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhListRestaurant : ContentPage
    {
        private int type;
        public mhListRestaurant()
        {
            InitializeComponent();
        }

        public mhListRestaurant(int type)
        {
            this.type = type;
            InitializeComponent();
            InitButton(type);
            setTitle();
        }

        private void setTitle()
        {
            if (type == 1)
                this.Title = "Cơm";
            else if (type == 2)
                this.Title = "Món nước";
            else if (type == 3)
                this.Title = "Món chay";
            else if (type == 4)
                this.Title = "Ăn vặt";
            else if (type == 5)
                this.Title = "Lẩu";
            else if (type == 6)
                this.Title = "Đồ uống";
            else if (type == 7)
                this.Title = "Bánh Kem";
            else if (type == 9)
                this.Title = "Cháo";
            else if (type == 8)
                this.Title = "Tráng miệng";
            else
                return;
        }
        private async void InitButton(int type)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(type);

            btnGantoi.TextColor = Color.White;
            btnGantoi.BackgroundColor = Color.Orange;

            btnbanchay.TextColor = (Color)Resources["coTextMo"];
            btnbanchay.BackgroundColor = (Color)Resources["coWhite"];
            btndanhgia.TextColor = (Color)Resources["coTextMo"];
            btndanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btngiaonhanh.TextColor = (Color)Resources["coTextMo"];
            btngiaonhanh.BackgroundColor = (Color)Resources["coWhite"];
            lsDS.ItemsSource = dsfood;
        }
        private async void btnGantoi_Clicked(object sender, EventArgs e)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(type);


            btnGantoi.TextColor = Color.White;
            btnGantoi.BackgroundColor = Color.Orange;

            btnbanchay.TextColor = (Color)Resources["coTextMo"];
            btnbanchay.BackgroundColor = (Color)Resources["coWhite"];
            btndanhgia.TextColor = (Color)Resources["coTextMo"];
            btndanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btngiaonhanh.TextColor = (Color)Resources["coTextMo"];
            btngiaonhanh.BackgroundColor = (Color)Resources["coWhite"];
            lsDS.ItemsSource = dsfood;
        }
        private async void btnbanchay_Clicked(object sender, EventArgs e)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(type);


            btnbanchay.TextColor = Color.White;
            btnbanchay.BackgroundColor = Color.Orange;

            btnGantoi.TextColor = (Color)Resources["coTextMo"];
            btnGantoi.BackgroundColor = (Color)Resources["coWhite"];
            btndanhgia.TextColor = (Color)Resources["coTextMo"];
            btndanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btngiaonhanh.TextColor = (Color)Resources["coTextMo"];
            btngiaonhanh.BackgroundColor = (Color)Resources["coWhite"];
            lsDS.ItemsSource = dsfood;
        }
        private async void btndanhgia_Clicked(object sender, EventArgs e)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(type);


            btndanhgia.TextColor = Color.White;
            btndanhgia.BackgroundColor = Color.Orange;

            btnbanchay.TextColor = (Color)Resources["coTextMo"];
            btnbanchay.BackgroundColor = (Color)Resources["coWhite"];
            btnGantoi.TextColor = (Color)Resources["coTextMo"];
            btnGantoi.BackgroundColor = (Color)Resources["coWhite"];
            btngiaonhanh.TextColor = (Color)Resources["coTextMo"];
            btngiaonhanh.BackgroundColor = (Color)Resources["coWhite"];
            lsDS.ItemsSource = dsfood;
        }

        private async void btngiaonhanh_Clicked(object sender, EventArgs e)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(type);


            btngiaonhanh.TextColor = Color.White;
            btngiaonhanh.BackgroundColor = Color.Orange;

            btnbanchay.TextColor = (Color)Resources["coTextMo"];
            btnbanchay.BackgroundColor = (Color)Resources["coWhite"];
            btndanhgia.TextColor = (Color)Resources["coTextMo"];
            btndanhgia.BackgroundColor = (Color)Resources["coWhite"];
            btnGantoi.TextColor = (Color)Resources["coTextMo"];
            btnGantoi.BackgroundColor = (Color)Resources["coWhite"];
            lsDS.ItemsSource = dsfood;
        }

        private void lsDS_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Food food = (Food)e.SelectedItem;
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhRestaurant(food.rsdt) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }

        private void btnTroVe_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhHome() { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }
    }
}