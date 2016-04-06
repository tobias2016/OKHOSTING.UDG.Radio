using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI 
{
	public class VirtualesController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		protected IImage BackgroundImage;
		HomeController homecontroller;

		public override void Start()
		{
			base.Start ();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color (255, 0, 0, 0);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			IGrid grdMenu = Platform.Current.Create<IGrid>();
			grdMenu.RowCount = 1;
			grdMenu.ColumnCount = 4;
			if (Platform.Current.Page.Width > 600)
			{
				grdMenu.Height = 30;
			} 
			else if (Platform.Current.Page.Width < 600)
			{
				grdMenu.Height = 25;
			}
			grdMenu.Width = Platform.Current.Page.Width;
			grdMenu.BackgroundColor = new Color(255, 0, 0, 0);
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += cmdHome_Click;
			grdMenu.SetContent (0, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			imgRegionales.Click += cmdEstaciones_Click;
			grdMenu.SetContent (0, 1, imgRegionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			cmdProgramas.Width = 25;
			cmdProgramas.Height = 25;
			cmdProgramas.Click += cmdProgramas_Click;
			grdMenu.SetContent (0, 2, cmdProgramas);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-10.png"));
			Virtuales.Width = 25;
			Virtuales.Height = 25;
			grdMenu.SetContent (0, 3, Virtuales);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "¡PROXIMAMENTE VIRTUALES!";
			lblLabel.Width = Platform.Current.Page.Width;
			if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
			{
				lblLabel.Height = 50;
				lblLabel.FontSize = 14;
			} 
			else if (Platform.Current.Page.Width < 310)
			{
				lblLabel.Height = 40;
				lblLabel.FontSize = 12;
			}
			else if (Platform.Current.Page.Width > 600)
			{
				lblLabel.Height = 70;
				lblLabel.FontSize = 19;
			}
			lblLabel.Bold = true;
			lblLabel.FontColor = new Color(255, 255, 255, 255);
			lblLabel.BackgroundColor = new Color (230, 103, 57, 183);
			lblLabel.Margin = new Thickness (0, 25, 0, 0);
			lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblLabel.TextVerticalAlignment = VerticalAlignment.Center;
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					imgLogo.Width = 70;
					imgLogo.Height = 50;
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					imgLogo.Width = 60;
					imgLogo.Height = 40;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgLogo.Width = 90;
					imgLogo.Height = 70;
				}
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
				BackgroundImage.Height = Platform.Current.Page.Height * 1.2;
			}
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = panel;
		}

		public VirtualesController(HomeController home)
		{
			homecontroller = home;
		}

		private void cmdHome_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdProgramas_Click(object sender, EventArgs e)
		{
			this.Finish();
			new ProgramasController (homecontroller).Start ();
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
			new RegionalesController (homecontroller).Start ();
		}
	}
}

