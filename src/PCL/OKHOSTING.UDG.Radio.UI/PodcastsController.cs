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
		protected IImage BackgroundImage;
		IAudioPlayer AudioPlayer;
		HomeController homecontroller;
		Show podcasts;

		public Show Show
		{
			get
			{ 
				return _show;
			}
			set
			{
				_show = value;
			}
		}
		private Show _show;

		public override void Start()
		{
			base.Start();

			System.Net.Http.HttpClient client = new System.Net.Http.HttpClient ();
			var xmlStream = client.GetStreamAsync (podcasts.PodcastUri).Result;

			System.Xml.XmlReader reader = System.Xml.XmlReader.Create (xmlStream);

			IList<Episode> episodios = new List<Episode> ();

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
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-08.png"));
			cmdProgramas.Width = 25;
			cmdProgramas.Height = 25;
			//cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			grdMenu.SetContent (0, 2, cmdProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 25;
			imgVirtuales.Height = 25;
			imgVirtuales.Click += cmdVirtuales_Click;
			grdMenu.SetContent (0, 3, imgVirtuales);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Archivo de programa";
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
			lblLabel.FontFamily = "Arial";
			lblLabel.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblLabel.TextVerticalAlignment = VerticalAlignment.Center;
			lblLabel.FontColor = new Color(255, 255, 255, 255);
			lblLabel.BackgroundColor = new Color(255, 255, 143, 0);
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
					imgLogo.Margin = new Thickness (0, 0, 10, 0);
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					imgLogo.Width = 60;
					imgLogo.Height = 40;
					imgLogo.Margin = new Thickness (0, 0, 0, 0);
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgLogo.Width = 90;
					imgLogo.Height = 60;
					imgLogo.Margin = new Thickness (0, 0, 30, 0);
				}
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblLabel);
			}

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--49.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 500)
			{
				BackgroundImage.Height = Platform.Current.Page.Height * 1.2;
			} 
			else if (Platform.Current.Page.Width < 310)
			{
				BackgroundImage.Height = Platform.Current.Page.Height * 2;
			} 
			else if (Platform.Current.Page.Width > 500)
			{
				BackgroundImage.Height = Platform.Current.Page.Height * 2.7;
			}
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			IControl referencia = lblLabel;

			while (reader.ReadToFollowing ("item")) 
			{
				reader.ReadToFollowing ("title");
				Episode episodio = new Episode ();
				episodio.Name = reader.ReadElementContentAsString ();
				reader.ReadToFollowing ("link");
				string mp3string = reader.ReadElementContentAsString();
				episodio.EpisodeUri = new Uri (mp3string);
				episodio.ImagenUri = podcasts.LogoUri;
				episodio.Description = podcasts.Name;

				episodios.Add (episodio);
			}

			foreach(Episode e in episodios)
			{
				IGrid grdPostcads = Platform.Current.Create<IGrid>();
				grdPostcads.RowCount = 1;
				grdPostcads.ColumnCount = 4;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					grdPostcads.Height = 70;
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					grdPostcads.Height = 50;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					grdPostcads.Height = 90;
				}
				grdPostcads.Width = Platform.Current.Page.Width;
				grdPostcads.BackgroundColor = new Color(40, 120, 120, 120);
				grdPostcads.Margin = new Thickness (0, 20, 0, 0);
				panel.Add(grdPostcads, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

				referencia = grdPostcads;

				IImageButton imgPostcast = Platform.Current.Create<IImageButton>();
				imgPostcast.LoadFromUrl(podcasts.LogoUri);
				imgPostcast.Click += Episode_Click;
				imgPostcast.Tag = e;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					imgPostcast.Width = 50;
					imgPostcast.Height = 50;
					imgPostcast.Margin = new Thickness (25, 10, 30, 5);
				} 
				else if (Platform.Current.Page.Width < 250)
				{
					imgPostcast.Width = 35;
					imgPostcast.Height = 35;
					imgPostcast.Margin = new Thickness(7, 10, 7, 5);
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgPostcast.Width = 70;
					imgPostcast.Height = 70;
					imgPostcast.Margin = new Thickness(40, 10, 80, 5);
				}
				panel.Add(imgPostcast, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdPostcads);

				ILabelButton lblTitulo = Platform.Current.Create<ILabelButton> ();
				if (Platform.Current.Page.Width < 310)
				{
					lblTitulo.Width = 150;
					lblTitulo.FontSize = 10;
				} 
				else if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					lblTitulo.Width = 250;
					lblTitulo.FontSize = 12;
				}
				else if (Platform.Current.Page.Width > 600)
				{
					lblTitulo.Width = 500;
					lblTitulo.FontSize = 16;
				}
				lblTitulo.Text = e.Name;
				lblTitulo.FontColor = new Color (255, 255, 255, 255);
				lblTitulo.Click += Episode_Click;
				lblTitulo.Tag = e;
				panel.Add (lblTitulo, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgPostcast);


				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon-20.png"));
				imgPlay.Click += Episode_Click;
				imgPlay.Tag = e;
				if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
				{
					imgPlay.Width = 30;
					imgPlay.Height = 30;
					imgPlay.Margin = new Thickness (0, 0, 30, 0);
				} 
				else if (Platform.Current.Page.Width < 310)
				{
					imgPlay.Width = 20;
					imgPlay.Height = 20;
					imgPlay.Margin = new Thickness (0, 0, 10, 0);
				}
				else if (Platform.Current.Page.Width > 600)
				{
					imgPlay.Width = 50;
					imgPlay.Height = 50;
					imgPlay.Margin = new Thickness (0, 0, 50, 0);
				}
				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, grdPostcads);
			}

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = panel;
		}

		public PodcastsController(Show p, HomeController home)
		{
			podcasts = p;
			homecontroller = home;
		}

		private void cmdHome_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdVirtuales_Click(object sender, EventArgs e)
		{
			this.Finish();
			new VirtualesController (homecontroller).Start ();
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
			new RegionalesController (homecontroller).Start ();
		}

		public void Episode_Click(object sender, EventArgs e)
		{
			IControl control = (IControl)sender;
			Episode episode = (Episode)control.Tag;
			homecontroller.Episode = episode;
			this.Finish ();
		}
	}
}

