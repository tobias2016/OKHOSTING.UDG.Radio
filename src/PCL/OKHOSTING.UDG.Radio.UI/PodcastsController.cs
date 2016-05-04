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

		public PodcastsController(Show show, HomeController home)
		{
			Show = show;
			HomeController = home;
		}

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
			imgHome.Click += cmdHome_Click;
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Click += cmdEstaciones_Click;
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-08.png"));
			//cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent(1, 2, cmdProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
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

			//extraer episodios del xml
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

			IControl referencia = lblTitulo;

			foreach (Episode episodio in episodios)
			{
				IImageButton imgLogo = Platform.Current.Create<IImageButton>();
				imgLogo.LoadFromUrl(Show.LogoUri);
				imgLogo.Click += Episode_Click;
				imgLogo.Tag = episodio;
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
				
				ILabelButton lblNombre = Platform.Current.Create<ILabelButton> ();
				lblNombre.Click += Episode_Click;
				lblNombre.Text = episodio.Name;
				lblNombre.Tag = episodio;
				lblNombre.Bold = true;
				lblNombre.FontSize = Constantes.FontSize2;
				lblNombre.FontColor = Constantes.FontColor2;
				lblNombre.Width = Platform.Current.Page.Width - (Constantes.AnchoIconos * 3) + 10;
				panel.Add (lblNombre, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogo);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon-20.png"));
				imgPlay.Click += Episode_Click;
				imgPlay.Tag = episodio;
				imgPlay.Width = Constantes.AnchoIconos;
				imgPlay.Height = Constantes.AnchoIconos;

				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblNombre);
			}

			Platform.Current.Page.Title = "Selecciona un episodio";
			Platform.Current.Page.Content = panel;
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

