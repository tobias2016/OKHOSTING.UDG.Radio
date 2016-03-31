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

		public override void Start()
		{
			base.Start ();

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
			estacion2.StramingUri = new Uri ("http://148.202.165.2/videoPlayer/swfs/StrobeMediaPlayback.swf");

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
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			imgBackgroundImage = Platform.Current.Create<IImage>();
			imgBackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--50.png"));
			imgBackgroundImage.Width = Platform.Current.Page.Width;
			imgBackgroundImage.Height = Platform.Current.Page.Height * 2;
			panel.Add(imgBackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IGrid grdMenu = Platform.Current.Create<IGrid>();
			grdMenu.RowCount = 1;
			grdMenu.ColumnCount = 4;
			grdMenu.Height = 30;
			grdMenu.Width = Platform.Current.Page.Width;
			grdMenu.BackgroundColor = new Color(255, 0, 0, 0);
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-05.png"));
			imgHome.Width = 20;
			imgHome.Height = 20;
			imgHome.Click += (object sender, EventArgs e) => new HomeController().Start();
			grdMenu.SetContent (0, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-12.png"));
			imgRegionales.Width = 20;
			imgRegionales.Height = 20;
			grdMenu.SetContent (0, 1, imgRegionales);

			IImageButton imngProgramas = Platform.Current.Create<IImageButton>();
			imngProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imngProgramas.Width = 20;
			imngProgramas.Height = 20;
			imngProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent (0, 2, imngProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 20;
			imgVirtuales.Height = 20;
			imgVirtuales.Click += (object sender, EventArgs e) => new VirtualesController ().Start ();
			grdMenu.SetContent (0, 3, imgVirtuales);

			/*
			IGrid grdTitulo = Platform.Current.Create<IGrid>();
			grdTitulo.RowCount = 1;
			grdTitulo.ColumnCount = 4;
			grdTitulo.Height = 40;
			grdTitulo.Width = Platform.Current.Page.Width;
			grdTitulo.BackgroundColor = new Color(250, 79, 195, 247);
			grdTitulo.Margin = new Thickness (0, 0, 20, 0);
			panel.Add(grdTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, menu);
			*/

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Estaciones Regionales";
			lblLabel.Width = Platform.Current.Page.Width;
			lblLabel.Height = 40;
			lblLabel.FontSize = 11;
			lblLabel.Bold = true;
			lblLabel.BackgroundColor = new Color (255, 79, 195, 247);
			lblLabel.FontColor = new Color(255, 0, 0, 0);
			lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblLabel.TextVerticalAlignment = VerticalAlignment.Center;
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			IImage imgLogo = Platform.Current.Create<IImage> ();
			imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
			imgLogo.Width = 60;
			imgLogo.Height = 40;
			//imgLogo.Margin = new Thickness (5, -17, 0, 0);
			panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblLabel);

			IControl referencia = lblLabel;

			foreach (Station etacion in estaciones) 
			{
				IGrid grdEstacion = Platform.Current.Create<IGrid>();
				grdEstacion.RowCount = 1;
				grdEstacion.ColumnCount = 4;
				grdEstacion.Height = 50;
				grdEstacion.Width = Platform.Current.Page.Width;
				grdEstacion.BackgroundColor = new Color(40, 120, 120, 120);
				grdEstacion.Margin = new Thickness (0, 20, 0, 0);
				panel.Add(grdEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

				referencia = grdEstacion;

                IImageButton imgEstacion = Platform.Current.Create<IImageButton>();
				imgEstacion.LoadFromUrl(etacion.WebSiteUri);
				imgEstacion.Click += Estacion_Click;
				imgEstacion.Tag = etacion;
				imgEstacion.Width = 35;
				imgEstacion.Height = 35;
				imgEstacion.Margin = new Thickness(30, 10, 20, 5);
				panel.Add(imgEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdEstacion);

				ILabelButton lblNombreEstacion = Platform.Current.Create<ILabelButton>();
				lblNombreEstacion.Click += Estacion_Click;
				lblNombreEstacion.Text = etacion.Name;
				lblNombreEstacion.Tag = etacion;
				lblNombreEstacion.FontSize = 11;
				lblNombreEstacion.Bold = true;
				lblNombreEstacion.FontColor = new Color(255, 255, 255, 255);
				panel.Add(lblNombreEstacion, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgEstacion);

				ILabelButton lblDescripcionEstacion = Platform.Current.Create<ILabelButton>();
				lblDescripcionEstacion.Click += Estacion_Click;
				lblDescripcionEstacion.Text = etacion.Description;
				lblDescripcionEstacion.Tag = etacion;
				lblDescripcionEstacion.FontSize = 10;
				lblDescripcionEstacion.FontColor = new Color (255, 150, 150, 150);
				panel.Add(lblDescripcionEstacion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombreEstacion);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon2--45.png"));
				imgPlay.Click += Estacion_Click;
				imgPlay.Tag = etacion;
				imgPlay.Width = 20;
				imgPlay.Height = 20;
				imgPlay.Margin = new Thickness (0, 0, 20, 0);
				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, grdEstacion);
			}

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

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Cerrar";
			cmdClose.Height = 40;
			cmdClose.BackgroundColor = new Color(255, 255, 212, 79);
			cmdClose.Click += CmdClose_Click;
			cmdClose.Margin = new Thickness (0, 15, 15, 0);
			panel.Add(cmdClose, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, referencia);

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = panel;
		}

		public RegionalesController(HomeController h)
		{
			homecontroler = h;
		}

		public override void Resize()
		{
			base.Resize();

			imgBackgroundImage.Width = Platform.Current.Page.Width;
			imgBackgroundImage.Height = Platform.Current.Page.Height;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
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

