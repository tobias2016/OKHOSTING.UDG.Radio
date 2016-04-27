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

			IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += cmdHome_Click;
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			imgRegionales.Click += cmdEstaciones_Click;
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			cmdProgramas.Width = 25;
			cmdProgramas.Height = 25;
			cmdProgramas.Click += cmdProgramas_Click;
			grdMenu.SetContent(1, 2, cmdProgramas);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-10.png"));
			Virtuales.Width = 25;
			Virtuales.Height = 25;
			grdMenu.SetContent(1, 3, Virtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("¡PROXIMAMENTE VIRTUALES!", new Color(230, 103, 57, 183));
			panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = Platform.Current.Page.Width / 6;
				imgLogo.Height = lblTitulo.Height;
				imgLogo.Margin = new Thickness (0, 0, 10, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			Platform.Current.Page.Title = "Virtuales";
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

