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
        public static IAudioPlayer AudioPlayer;

        public override void Start()
        {
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

            AudioPlayer.Source = new Uri("http://148.202.114.39:8000/;stream/1");

            IGrid menu = Platform.Current.Create<IGrid>();
            menu.RowCount = 1;
            menu.ColumnCount = 4;
            menu.Height = 50;
            menu.Width = Platform.Current.Page.Width;
            menu.BackgroundColor = new Color(255, 0, 0, 0);
            panel.Add(menu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-08.png"));
			imgHome.Width = 35;
			imgHome.Height = 35;
			imgHome.Click += (object sender, EventArgs e) => new HomeController().Start();
			menu.SetContent(0, 0, imgHome);

			IImageButton imgProgramas = Platform.Current.Create<IImageButton>();
			imgProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-16.png"));
			imgProgramas.Width = 35;
			imgProgramas.Height = 35;
			imgProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
            menu.SetContent(0, 1, imgProgramas);

            IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-17.png"));
			imgRegionales.Width = 35;
			imgRegionales.Height = 35;
            menu.SetContent(0, 2, imgRegionales);
            
			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-18.png"));
			imgVirtuales.Width = 35;
			imgVirtuales.Height = 35;
            menu.SetContent(0, 3, imgVirtuales);

			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = "Radio Universidad De Guadalajara";
			lblTitulo.Width = Platform.Current.Page.Width;
			lblTitulo.Height = 50;
			lblTitulo.FontColor = new Color(255, 0, 0, 0);
            lblTitulo.FontSize = 15;
            lblTitulo.Bold = true;
            lblTitulo.FontFamily = "Arial";
            lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
            lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			lblTitulo.BackgroundColor = new Color(255, 255, 212, 79);
            panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, menu);

			IImage imgLogo = Platform.Current.Create<IImage> ();
			imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images/app-07.png"));
			imgLogo.Width = 100;
			imgLogo.Height = lblTitulo.Height;
			panel.Add(imgLogo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.CenterWith, lblTitulo);

            imgBackgroundImage = Platform.Current.Create<IImage>();
            imgBackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--47.png"));
            imgBackgroundImage.Width = Platform.Current.Page.Width * 1.3;
            imgBackgroundImage.Height = Platform.Current.Page.Height * 2;
            panel.Add(imgBackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

            IImage imgAntena = Platform.Current.Create<IImage> ();
			imgAntena.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-13.png"));
			imgAntena.Width = 40;
			imgAntena.Height = 15;
			imgAntena.Margin = new Thickness(10, 25, 0, 10);
			panel.Add(imgAntena, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTitulo);

			ILabel lblAlAire = Platform.Current.Create<ILabel>();
			lblAlAire.Text = "Ahora al aire";
            lblAlAire.FontSize = 14;
            lblAlAire.Bold = true;
            lblAlAire.FontFamily = "Arial";
            lblAlAire.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblAlAire, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgAntena);

            IGrid grdReproductor = Platform.Current.Create<IGrid>();
            grdReproductor.RowCount = 1;
            grdReproductor.ColumnCount = 4;
            grdReproductor.Height = 70;
            grdReproductor.Width = Platform.Current.Page.Width - 40;
            grdReproductor.BackgroundColor = new Color(130, 255, 255, 255);
            grdReproductor.Margin = new Thickness(10, 20, 20, 5);
            panel.Add(grdReproductor, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);

            IImage imgLogoPrograma = Platform.Current.Create<IImage>();
            imgLogoPrograma.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--19.png"));
            imgLogoPrograma.Width = 41;
            imgLogoPrograma.Height = 41;
            imgLogoPrograma.Margin = new Thickness(10, 10, 20, 5);
            //panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgAntena);
            panel.Add(imgLogoPrograma, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, grdReproductor);

            ILabel lblPrograma = Platform.Current.Create<ILabel>();
            lblPrograma.Text = "El Acordeón";
            lblPrograma.FontColor = new Color(255, 80, 80, 80);
            lblPrograma.FontFamily = "Arial";
            lblPrograma.FontSize = 16;
            panel.Add(lblPrograma, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogoPrograma);

            ILabel lblPrograma2 = Platform.Current.Create<ILabel>();
            lblPrograma2.Text = "Con Manuel Falcón";
            lblPrograma2.FontColor = new Color(255, 150, 150, 150);
            lblPrograma2.FontFamily = "Arial";
            lblPrograma2.FontSize = 12;
            lblPrograma2.Margin = new Thickness(0, 5, 0, 0);
            panel.Add(lblPrograma2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblPrograma);

            cmdPlay = Platform.Current.Create<IImageButton>();
            cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images/app-54.png"));
            cmdPlay.Click += Play_Click;
			cmdPlay.Width = 80;
			cmdPlay.Height = 35;
			cmdPlay.Margin = new Thickness (20, 0, 0, 0);
			panel.Add(cmdPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblPrograma);

			IImage imgNotas = Platform.Current.Create<IImage> ();
			imgNotas.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-14.png"));
			imgNotas.Width = 40;
			imgNotas.Height = 15;
			imgNotas.Margin = new Thickness (0, 15, 0, 5);
			panel.Add(imgNotas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdReproductor);

			ILabel lblNotas = Platform.Current.Create<ILabel>();
            lblNotas.Text = "NOTAS DE EL ACORDEON";
            lblNotas.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblNotas, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imgNotas);

			ILabel lblTexto = Platform.Current.Create<ILabel>();
			lblTexto.Text = "Hoy estamos hablando de las palabras que usamos que provienen del Árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			lblTexto.BorderColor = new Color(255, 255, 255, 255);
			lblTexto.BorderWidth = new Thickness(9, 9, 9, 9);
			lblTexto.Margin = new Thickness (2);
			panel.Add(lblTexto, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imgNotas);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "ENVIA UN MENSAJE A EL ACORDEON";
			lblLabel4.FontSize = 11;
			lblLabel4.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTexto);

			ITextArea txtAreaComentario = Platform.Current.Create<ITextArea>();
			txtAreaComentario.Value = "";
			txtAreaComentario.FontSize = 12;
			txtAreaComentario.FontColor = new Color(255, 0, 0, 0);
			txtAreaComentario.BackgroundColor = new Color(255, 255, 255, 255);
			txtAreaComentario.Width = 210;
			txtAreaComentario.Height = 80;
			txtAreaComentario.Margin = new Thickness (2);
			panel.Add(txtAreaComentario, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel4);

			IButton cmdEnviar = Platform.Current.Create<IButton>();
			cmdEnviar.Text = "Enviar";
			cmdEnviar.Width = 80;
			cmdEnviar.Height = 30;
			cmdEnviar.FontSize = 12;
			cmdEnviar.FontColor = new Color (255, 0, 0, 0);
			cmdEnviar.BackgroundColor = new Color(255, 255, 212, 79);
			cmdEnviar.Margin = new Thickness (0, 2, 2, 5);
			panel.Add(cmdEnviar, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.BelowOf, txtAreaComentario);

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
                cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/image/app-53.png"));
                IsPlaying = true;
            }
            else
            {
                AudioPlayer.Pause();
                cmdPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/image/app-54.png"));
                IsPlaying = false;
            }
        }
    }
}