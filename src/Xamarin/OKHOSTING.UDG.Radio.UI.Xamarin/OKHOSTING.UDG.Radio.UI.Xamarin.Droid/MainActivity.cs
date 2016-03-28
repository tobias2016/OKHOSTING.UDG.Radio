﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OKHOSTING.UDG.Radio.UI.Xamarin.Droid
{
    [Activity(Label = "OKHOSTING.UDG.Radio.UI.Xamarin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadApplication(new App());
        }
    }
}
