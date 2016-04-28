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
		protected HomeController HomeControler;

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
			panel.BackgroundColor = new Color (255, 255, 255, 255);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-05.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += cmdEstaciones_Click;
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-12.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton imngProgramas = Platform.Current.Create<IImageButton>();
			imngProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imngProgramas.Width = 25;
			imngProgramas.Height = 25;
			imngProgramas.Click += cmdProgramas_Click;
			grdMenu.SetContent(1, 2, imngProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 25;
			imgVirtuales.Height = 25;
			imgVirtuales.Click += cmdVirtuales_Click;
			grdMenu.SetContent(1, 3, imgVirtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("Estaciones Regionales", new Color(255, 79, 195, 247));
			panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = Platform.Current.Page.Width / 6;
				imgLogo.Height = lblTitulo.Height;
				imgLogo.Margin = new Thickness(0, 0, 10, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			IControl referencia = lblTitulo;

			foreach (Station estacion in estaciones)
			{
				IImageButton imgLogo = Platform.Current.Create<IImageButton>();
				imgLogo.LoadFromUrl(estacion.WebSiteUri);
				imgLogo.Click += Estacion_Click;
				imgLogo.Tag = estacion;
				imgLogo.Width = Constantes.AnchoIconos;
				imgLogo.Height = Constantes.AnchoIconos;

				//set margin for first iteration
				if (referencia == lblTitulo)
				{
					imgLogo.Margin = new Thickness(10, 10, 10, 10);
				}
				else
				{
					imgLogo.Margin = new Thickness(0, 10, 10, 10);
				}

				panel.Add(imgLogo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

				referencia = imgLogo;

				ILabelButton lblNombre = Platform.Current.Create<ILabelButton>();
				lblNombre.Click += Estacion_Click;
				lblNombre.Text = estacion.Name;
				lblNombre.Tag = estacion;
				lblNombre.Bold = true;
				lblNombre.FontSize = Constantes.FontSize2;
				lblNombre.FontColor = Constantes.FontColor2;
				lblNombre.Width = Platform.Current.Page.Width - (Constantes.AnchoIconos * 3) + 30;
				panel.Add(lblNombre, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogo);

				ILabelButton lblDescripcion = Platform.Current.Create<ILabelButton>();
				lblDescripcion.Click += Estacion_Click;
				lblDescripcion.Text = estacion.Description;
				lblDescripcion.Tag = estacion;
				lblDescripcion.FontSize = Constantes.FontSize3;
				lblDescripcion.FontColor = Constantes.FontColor3;
				lblDescripcion.Width = lblNombre.Width;
				panel.Add(lblDescripcion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombre);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon2--45.png"));
				imgPlay.Click += Estacion_Click;
				imgPlay.Tag = estacion;
				imgPlay.Width = Constantes.AnchoIconos;
				imgPlay.Height = Constantes.AnchoIconos;

				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblNombre);
			}

			Platform.Current.Page.Content = panel;
			Cache = panel;
		}

		public RegionalesController(HomeController home)
		{
			HomeControler = home;
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdProgramas_Click(object sender, EventArgs e)
		{
			this.Finish();
			new ProgramasController (HomeControler).Start ();
		}

		private void cmdVirtuales_Click(object sender, EventArgs e)
		{
			this.Finish();
			new VirtualesController (HomeControler).Start ();
		}

		public void Estacion_Click(object sender, EventArgs e)
		{
			IControl control = (IControl)sender;
			Station estacion = (Station)control.Tag;
			HomeControler.Station = estacion;
			this.Finish ();
		}
	}
}

