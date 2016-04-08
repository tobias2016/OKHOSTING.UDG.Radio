using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OKHOSTING.UDG.Radio.UI.Xamarin.Droid
{
	public class AudioPlayer : OKHOSTING.UDG.Radio.UI.IAudioPlayer
    {
        protected Uri _Source;

        public Uri Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;

                Intent intent = new Intent(StreamingBackgroundService.ActionSource);
                intent.PutExtra("source", value.ToString());
                global::Android.App.Application.Context.StartService(intent);
            }
        }

        public void Pause()
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionPause);
            global::Android.App.Application.Context.StartService(intent);
        }

        public void Play()
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionPlay);
            global::Android.App.Application.Context.StartService(intent);
        }

        public void Stop()
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionStop);
            global::Android.App.Application.Context.StartService(intent);
        }
    }
}