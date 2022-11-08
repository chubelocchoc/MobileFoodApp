using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FoodCity.Models;
using FoodCity.ModelDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodCity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mhHome : ContentPage
    {
        private Advertisement adv;
        private async void getQuangcao()
        {
            List<Advertisement> Quangcao = await AdvertisementDB.getAdvertisement();
            carQuangcao.ItemsSource = Quangcao;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                carQuangcao.Position = (carQuangcao.Position + 1) % Quangcao.Count;
                return true;
            }));
        }

        private Frame createFood(Food f)
        {
            ImageButton image = new ImageButton();
            image.Source = f.hurl;
            image.Padding = 0;
            image.Margin = 0;
            image.HeightRequest = 130;
            image.HorizontalOptions = LayoutOptions.CenterAndExpand;
            image.CommandParameter = f.rsdt;
            image.Clicked += Image_Clicked;

            Grid gridFirst = new Grid
            {
                RowDefinitions =
                    {
                        new RowDefinition ()
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(15) },
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                    }

            };
            gridFirst.Children.Add(new Image
            {
                Source = "ResIcon.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Scale = 1.2
            }, 0, 0);
            gridFirst.Children.Add(new Label
            {
                Text = f.fname,
                HorizontalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                TextColor = Color.Black,
                FontSize = 14
            }, 1, 0);

            Grid gridSecond = new Grid
            {
                RowDefinitions =
                    {
                        new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(10)},
                        new ColumnDefinition{Width = new GridLength(10)},
                        new ColumnDefinition{Width = new GridLength(2)},
                        new ColumnDefinition{Width = new GridLength(10)},
                        new ColumnDefinition{Width = new GridLength(35)},
                        new ColumnDefinition{Width = new GridLength(2)},
                        new ColumnDefinition{Width = new GridLength(10)},
                        new ColumnDefinition{Width = new GridLength(35)},
                    }
            };
            gridSecond.Children.Add(new Image
            {
                Source = "starIcon.png",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Scale = 1.5,
            }, 0, 0);
            gridSecond.Children.Add(new Label
            {
                Text = f.ftype.ToString(),
                HorizontalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 10,
            }, 1, 0);
            gridSecond.Children.Add(new Label
            {
                Text = "|"
            }, 2, 0);
            gridSecond.Children.Add(new Image
            {
                Source = "mapIcon.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Scale = 1.3,
                Margin = 0
            }, 3, 0);
            gridSecond.Children.Add(new Label
            {
                Text = "1.5 km",
                FontSize = 10
            }, 4, 0);
            gridSecond.Children.Add(new Label
            {
                Text = "|"
            }, 5, 0);
            gridSecond.Children.Add(new Image
            {
                Source = "timeIcon.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Scale = 1.3
            }, 6, 0);
            gridSecond.Children.Add(new Label
            {
                Text = "20 phut",
                FontSize = 10
            }, 7, 0);

            gridFirst.Padding = 0;
            gridSecond.Padding = 0;
            StackLayout stackLayout = new StackLayout { Children = { image, gridFirst, gridSecond }};
            stackLayout.Padding = 5;
            Frame frame = new Frame();
            //frame.WidthRequest = 165;
            frame.CornerRadius = 5;
            frame.Padding = 0;
            frame.HorizontalOptions = LayoutOptions.Center;
            frame.Content = stackLayout;
            return frame;
        }

        private void Image_Clicked(object sender, EventArgs e)
        {
            ImageButton image = (ImageButton)sender;

            
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhRestaurant(image.CommandParameter.ToString()) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
            //tabbedPage.FindByName<ContentPage>("mhHome").IsVisible = true;
            
            //Navigation.PushAsync(new mhRestaurant(image.CommandParameter.ToString()));
        }

        private async void FirstScroll()
        {
            List<Food> dsfood = await FoodDB.getFoodByType(6);

            for (int i =0; i<dsfood.Count(); i++)
            {
                Frame frame = createFood(dsfood[i]);
                lsFirstScroll.Children.Add(frame);
            }

        }

        private async void SecondScroll()
        {
            List<Food> dsfood = await FoodDB.getFoodByType(2);

            for (int i = 0; i < dsfood.Count(); i++)
            {
                Frame frame = createFood(dsfood[i]);
                lsSecondScroll.Children.Add(frame);
            }
        }
        private async void InitButton()
        {
            List<Food> dsfood = await FoodDB.getFoodByType(3);

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
        public mhHome()
        {
            InitializeComponent();
            getQuangcao();
            FirstScroll();
            SecondScroll();
            InitButton();
        }

        private async void btnGantoi_Clicked(object sender, EventArgs e)
        {
            List<Food> dsfood = await FoodDB.getFoodByType(4);


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
            List<Food> dsfood = await FoodDB.getFoodByType(5);


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
            List<Food> dsfood = await FoodDB.getFoodByType(6);


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
            List<Food> dsfood = await FoodDB.getFoodByType(7);


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

        private void btnimagevitri_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new mhMap());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhRestaurant(adv.rsdt) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }

        private void Com_Clicked(object sender, EventArgs e)
        {
            if (sender == Com)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(1) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Monnuoc)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(2) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Monchay)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(3) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Anvat)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(4) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Lau)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(5) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Douong)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(6) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Banhkem || sender == Banh)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(7) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Trangmieng)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(8) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else if (sender == Chao)
            {
                TabbedPage tabbedPage = this.Parent as TabbedPage;
                tabbedPage.Children.Insert(1, new mhListRestaurant(9) { IconImageSource = "home.png" });
                tabbedPage.Children.RemoveAt(0);
            }
            else
                return;
        }

        private void btnXemChude1_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhListRestaurant(6) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }
        private void btnXemChude2_Clicked(object sender, EventArgs e)
        {
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhListRestaurant(5) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }

        private void carQuangcao_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            adv = (Advertisement)e.CurrentItem;
        }

        private void lsDS_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Food food = (Food)e.SelectedItem;
            TabbedPage tabbedPage = this.Parent as TabbedPage;
            tabbedPage.Children.Insert(1, new mhRestaurant(food.rsdt) { IconImageSource = "home.png" });
            tabbedPage.Children.RemoveAt(0);
        }

        private async void sbTimkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sbTimkiem.Text.Length > 0)
            {
                lsDS.ItemsSource = null;
                carQuangcao.IsVisible = false;
                intercatorView.IsVisible = false;
                gridTheLoai.IsVisible = false;
                gridFirst.IsVisible = false;
                scrollFirst.IsVisible = false;
                gridSecond.IsVisible = false;
                scrollSecond.IsVisible = false;
                frButton.IsVisible = false;
                List<Food> dsfood = await FoodDB.getFoodBySearch(sbTimkiem.Text);
                lsDS.ItemsSource = dsfood;
            }
            else
            {
                lsDS.ItemsSource = null;
                carQuangcao.IsVisible = true;
                intercatorView.IsVisible = true;
                gridTheLoai.IsVisible = true;
                gridFirst.IsVisible = true;
                scrollFirst.IsVisible = true;
                gridSecond.IsVisible = true;
                scrollSecond.IsVisible = true;
                frButton.IsVisible = true;
                InitButton();
            }
        }
    }
}