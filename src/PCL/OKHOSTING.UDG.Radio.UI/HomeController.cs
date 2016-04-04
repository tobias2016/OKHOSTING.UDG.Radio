using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{ 
    public class HomeController : OKHOSTING.UI.Controller
    {
		protected IImage imgBackgroundImage;
        protected IImageButton cmdPlay;
        IAudioPlayer AudioPlayer;
		IImage imgLogoPrograma;
		ILabel lblPrograma;
		ILabel lblPrograma2;

		public Station Station 
		{
			get 
			{
				return _station;
			}
			set 
			{ 
				_station = value;
				AudioPlayer.Stop ();
				AudioPlayer.Source = _station.StramingUri;
				AudioPlayer.Play ();
				imgLogoPrograma.LoadFromUrl(_station.WebSiteUri);
				lblPrograma.Text = _station.Name;
				lblPrograma2.Text = _station.Description;	
				cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-53.png"));
				IsPlaying = true;
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
				AudioPlayer.Stop ();
				AudioPlayer.Source = _episode.EpisodeUri;
				lblPrograma.Text = _episode.Name;
				cmdPlay.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images/app-53.png"));
				IsPlaying = true;
			}
		}

		private Episode _episode;

        public override void Start()
        {
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color (255, 0, 0, 0);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

            AudioPlayer.Source = new Uri("http://148.202.114.39:8000/;stream/1");

            IGrid menu = Platform.Current.Create<IGrid>();
            menu.RowCount = 1;
            menu.ColumnCount = 4;
            menu.Height = 15;
            menu.Width = Platform.Current.Page.Width;
            menu.BackgroundColor = new Color(255, 0, 0, 0);
            panel.Add(menu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon2--15.png"));
			imgHome.Width = 20;
			imgHome.Height = 20;
			imgHome.Click += (object sender, EventArgs e) => new HomeController().Start();
			menu.SetContent(0, 0, imgHome);

            IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Width = 20;
			imgRegionales.Height = 20;
			imgRegionales.Click += (object sender, EventArgs e) => new RegionalesController(this).Start();
            menu.SetContent(0, 1, imgRegionales);

			IImageButton imgProgramas = Platform.Current.Create<IImageButton>();
			imgProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imgProgramas.Width = 20;
			imgProgramas.Height = 20;
			imgProgramas.Click += (object sender, EventArgs e) => new ProgramasController(this).Start();
			menu.SetContent(0, 2, imgProgramas);
            
			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 20;
			imgVirtuales.Height = 20;
            menu.SetContent(0, 3, imgVirtuales);

			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = "Radio Universidad De Guadalajara";
			lblTitulo.Width = Platform.Current.Page.Width;
			lblTitulo.Height = 40;
			lblTitulo.FontColor = new Color(255, 0, 0, 0);
            lblTitulo.FontSize = 11;
            lblTitulo.Bold = true;
            lblTitulo.FontFamily = "Arial";
            lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
            lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			lblTitulo.BackgroundColor = new Color(255, 255, 212, 79);
			lblTitulo.Margin = new Thickness (0, 15, 0, 0);
            panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, menu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = 60;
				imgLogo.Height = 40;
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			imgBackgroundImage = Platform.Current.Create<IImage>();
			imgBackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--47.png"));
			imgBackgroundImage.Width = Platform.Current.Page.Width;
			if (Platform.Current.Page.Width > 500)
			{
				imgBackgroundImage.Height = Platform.Current.Page.Height * 2.7;
			} 
			else if (Platform.Current.Page.Width < 500)
			{
				imgBackgroundImage.Height = Platform.Current.Page.Height * 1.2;
			}

			panel.Add(imgBackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

            IImage imgAntena = Platform.Current.Create<IImage> ();
			imgAntena.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-13.png"));
			imgAntena.Width = 40;
			imgAntena.Height = 15;
			imgAntena.Margin = new Thickness(0, 25, 0, 5);
			panel.Add(imgAntena, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

			ILabel lblAlAire = Platform.Current.Create<ILabel>();
			lblAlAire.Text = "AHORA AL AIRE";
            lblAlAire.FontSize = 12;
            lblAlAire.Bold = true;
            lblAlAire.FontFamily = "Arial";
            lblAlAire.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblAlAire, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgAntena);

            IGrid grdReproductor = Platform.Current.Create<IGrid>();
            grdReproductor.RowCount = 1;
            grdReproductor.ColumnCount = 4;
            grdReproductor.Height = 70;
            grdReproductor.Width = Platform.Current.Page.Width - 30;
            grdReproductor.BackgroundColor = new Color(230, 255, 255, 255);
            grdReproductor.Margin = new Thickness(12, 10, 15, 20);
            panel.Add(grdReproductor, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);

            imgLogoPrograma = Platform.Current.Create<IImage>();
			imgLogoPrograma.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--19.png"));
            imgLogoPrograma.Width = 41;
            imgLogoPrograma.Height = 41;
			if (Platform.Current.Page.Width > 390)
			{
				imgLogoPrograma.Margin = new Thickness(20, 10, 35, 5);
			}
			else if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 350)
			{
				imgLogoPrograma.Margin = new Thickness(15, 10, 25, 5);
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				imgLogoPrograma.Margin = new Thickness(10, 10, 15, 5);
			}
            
            //panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);
            panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdReproductor);

            lblPrograma = Platform.Current.Create<ILabel>();
			lblPrograma.Text = "GUADALAJARA";
            lblPrograma.FontColor = new Color(255, 0, 0, 10);
            lblPrograma.FontFamily = "Arial";

			if (Platform.Current.Page.Width > 390)
			{
				lblPrograma.FontSize = 12;
				lblPrograma.Width = 200;
			}
			else if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 350)
			{
				lblPrograma.FontSize = 11;
				lblPrograma.Width = 140;
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				lblPrograma.FontSize = 10;
				lblPrograma.Width = 100;
			}

			lblPrograma.Bold = true;
			panel.Add(lblPrograma, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogoPrograma);

            lblPrograma2 = Platform.Current.Create<ILabel>();
			lblPrograma2.Text = "XHUDG 104.3 F.M.";
            lblPrograma2.FontColor = new Color(255, 128, 128, 128);
            lblPrograma2.FontFamily = "Arial";
			if (Platform.Current.Page.Width > 390)
			{
				lblPrograma2.FontSize = 11;
			}
			else if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 350)
			{
				lblPrograma2.FontSize = 10;
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				lblPrograma2.FontSize = 9;
			}
            
            lblPrograma2.Margin = new Thickness(0, 2, 0, 0);
            panel.Add(lblPrograma2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblPrograma);

            cmdPlay = Platform.Current.Create<IImageButton>();
            cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
            cmdPlay.Click += Play_Click;
			cmdPlay.Width = 80;
			cmdPlay.Height = 35;
			cmdPlay.Margin = new Thickness (5, 0, 0, 0);
			panel.Add(cmdPlay, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, grdReproductor);

			/*
			IImage imgNotas = Platform.Current.Create<IImage> ();
			imgNotas.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-14.png"));
			imgNotas.Width = 40;
			imgNotas.Height = 15;
			imgNotas.Margin = new Thickness (-11, 0, 0, 0);
			panel.Add(imgNotas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdReproductor);

			ILabel lblNotas = Platform.Current.Create<ILabel>();
            lblNotas.Text = "NOTAS DE EL ACORDEON";
			lblNotas.FontSize = 12;
			lblNotas.Bold = true;
			lblNotas.FontFamily = "Arial";
            lblNotas.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblNotas, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgNotas);

			ILabel lblTexto = Platform.Current.Create<ILabel>();
			lblTexto.Text = "Hoy estamos hablando de las palabras que usamos que provienen del Árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			lblTexto.BorderColor = new Color(255, 255, 255, 255);
			lblTexto.BorderWidth = new Thickness(9, 9, 9, 9);
			lblTexto.FontSize = 10;
			lblTexto.Width = Platform.Current.Page.Width - 40;
			lblTexto.FontColor = new Color (255, 255, 255, 255);
			lblTexto.Margin = new Thickness (25, 5, 0, 15);
			panel.Add(lblTexto, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgNotas);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "ENVIA UN MENSAJE A EL ACORDEON";
			lblLabel4.FontSize = 12;
			lblLabel4.FontFamily = "Arial";
			lblLabel4.Bold = true;
			lblLabel4.FontColor = new Color(255, 255, 212, 79);
			lblLabel4.Margin = new Thickness (-12, 0, 0, 0);
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTexto);

			ITextArea txtAreaComentario = Platform.Current.Create<ITextArea>();
			txtAreaComentario.Value = "";
			txtAreaComentario.FontSize = 12;
			txtAreaComentario.FontColor = new Color(255, 0, 0, 0);
			txtAreaComentario.BackgroundColor = new Color(255, 255, 255, 255);
			txtAreaComentario.Width = Platform.Current.Page.Width - 45;
			txtAreaComentario.Height = 80;
			txtAreaComentario.Margin = new Thickness (15, 5, 0, 10);
			panel.Add(txtAreaComentario, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel4);
			*/

			Play_Click (null, null);

			Platform.Current.Page.Title = "straming";
			Platform.Current.Page.Content = panel;
        }

		public override void Resize()
		{
			base.Resize();

			imgBackgroundImage.Width = Platform.Current.Page.Width;
			imgBackgroundImage.Height = Platform.Current.Page.Height;
		}

        protected bool IsPlaying = false;

        private void Play_Click(object sender, EventArgs e)
        {
            if (!IsPlaying)
            {
                AudioPlayer.Play();
                cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-53.png"));
                IsPlaying = true;
            }
            else
            {
                AudioPlayer.Pause();
                cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
                IsPlaying = false;
            }
        }

        public override void Finish()
        {
            AudioPlayer.Stop();
            base.Finish();
        }
    }
}