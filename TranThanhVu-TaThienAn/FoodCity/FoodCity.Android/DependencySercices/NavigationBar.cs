using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodCity.AppConstrants;
using FoodCity.Droid.DependencySercices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
[assembly:Dependency(typeof(NavigationBar))]
namespace FoodCity.Droid.DependencySercices
{
    class NavigationBar : INavigationBar
    {
        private int attributes;

        [Obsolete]
        public void HideNavigationBar()
        {

            var activity = Forms.Context as Activity;
            attributes = (int)activity.Window.DecorView.SystemUiVisibility;
            attributes |= (int)SystemUiFlags.LayoutHideNavigation;
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)attributes;
        }

        [Obsolete]
        public void ShowNavigationBar()
        {
            var activity = (Activity)Forms.Context;
            var attributes = activity.Window.Attributes;
            //_originalFlags = attributes.Flags;
            activity.Window.Attributes = attributes;
        }
    }
}