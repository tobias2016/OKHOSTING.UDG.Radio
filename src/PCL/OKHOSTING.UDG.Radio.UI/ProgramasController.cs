﻿using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{
	public class ProgramasController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		protected IImage BackgroundImage;

		public override void Start()
		{
			base.Start ();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color (255, 0, 0, 0);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			IGrid grdMenu = Platform.Current.Create<IGrid>();
			grdMenu.RowCount = 1;
			grdMenu.ColumnCount = 4;
			grdMenu.Height = 15;
			grdMenu.Width = Platform.Current.Page.Width;
			grdMenu.BackgroundColor = new Color(255, 0, 0, 0);
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Home = Platform.Current.Create<IImageButton>();
			Home.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			Home.Width = 20;
			Home.Height = 20;
			Home.Click += (object sender, EventArgs e) => new HomeController().Start();
			grdMenu.SetContent (0, 0, Home);

			IImageButton Regionales = Platform.Current.Create<IImageButton>();
			Regionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			Regionales.Width = 20;
			Regionales.Height = 20;
			//Regionales.Click += (object sender, EventArgs e) => new RegionalesController(this).Start();
			grdMenu.SetContent (0, 1, Regionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-08.png"));
			cmdProgramas.Width = 20;
			cmdProgramas.Height = 20;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent (0, 2, cmdProgramas);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			Virtuales.Width = 20;
			Virtuales.Height = 20;
			Virtuales.Click += (object sender, EventArgs e) => new VirtualesController ().Start ();
			grdMenu.SetContent (0, 3, Virtuales);

			/*
			IGrid bgdTitulo = Platform.Current.Create<IGrid>();
			bgdTitulo.RowCount = 1;
			bgdTitulo.ColumnCount = 4;
			bgdTitulo.Height = 40;
			bgdTitulo.Width = Platform.Current.Page.Width;
			bgdTitulo.BackgroundColor = new Color(230, 255, 143, 0);
			panel.Add(bgdTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.CenterWith);
			*/

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "¡PROXIMAMENTE PROGRAMAS!";
			lblLabel.Width = Platform.Current.Page.Width;
			lblLabel.Height = 40;
			lblLabel.FontSize = 12;
			lblLabel.Bold = true;
			lblLabel.FontColor = new Color(255, 255, 255, 255);
			lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblLabel.TextVerticalAlignment = VerticalAlignment.Center;
			lblLabel.BackgroundColor = new Color (230, 255, 143, 0);
			lblLabel.Margin = new Thickness (0, 15, 0, 0);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = 60;
				imgLogo.Height = 60;
				imgLogo.Margin = new Thickness (0, -10, 0, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblLabel);
			}

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--49.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			if (Platform.Current.Page.Width > 500)
			{
				BackgroundImage.Height = Platform.Current.Page.Height * 2.7;
			} 
			else if (Platform.Current.Page.Width < 500)
			{
				BackgroundImage.Height = Platform.Current.Page.Height * 1.3;
			}
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			/*
			IGrid pgrAcordeon = Platform.Current.Create<IGrid>();
			pgrAcordeon.RowCount = 1;
			pgrAcordeon.ColumnCount = 4;
			pgrAcordeon.Height = 50;
			pgrAcordeon.Width = Platform.Current.Page.Width;
			pgrAcordeon.BackgroundColor = new Color(1, 255, 143, 0);
			pgrAcordeon.Margin = new Thickness (0, 15, 0, 15);
			panel.Add(pgrAcordeon, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, bgdTitulo);

			IImage imgAcordeon = Platform.Current.Create<IImage>();
			imgAcordeon.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--19.png"));
			imgAcordeon.Width = 41;
			imgAcordeon.Height = 41;
			imgAcordeon.Margin = new Thickness(10, 10, 10, 5);
			panel.Add(imgAcordeon, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, pgrAcordeon);

			ILabelButton Programa1 = Platform.Current.Create<ILabelButton>();
			Programa1.Click += (object sender, EventArgs e) => new AcordeonController().Start();
			Programa1.Text = "El acordeon";
			Programa1.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa1, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgAcordeon);

			IImage arvAcordeon = Platform.Current.Create<IImage>();
			arvAcordeon.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--28.png"));
			arvAcordeon.Width = 41;
			arvAcordeon.Height = 41;
			arvAcordeon.Margin = new Thickness(20, 0, 0, 0);
			panel.Add(arvAcordeon, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.CenterWith, Programa1);

			ILabelButton Programa2 = Platform.Current.Create<ILabelButton>();
			//Programa2.Click += Programa2_Click;
			Programa2.Text = "Teleferico";
			Programa2.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabelButton Programa3 = Platform.Current.Create<ILabelButton>();
			//Programa3.Click += Programa3_Click;
			Programa3.Text = "El despeñadero";
			Programa3.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabelButton Programa4 = Platform.Current.Create<ILabelButton>();
			//Programa4.Click += Programa4_Click;
			Programa4.Text = "El ritual de lo habitual";
			Programa4.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabelButton Programa5 = Platform.Current.Create<ILabelButton>();
			Programa5.Text = "El expreso de las 10";
			Programa5.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);
			*/

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = panel;
		}

	}
}

