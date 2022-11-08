
using System;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhWelcome : ContentPage
    {
        public mhWelcome()
        {
            InitializeComponent();
        }

        private void btnBatdau_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.CurrentPage = tabbedPage.Children[0];
        }
    }
}