using FoodCity.ModelDB;
using FoodCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhSearch : ContentPage
    {
        public mhSearch()
        {
            InitializeComponent();
        }

        public mhSearch(string txt)
        {
            InitializeComponent();
            Init(txt);
        }

        private async void Init(string txtSearch)
        {
            try
            {
                List<Food> dsfood = await FoodDB.getFoodBySearch(txtSearch);
                lsDS.ItemsSource = dsfood;
                this.Title = txtSearch;
            }
            catch
            {
                await DisplayAlert("Thông báo", "error", "ok");
            }
        }

        private void lsDS_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Food food = (Food)e.SelectedItem;
            
            Navigation.RemovePage(this);
            

            //Navigation.PopAsync();
            //TabbedPage tabbedPage = this.Parent as TabbedPage;
            //tabbedPage.Children.Insert(1, new mhRestaurant(food.rsdt) { IconImageSource = "home.png" });
            //tabbedPage.Children.RemoveAt(0);
        }
    }
}