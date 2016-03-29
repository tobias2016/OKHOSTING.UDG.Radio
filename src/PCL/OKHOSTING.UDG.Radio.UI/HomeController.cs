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
		protected IImage BackgroundImage;
		IButton play;
        IAudioPlayer AudioPlayer;

        public override void Start()
        {
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--47.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height * 2;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

            IGrid menu = Platform.Current.Create<IGrid>();
            menu.RowCount = 1;
            menu.ColumnCount = 4;
            menu.Height = 50;
            menu.Width = Platform.Current.Page.Width;
            menu.BackgroundColor = new Color(255, 0, 0, 0);
            panel.Add(menu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Home = Platform.Current.Create<IImageButton>();
			Home.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-08.png"));
			Home.Width = 35;
			Home.Height = 35;
			Home.Click += (object sender, EventArgs e) => new HomeController().Start();
			menu.SetContent(0, 0, Home);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-16.png"));
			cmdProgramas.Width = 35;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
            menu.SetContent(0, 1, cmdProgramas);

            IImageButton Regionales = Platform.Current.Create<IImageButton>();
			Regionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-17.png"));
			Regionales.Width = 35;
			Regionales.Height = 35;
            menu.SetContent(0, 2, Regionales);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-18.png"));
			Virtuales.Width = 35;
			Virtuales.Height = 35;
            menu.SetContent(0, 3, Virtuales);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Radio Universidad De Guadalajara";
			lblLabel.Width = 240;
			lblLabel.Height = 25;
			lblLabel.FontColor = new Color(255, 0, 0, 0);
			lblLabel.BackgroundColor = new Color(255, 255, 212, 79);
            panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, menu);

			IImage imagen = Platform.Current.Create<IImage> ();
			imagen.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--01.png"));
			imagen.Width = 50;
			imagen.Height = 20;
			panel.Add(imagen, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, lblLabel);

			/*
			IGrid Alaire = Platform.Current.Create<IGrid>();
			Alaire.RowCount = 1;
			Alaire.ColumnCount = 2;
			Alaire.Height = 50;
			Alaire.Width = 200;
			Alaire.BackgroundColor = new Color(255, 0, 0, 0);
			panel.Add(Alaire, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);
			*/

			IImage imagen2 = Platform.Current.Create<IImage> ();
			imagen2.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-13.png"));
			imagen2.Width = 40;
			imagen2.Height = 15;
			//Alaire.SetContent(0, 0, imagen2);
			imagen2.Margin = new Thickness(2, 17, 0, 5);
			panel.Add(imagen2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			ILabel lblLabel2 = Platform.Current.Create<ILabel>();
			lblLabel2.Text = "AHORA AL AIRE";
			lblLabel2.FontColor = new Color(255, 255, 212, 79);
			//Alaire.SetContent(0, 1, lblLabel2);
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imagen2);

			play = Platform.Current.Create<IButton>();
			play.Text = "Play";
            //play.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-03.png"));
            play.Click += Play_Click;
			play.Width = 80;
			play.Height = 35;
			play.Margin = new Thickness (2);
			panel.Add(play, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imagen2);

			IImage imagen3 = Platform.Current.Create<IImage> ();
			imagen3.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-14.png"));
			imagen3.Width = 40;
			imagen3.Height = 15;
			imagen3.Margin = new Thickness (2, 15, 0, 5);
			panel.Add(imagen3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, play);

			ILabel lblLabel3 = Platform.Current.Create<ILabel>();
			lblLabel3.Text = "NOTAS DE EL ACORDEON";
			lblLabel3.FontColor = new Color(255, 255, 212, 79);
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, imagen3);

			ILabel lblTexto = Platform.Current.Create<ILabel>();
			lblTexto.Text = "Hoy estamos hablando de las palabras que usamos que provienen del Árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			lblTexto.BorderColor = new Color(255, 255, 255, 255);
			lblTexto.BorderWidth = new Thickness(9, 9, 9, 9);
			lblTexto.Margin = new Thickness (2);
			panel.Add(lblTexto, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, imagen3);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "ENVIA UN MENSAJE A EL ACORDEON";
			lblLabel4.FontSize = 11;
			lblLabel4.FontColor = new Color(1, 255, 212, 79);
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

			IButton Enviar = Platform.Current.Create<IButton>();
			Enviar.Text = "Enviar";
			Enviar.Width = 80;
			Enviar.Height = 30;
			Enviar.FontSize = 12;
			Enviar.FontColor = new Color (255, 0, 0, 0);
			Enviar.BackgroundColor = new Color(255, 255, 212, 79);
			Enviar.Margin = new Thickness (0, 2, 2, 5);
			panel.Add(Enviar, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.BelowOf, txtAreaComentario);

			Platform.Current.Page.Title = "straming";
			Platform.Current.Page.Content = panel;
        }

		public override void Resize()
		{
			base.Resize();

			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
		}

        private void Stop_Click(object sender, EventArgs e)
        {
            AudioPlayer.Stop();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            AudioPlayer.Pause();
        }

        private void Play_Click(object sender, EventArgs e)
        {
			AudioPlayer.Source = new Uri ("http://148.202.114.39:8000/;stream/1");
            AudioPlayer.Play();
        }

    }
}