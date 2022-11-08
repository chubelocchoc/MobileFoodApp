using FoodCity.AppConstrants;
using Xamarin.Forms;

namespace FoodCity
{
    public partial class App : Application
    {
        public App()
        {
            if (CredentialsStore.IsUserLogged())
            {
                MainPage = new NavigationPage(new Views.mhMainView());
            }
            else
                MainPage = new NavigationPage(new Views.mhLogin());
        }

        

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
