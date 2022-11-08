﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android.Views;
using Android;

namespace FoodCity.Droid
{
    [Activity(Label = "FoodCity", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        const int RequestLocationId = 0;

        readonly string[] LocactionPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };
        protected override void OnStart()
        {
            base.OnStart();
            if((int)Build.VERSION.SdkInt >= 23)
            {
                if(CheckSelfPermission(Manifest.Permission.AccessFineLocation)!= Permission.Granted)
                {
                    RequestPermissions(LocactionPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());

            ImmersiveMode();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if((grantResults.Length==1) && (grantResults[0] == (int)Permission.Granted))
                {
                    // Permissions granted - display a message.
                }
                else
                {
                    // Permissions denied - display a message.
                }
            }
            else
            {
                //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
            

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
        public void ImmersiveMode()
        {
            int uiOptions = (int)(Forms.Context as Activity).Window.DecorView.SystemUiVisibility;
            //uiOptions |= (int)SystemUiFlags.Fullscreen;
            //uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.LightNavigationBar;
            (Forms.Context as Activity).Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

    }
}