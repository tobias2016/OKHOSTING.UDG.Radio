﻿using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio.UI
{
    public class SplashScreenScontroller: Controller
    {
        public override void Start()
        {
            base.Start();

            IImage logo = Platform.Current.Create<IImage>();
            logo.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--01.png"));
            logo.Width = Platform.Current.Page.Width;
            logo.Height = Platform.Current.Page.Height;

            Platform.Current.Page.Title = "Radio Universidad de Guaralajara";
            Platform.Current.Page.Content = logo;

            System.Threading.Tasks.Task.Delay(1000).Wait();

            Finish();
            new HomeController().Start();
        }
    }
}