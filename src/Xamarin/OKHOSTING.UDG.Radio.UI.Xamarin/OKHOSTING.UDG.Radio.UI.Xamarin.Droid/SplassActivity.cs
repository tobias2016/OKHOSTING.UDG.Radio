using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio.UI.Xamarin.Droid
{
	[Activity(Label = "Radio UDG", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplassActivity : Android.App.Activity
	{
		protected override void OnStart()
		{
			base.OnStart();

			base.SetContentView (Resource.Layout.SplashLayout);

			Task startupWork = new Task(() => {
				Task.Delay(1000);  // Simulate a bit of startup work.
			});

			startupWork.ContinueWith(t => {
				StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			}, TaskScheduler.FromCurrentSynchronizationContext());

			startupWork.Start();
		}
	}
}