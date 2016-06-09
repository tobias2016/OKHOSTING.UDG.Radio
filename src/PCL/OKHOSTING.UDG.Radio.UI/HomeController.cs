using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{ 
	public class HomeController : OKHOSTING.UI.Controller
	{
		IImageButton cmdPlay;
		IAudioPlayer AudioPlayer;
		IImage imgLogoPrograma;
		ILabel lblNombre;
		ILabel lblDescripcion;

		public Station Station 
		{
			get 
			{
				return _station;
			}
			set 
			{ 
				_station = value;
				imgLogoPrograma.LoadFromUrl(_station.WebSiteUri);
				lblNombre.Text = _station.Name;
				lblDescripcion.Text = _station.Description;
				cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-53.png"));
				IsPlaying = true;

				AudioPlayer.Stop ();
				AudioPlayer.Source = _station.StramingUri;
				AudioPlayer.Play ();
			}
		}

		private Station _station;

		public Episode Episode
		{
			get 
			{
				return _episode;
			}
			set 
			{
				_episode = value;
				cmdPlay.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images/app-53.png"));

				imgLogoPrograma.LoadFromUrl(_episode.ImagenUri);
				lblNombre.Text = _episode.Name;
				lblDescripcion.Text = _episode.Description;
				IsPlaying = true;

				AudioPlayer.Stop ();
				AudioPlayer.Source = _episode.EpisodeUri;
				AudioPlayer.Play ();
			}
		}

		private Episode _episode;

		public override void Start()
		{
			base.Start();
            Current = this;

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color(255, 255, 255, 255);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>(new string[] { "Xamarin.Android", "Xamarin.iOS" });

						IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--15.png"));
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Click += (object sender, EventArgs e) => new RegionalesController().Start();
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton imgProgramas = Platform.Current.Create<IImageButton>();
			imgProgramas.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imgProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent(1, 2, imgProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Click += (object sender, EventArgs e) => new VirtualesController().Start();
			grdMenu.SetContent(1, 3, imgVirtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("Radio Universidad De Guadalajara", new Color(255, 255, 212, 79));
			panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage>();
				imgLogo.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = Platform.Current.Page.Width / 6;
				imgLogo.Height = lblTitulo.Height;
				imgLogo.Margin = new Thickness(0, 0, 10, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			IImage imgAntena = Platform.Current.Create<IImage>();
			imgAntena.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-22.png"));
			imgAntena.Width = Platform.Current.Page.Width * .1;
			imgAntena.Margin = new Thickness(10, 0, 10, 20);
			panel.Add(imgAntena, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

			ILabel lblAlAire = Platform.Current.Create<ILabel>();
			lblAlAire.Text = "Estas escuchando:";
			lblAlAire.Bold = true;
			lblAlAire.FontSize = Constantes.FontSize2;
			lblAlAire.FontFamily = Constantes.FontFamily;
			lblAlAire.FontColor = Constantes.FontColor2;
			panel.Add(lblAlAire, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgAntena);

			var estacionDefault = RegionalesController.LeerEstaciones().First();

			AudioPlayer.Stop();
			AudioPlayer.Source = estacionDefault.StramingUri;

			IGrid grdReproductor = Platform.Current.Create<IGrid>();
			grdReproductor.RowCount = 1;
			grdReproductor.ColumnCount = 4;
			grdReproductor.Width = Platform.Current.Page.Width - 20;
			grdReproductor.BackgroundColor = new Color(60, 255, 255, 255);
			panel.Add(grdReproductor, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);

			imgLogoPrograma = Platform.Current.Create<IImage>();
			imgLogoPrograma.LoadFromUrl(estacionDefault.WebSiteUri);
			imgLogoPrograma.Width = Constantes.AnchoIconos;
			imgLogoPrograma.Height = Constantes.AnchoIconos;
			imgLogoPrograma.Margin = new Thickness(0, 0, 10, 0);

			panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdReproductor);

			lblNombre = Platform.Current.Create<ILabel>();
			lblNombre.Text = estacionDefault.Name;
			lblNombre.FontColor = Constantes.FontColor2;
			lblNombre.FontFamily = Constantes.FontFamily;
			lblNombre.FontSize = Constantes.FontSize2;
			lblNombre.Bold = true;
			lblNombre.Width = Platform.Current.Page.Width - (Constantes.AnchoIconos * 3) + 10;
			panel.Add(lblNombre, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogoPrograma);

			lblDescripcion = Platform.Current.Create<ILabel>();
			lblDescripcion.Text = estacionDefault.Description;
			lblDescripcion.FontColor = Constantes.FontColor3;
			lblDescripcion.FontFamily = Constantes.FontFamily;
			lblDescripcion.FontSize = Constantes.FontSize3;
			lblDescripcion.Margin = new Thickness(0, 5, 0, 0);
			lblDescripcion.Width = lblNombre.Width;
			panel.Add(lblDescripcion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombre);

			cmdPlay = Platform.Current.Create<IImageButton>();
			cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
			cmdPlay.Click += Play_Click;
			cmdPlay.Width = Constantes.AnchoIconos;
			cmdPlay.Height = Constantes.AnchoIconos;

			panel.Add(cmdPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblNombre);

			Platform.Current.Page.Title = "Radio Universidad de Guadalajara";
			Platform.Current.Page.Content = panel;

			Play_Click (null, null);
		}

		protected bool IsPlaying = false;

		private void Play_Click(object sender, EventArgs e)
		{
			if (!IsPlaying)
			{
				cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-53.png"));
				AudioPlayer.Play();
				IsPlaying = true;
			}
			else
			{
				cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
				AudioPlayer.Pause();
				IsPlaying = false;
			}
		}

		public override void Finish()
		{
			AudioPlayer.Stop();
			base.Finish();
		}

        public static HomeController Current
        {
            get;
            private set;
        }
	}
}