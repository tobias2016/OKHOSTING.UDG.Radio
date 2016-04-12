using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{
	public class RegionalesController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		protected IImage imgBackgroundImage;
		protected HomeController homecontroler;

		protected static IControl Cache;

		public override void Start()
		{
			base.Start ();

			Platform.Current.Page.Title = "Selecciona una estación";

			if (Cache != null) 
			{
				Platform.Current.Page.Content = Cache;
				return;
			}

			IList<Station> estaciones = new List<Station> ();
			Station estacion1 = new Station ();
			estacion1.Id = 1;
			estacion1.Name = "AMECA";
			estacion1.Description = "XHUDG 105.5 F.M.";
			estacion1.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--11.png");
			estacion1.StramingUri = new Uri ("http://148.202.87.222:8000/;stream/1");

			estaciones.Add (estacion1);

			Station estacion2 = new Station ();
			estacion2.Id = 2;
			estacion2.Name = "GUADALAJARA";
			estacion2.Description = "XHUDG 104.3 F.M.";
			estacion2.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--20.png");
			estacion2.StramingUri = new Uri ("http://148.202.165.1:8000/;stream/1");

			estaciones.Add (estacion2);

			Station estacion3 = new Station ();
			estacion3.Id = 1;
			estacion3.Name = "AUTLAN";
			estacion3.Description = "XHANU 102.3 F.M.";
			estacion3.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--40.png");
			estacion3.StramingUri = new Uri ("http://148.202.114.39:8000/;stream/1");

			estaciones.Add (estacion3);

			Station estacion4 = new Station ();
			estacion4.Id = 1;
			estacion4.Name = "CD. GUZMÁN";
			estacion4.Description = "XHUGG 94.3 F.M.";
			estacion4.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--23.png");
			estacion4.StramingUri = new Uri ("http://148.202.119.233:8080/;stream/1");

			estaciones.Add (estacion4);

			Station estacion5 = new Station ();
			estacion5.Id = 1;
			estacion5.Name = "COLOTLÁN";
			estacion5.Description = "XHUGC 104.7 F.M.";
			estacion5.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--44.png");
			estacion5.StramingUri = new Uri ("http://148.202.79.112:8000/;stream/1");

			estaciones.Add (estacion5);

			Station estacion6 = new Station ();
			estacion6.Id = 1;
			estacion6.Name = "LAGOS DE MORENO";
			estacion6.Description = "XHUGL 104.7 F.M.";
			estacion6.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--43.png");
			estacion6.StramingUri = new Uri ("http://148.202.62.3:8000/;stream/1");

			estaciones.Add (estacion6);

			Station estacion7 = new Station ();
			estacion7.Id = 1;
			estacion7.Name = "OCOTLÁN";
			estacion7.Description = "XHUGO 107.9 F.M.";
			estacion7.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--41.png");
			estacion7.StramingUri = new Uri ("http://148.202.148.5:4040/;stream/1");

			estaciones.Add (estacion7);

			Station estacion8 = new Station ();
			estacion8.Id = 1;
			estacion8.Name = "PUERTO VALLARTA";
			estacion8.Description = "XHUGP 104.3 F.M.";
			estacion8.WebSiteUri = new Uri ("http://radioudg.okhosting.com/images-old/icon2--42.png");
			estacion8.StramingUri = new Uri ("http://148.202.110.152:8000/;stream/1");

			estaciones.Add (estacion8);

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
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-05.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += cmdEstaciones_Click;
			grdMenu.SetContent (0, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-12.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			grdMenu.SetContent (0, 1, imgRegionales);

			IImageButton imngProgramas = Platform.Current.Create<IImageButton>();
			imngProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imngProgramas.Width = 25;
			imngProgramas.Height = 25;
			imngProgramas.Click += cmdProgramas_Click;
			grdMenu.SetContent (0, 2, imngProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 25;
			imgVirtuales.Height = 25;
			imgVirtuales.Click += cmdVirtuales_Click;
			grdMenu.SetContent (0, 3, imgVirtuales);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Estaciones Regionales";
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
			lblLabel.BackgroundColor = new Color (255, 79, 195, 247);
			lblLabel.FontColor = new Color(255, 0, 0, 0);
			lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblLabel.TextVerticalAlignment = VerticalAlignment.Center;
			lblLabel.Margin = new Thickness (0, 25, 0, 0);
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

			imgBackgroundImage = Platform.Current.Create<IImage>();
			imgBackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--50.png"));
			imgBackgroundImage.Width = Platform.Current.Page.Width;

			if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 500)
			{
				imgBackgroundImage.Height = Platform.Current.Page.Height * 1.2;
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				imgBackgroundImage.Height = Platform.Current.Page.Height * 2;
			} 
			else if (Platform.Current.Page.Width > 500)
			{
				imgBackgroundImage.Height = Platform.Current.Page.Height * 2.7;
			}
			//panel.Add(imgBackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			IControl referencia = lblLabel;

			foreach (Station etacion in estaciones) 
			{
				IGrid grdEstacion = Platform.Current.Create<IGrid>();
				grdEstacion.RowCount = 1;
				grdEstacion.ColumnCount = 4;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					grdEstacion.Height = 70;
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					grdEstacion.Height = 50;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					grdEstacion.Height = 90;
				}
				grdEstacion.Width = Platform.Current.Page.Width;
				grdEstacion.BackgroundColor = new Color(40, 120, 120, 120);
				grdEstacion.Margin = new Thickness (0, 20, 0, 0);
				panel.Add(grdEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

				referencia = grdEstacion;

                IImageButton imgEstacion = Platform.Current.Create<IImageButton>();
				imgEstacion.LoadFromUrl(etacion.WebSiteUri);
				imgEstacion.Click += Estacion_Click;
				imgEstacion.Tag = etacion;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					imgEstacion.Width = 50;
					imgEstacion.Height = 50;
					imgEstacion.Margin = new Thickness(40, 10, 50, 5);
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					imgEstacion.Width = 35;
					imgEstacion.Height = 35;
					imgEstacion.Margin = new Thickness(30, 10, 20, 5);
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgEstacion.Width = 70;
					imgEstacion.Height = 70;
					imgEstacion.Margin = new Thickness(35, 10, 60, 5);
				}
				panel.Add(imgEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdEstacion);

				ILabelButton lblNombreEstacion = Platform.Current.Create<ILabelButton>();
				lblNombreEstacion.Click += Estacion_Click;
				lblNombreEstacion.Text = etacion.Name;
				lblNombreEstacion.Tag = etacion;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					lblNombreEstacion.FontSize = 13;
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					lblNombreEstacion.FontSize = 11;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					lblNombreEstacion.FontSize = 16;
				}
				lblNombreEstacion.Bold = true;
				lblNombreEstacion.FontColor = new Color(255, 255, 255, 255);
				panel.Add(lblNombreEstacion, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgEstacion);

				ILabelButton lblDescripcionEstacion = Platform.Current.Create<ILabelButton>();
				lblDescripcionEstacion.Click += Estacion_Click;
				lblDescripcionEstacion.Text = etacion.Description;
				lblDescripcionEstacion.Tag = etacion;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					lblDescripcionEstacion.FontSize = 11;
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					lblDescripcionEstacion.FontSize = 9;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					lblDescripcionEstacion.FontSize = 14;
				}
				lblDescripcionEstacion.FontColor = new Color (255, 150, 150, 150);
				panel.Add(lblDescripcionEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombreEstacion);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon2--45.png"));
				imgPlay.Click += Estacion_Click;
				imgPlay.Tag = etacion;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					imgPlay.Width = 30;
					imgPlay.Height = 30;
					imgPlay.Margin = new Thickness (0, 0, 20, 0);
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					imgPlay.Width = 20;
					imgPlay.Height = 20;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgPlay.Width = 50;
					imgPlay.Height = 50;
					imgPlay.Margin = new Thickness (0, 0, 50, 0);
				}
				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, grdEstacion);
			}

			Platform.Current.Page.Content = panel;
			Cache = panel;
		}

		public RegionalesController(HomeController h)
		{
			homecontroler = h;
		}

		public override void Resize()
		{
			base.Resize();

            if (imgBackgroundImage != null)
            {
                imgBackgroundImage.Width = Platform.Current.Page.Width;
                imgBackgroundImage.Height = Platform.Current.Page.Height;
            }
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdProgramas_Click(object sender, EventArgs e)
		{
			this.Finish();
			new ProgramasController (homecontroler).Start ();
		}

		private void cmdVirtuales_Click(object sender, EventArgs e)
		{
			this.Finish();
			new VirtualesController (homecontroler).Start ();
		}

		public void Estacion_Click(object sender, EventArgs e)
		{
			IControl control = (IControl)sender;
			Station estacion = (Station)control.Tag;
			homecontroler.Station = estacion;
			this.Finish ();
		}
	}
}

