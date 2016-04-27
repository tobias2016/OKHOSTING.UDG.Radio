using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{
	public class PodcastsController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		HomeController HomeController;
		Show Show;

		public override void Start()
		{
			base.Start();

			System.Net.Http.HttpClient client = new System.Net.Http.HttpClient ();
			var xmlStream = client.GetStreamAsync (Show.PodcastUri).Result;

			System.Xml.XmlReader reader = System.Xml.XmlReader.Create (xmlStream);

			IList<Episode> episodios = new List<Episode> ();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color (255, 255, 255, 255);
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
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-08.png"));
			cmdProgramas.Width = 25;
			cmdProgramas.Height = 25;
			//cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent(1, 2, cmdProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 25;
			imgVirtuales.Height = 25;
			imgVirtuales.Click += cmdVirtuales_Click;
			grdMenu.SetContent(1, 3, imgVirtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("Archivo de programa", new Color(255, 255, 143, 0));
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

			IControl referencia = lblTitulo;

			while (reader.ReadToFollowing ("item")) 
			{
				reader.ReadToFollowing ("title");
				Episode episodio = new Episode ();
				episodio.Name = reader.ReadElementContentAsString ();
				reader.ReadToFollowing ("link");
				string mp3string = reader.ReadElementContentAsString();
				episodio.EpisodeUri = new Uri (mp3string);
				episodio.ImagenUri = Show.LogoUri;
				episodio.Description = Show.Name;

				episodios.Add (episodio);
			}

			foreach(Episode e in episodios)
			{
				IGrid grdPostcads = Platform.Current.Create<IGrid>();
				grdPostcads.RowCount = 1;
				grdPostcads.ColumnCount = 4;
				grdPostcads.Height = 90;
				grdPostcads.Width = Platform.Current.Page.Width;
				grdPostcads.Margin = new Thickness (0, 20, 0, 0);
				panel.Add(grdPostcads, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

				referencia = grdPostcads;

				IImageButton imgPostcast = Platform.Current.Create<IImageButton>();
				imgPostcast.LoadFromUrl(Show.LogoUri);
				imgPostcast.Click += Episode_Click;
				imgPostcast.Tag = e;
				imgPostcast.Width = 70;
				imgPostcast.Height = 70;
				imgPostcast.Margin = new Thickness(40, 10, 80, 5);
				panel.Add(imgPostcast, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdPostcads);

				ILabelButton lblTituloPodcast = Platform.Current.Create<ILabelButton> ();
				lblTituloPodcast.Width = 500;
				lblTituloPodcast.Text = e.Name;
				lblTituloPodcast.FontSize = Constantes.FontSize2;
				lblTituloPodcast.FontColor = Constantes.FontColor2;
				lblTituloPodcast.Click += Episode_Click;
				lblTituloPodcast.Tag = e;
				panel.Add (lblTituloPodcast, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgPostcast);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon-20.png"));
				imgPlay.Click += Episode_Click;
				imgPlay.Tag = e;
				imgPlay.Width = 50;
				imgPlay.Height = 50;
				imgPlay.Margin = new Thickness (0, 0, 50, 0);
				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, grdPostcads);
			}

			Platform.Current.Page.Title = "Selecciona un episodio";
			Platform.Current.Page.Content = panel;
		}

		public PodcastsController(Show show, HomeController home)
		{
			Show = show;
			HomeController = home;
		}

		private void cmdHome_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdVirtuales_Click(object sender, EventArgs e)
		{
			this.Finish();
			new VirtualesController (HomeController).Start ();
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
			new RegionalesController (HomeController).Start ();
		}

		public void Episode_Click(object sender, EventArgs e)
		{
			IControl control = (IControl)sender;
			Episode episode = (Episode)control.Tag;
			HomeController.Episode = episode;
			this.Finish ();
		}
	}
}

