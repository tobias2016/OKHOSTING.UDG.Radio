using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OKHOSTING.UDG.Radio.UI.Xamarin
{
    public class App : Application
    {
        public App()
        {
			OKHOSTING.UI.Xamarin.Forms.Platform.Current.Page = new OKHOSTING.UI.Xamarin.Forms.Page();
			MainPage = (global::Xamarin.Forms.Page) OKHOSTING.UI.Xamarin.Forms.Platform.Current.Page;
			new IndexController().Start();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
