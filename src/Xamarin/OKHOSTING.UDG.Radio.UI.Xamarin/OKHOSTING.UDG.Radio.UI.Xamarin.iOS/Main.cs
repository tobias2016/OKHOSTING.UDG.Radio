using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace OKHOSTING.UDG.Radio.UI.Xamarin.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			Core.BaitAndSwitch.PlatformSpecificTypes.Add (typeof(Streaming.IAudioPlayer), typeof(Streaming.Xamarin.iOS.AudioPlayer));
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}