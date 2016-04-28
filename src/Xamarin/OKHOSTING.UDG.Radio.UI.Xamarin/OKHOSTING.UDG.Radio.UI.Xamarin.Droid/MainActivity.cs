using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OKHOSTING.UDG.Radio.UI.Xamarin.Droid
{
	[Activity(Label = "Radio UDG", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            OKHOSTING.Streaming.Xamarin.Android.StreamingBackgroundService.ReturnTo = typeof(MainActivity);

            global::Xamarin.Forms.Forms.Init(this, bundle);
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (OKHOSTING.UI.Platform.Current != null && OKHOSTING.UI.Platform.Current.Page != null)
            {
                return;
            }

            LoadApplication(new App());
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            OKHOSTING.UI.Platform.Current.Controller.Finish();
            OKHOSTING.UI.Platform.Current.Finish();

            base.OnDestroy();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

		public override void OnBackPressed()
		{
			//no hacer nada
			//base.OnBackPressed();
		}
	}
}

