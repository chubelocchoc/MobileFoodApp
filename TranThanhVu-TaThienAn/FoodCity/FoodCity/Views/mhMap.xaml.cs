using System;


using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhMap : ContentPage
    {
        Map map;
        public mhMap()
        {
            
            InitializeComponent();
            map = new Map();
            map.IsShowingUser = true;
            this.Content = map;
            GeneratePins();
        }

        private void GeneratePins()
        {
            

            Pin pinTokyo = new Pin()
            {
                   
                Label = "ThanhVu-ThienAn",
                Address = "DH CNTT, ThuDuc, tp.HoChiMinh ",
                Type = PinType.Place,
                Position = new Position(10.869896, 106.803833)
            };
            map.Pins.Add(pinTokyo);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinTokyo.Position, Distance.FromMeters(300)));
        }
    }
}