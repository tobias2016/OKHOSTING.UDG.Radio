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
				AudioPlayer.Play ();
				imgLogoPrograma.LoadFromUrl (_episode.ImagenUri);
				if (Platform.Current.Page.Width < 310 && Platform.Current.Page.Width < 600)
				{
					lblPrograma.FontSize = 9;
				} 
				else if (Platform.Current.Page.Width > 250) 
				{
					lblPrograma.FontSize = 11;
				}
				else if (Platform.Current.Page.Width > 600) 
				{
					lblPrograma.FontSize = 15;
				}
				lblPrograma.Text = _episode.Name;
				lblPrograma2.Text = _episode.Description;
				cmdPlay.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images/app-53.png"));
				IsPlaying = true;
			}
		}

		private Episode _episode;

        public override void Start()
        {
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color(255, 255, 255, 255);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>(new string[] { "Xamarin.Android", "Xamarin.iOS" });

			AudioPlayer.Stop();
			AudioPlayer.Source = new Uri("http://148.202.165.1:8000/;stream/1");

			IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--15.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += (object sender, EventArgs e) => new HomeController().Start();
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			imgRegionales.Click += (object sender, EventArgs e) => new RegionalesController(this).Start();
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton imgProgramas = Platform.Current.Create<IImageButton>();
			imgProgramas.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			imgProgramas.Width = 25;
			imgProgramas.Height = 25;
			imgProgramas.Click += (object sender, EventArgs e) => new ProgramasController(this).Start();
			grdMenu.SetContent(1, 2, imgProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Width = 25;
			imgVirtuales.Height = 25;
			imgVirtuales.Click += (object sender, EventArgs e) => new VirtualesController(this).Start();
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
			imgAntena.Margin = new Thickness(20, 20, 20, 20);
			panel.Add(imgAntena, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

			ILabel lblAlAire = Platform.Current.Create<ILabel>();
			lblAlAire.Text = "Estas escuchando:";
			lblAlAire.Bold = true;
			lblAlAire.FontSize = Constantes.FontSize2;
			lblAlAire.FontFamily = Constantes.FontFamily;
			lblAlAire.FontColor = Constantes.FontColor2;
			panel.Add(lblAlAire, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgAntena);

            IGrid grdReproductor = Platform.Current.Create<IGrid>();
            grdReproductor.RowCount = 1;
            grdReproductor.ColumnCount = 4;

            if (Platform.Current.Page.Width < 600)
			{
				grdReproductor.Height = 70;
			} else if (Platform.Current.Page.Width > 600)
			{
				grdReproductor.Height = 85;
			}

            grdReproductor.Width = Platform.Current.Page.Width - 30;
            grdReproductor.BackgroundColor = new Color(230, 255, 255, 255);
            grdReproductor.Margin = new Thickness(12, 10, 15, 20);
            panel.Add(grdReproductor, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);

            imgLogoPrograma = Platform.Current.Create<IImage>();
			imgLogoPrograma.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--20.png"));

            if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
			{
				imgLogoPrograma.Width = 51;
				imgLogoPrograma.Height = 51;
				imgLogoPrograma.Margin = new Thickness(20, 10, 20, 5);
			} 
			else if (Platform.Current.Page.Width < 310)
			{
				imgLogoPrograma.Width = 41;
				imgLogoPrograma.Height = 41;
				imgLogoPrograma.Margin = new Thickness(5, 10, 7, 5);
			}
			else if (Platform.Current.Page.Width > 600)
			{
				imgLogoPrograma.Width = 71;
				imgLogoPrograma.Height = 71;
				imgLogoPrograma.Margin = new Thickness(25, 10, 35, 5);
			}
            
            //panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);
            panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdReproductor);

            lblPrograma = Platform.Current.Create<ILabel>();
			lblPrograma.Text = "GUADALAJARA";
            lblPrograma.FontColor = new Color(255, 0, 0, 10);
            lblPrograma.FontFamily = "Arial";

            if (Platform.Current.Page.Width > 390 && Platform.Current.Page.Width < 600)
			{
				lblPrograma.FontSize = 13;
				lblPrograma.Width = 200;
				lblPrograma.Margin = new Thickness (20, 0, 0, 0);
			}
			else if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 350)
			{
				lblPrograma.FontSize = 11;
				lblPrograma.Width = 140;
				lblPrograma.Margin = new Thickness (10, 0, 0, 0);
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				lblPrograma.FontSize = 10;
				lblPrograma.Width = 120;
			}
			else if (Platform.Current.Page.Width < 600)
			{
				lblPrograma.FontSize = 17;
				lblPrograma.Width = 220;
			}

			lblPrograma.Bold = true;
			panel.Add(lblPrograma, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogoPrograma);

            lblPrograma2 = Platform.Current.Create<ILabel>();
			lblPrograma2.Text = "XHUDG 104.3 F.M.";
            lblPrograma2.FontColor = new Color(255, 128, 128, 128);
            lblPrograma2.FontFamily = "Arial";

            if (Platform.Current.Page.Width > 390 && Platform.Current.Page.Width < 600)
			{
				lblPrograma2.FontSize = 12;
			}
			else if (Platform.Current.Page.Width > 250 && Platform.Current.Page.Width < 350)
			{
				lblPrograma2.FontSize = 10;
			} 
			else if (Platform.Current.Page.Width < 250)
			{
				lblPrograma2.FontSize = 9;
			}
			else if (Platform.Current.Page.Width > 600)
			{
				lblPrograma2.FontSize = 14;
			}
            
            lblPrograma2.Margin = new Thickness(0, 2, 0, 0);
            panel.Add(lblPrograma2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblPrograma);

            cmdPlay = Platform.Current.Create<IImageButton>();
            cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
            cmdPlay.Click += Play_Click;
			if (Platform.Current.Page.Width > 310 && Platform.Current.Page.Width < 600)
			{
				cmdPlay.Width = 90;
				cmdPlay.Height = 45;
				cmdPlay.Margin = new Thickness (5, 0, 0, 0);
			} 
			else if (Platform.Current.Page.Width < 310)
			{
				cmdPlay.Width = 80;
				cmdPlay.Height = 35;
				cmdPlay.Margin = new Thickness (15, 0, -17, 0);
			}
			else if (Platform.Current.Page.Width > 600)
			{
				cmdPlay.Width = 110;
				cmdPlay.Height = 65;
				cmdPlay.Margin = new Thickness (0, 0, 20, 0);
			}

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

			Platform.Current.Page.Title = "straming";
			Platform.Current.Page.Content = panel;

			Play_Click (null, null);
        }

		public override void Resize()
		{
            if (imgBackgroundImage != null)
            {
                imgBackgroundImage.Width = Platform.Current.Page.Width;
                imgBackgroundImage.Height = Platform.Current.Page.Height;
            }

            base.Resize();
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
    }
}