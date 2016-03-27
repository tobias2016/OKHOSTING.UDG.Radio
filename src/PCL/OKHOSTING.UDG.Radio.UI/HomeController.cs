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
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IButton cmdProgramas = Platform.Current.Create<IButton>();
			cmdProgramas.Text = "Programas";
			cmdProgramas.Width = 80;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			panel.Add(cmdProgramas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Regionales = Platform.Current.Create<IImageButton>();
			Regionales.LoadFromUrl (new Uri("http://app-udg.okhosting.com/iconos%20new/app-17.png"));
			Regionales.Width = 80;
			Regionales.Height = 35;
			panel.Add(Regionales, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://app-udg.okhosting.com/iconos%20new/app-18.png"));
			Virtuales.Width = 80;
			Virtuales.Height = 35;
			panel.Add(Virtuales, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith);

			IGrid Titulo = Platform.Current.Create<IGrid> ();
			Titulo.ColumnCount = 3;
			Titulo.RowCount = 1;	

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Radio Universidad De Guadalajara";
			lblLabel.Width = 150;
			lblLabel.Height = 20;
			lblLabel.FontColor = new Color(1, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
            lblLabel.Margin = new Thickness(30);
            panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, cmdProgramas);

			IImage imagen = Platform.Current.Create<IImage> ();
			imagen.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--01.png"));
			imagen.Width = 50;
			imagen.Height = 20;
			panel.Add(imagen, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.CenterWith, lblLabel);

			ILabel lblLabels = Platform.Current.Create<ILabel>();
			lblLabels.Text = "";
			lblLabels.Height = 20;
			lblLabels.Width = 20;
			panel.Add(lblLabels, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			ILabel lblLabel2 = Platform.Current.Create<ILabel>();
			lblLabel2.Text = "AHORA AL AIRE";
			lblLabel2.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabels);

			IImage imagen2 = Platform.Current.Create<IImage> ();
			imagen2.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-13.png"));
			imagen2.Width = 40;
			imagen2.Height = 15;
			panel.Add(imagen2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.AboveOf, lblLabel2);

			play = Platform.Current.Create<IButton>();
			play.Text = "Play";
            //play.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-03.png"));
            play.Click += Play_Click;
			play.Width = 80;
			play.Height = 35;
			panel.Add(play, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel2);

			ILabel lblLabel3 = Platform.Current.Create<ILabel>();
			lblLabel3.Text = "NOTAS DE EL ACORDEON";
			lblLabel3.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, play);

			IImage imagen3 = Platform.Current.Create<IImage> ();
			imagen3.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon-14.png"));
			imagen3.Width = 40;
			imagen3.Height = 15;
			panel.Add(imagen3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.AboveOf, lblLabel3);

			ILabel lblTexto = Platform.Current.Create<ILabel>();
			lblTexto.Text = "Hoy estamos hablando de las palabras que usamos que provienen del Árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			lblTexto.BorderColor = new Color(1, 255, 255, 255);
			lblTexto.BorderWidth = new Thickness(9, 9, 9, 9);
			panel.Add(lblTexto, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel3);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "ENVIA UN MENSAJE A EL ACORDEON";
			lblLabel4.FontSize = 11;
			lblLabel4.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTexto);

			ITextArea txtAreaComentario = Platform.Current.Create<ITextArea>();
			txtAreaComentario.Value = "";
			txtAreaComentario.FontSize = 12;
			txtAreaComentario.FontColor = new Color(1, 0, 0, 255);
			txtAreaComentario.BackgroundColor = new Color(1, 255, 255, 255);
			txtAreaComentario.Width = 210;
			txtAreaComentario.Height = 80;
			panel.Add(txtAreaComentario, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel4);

			IButton Enviar = Platform.Current.Create<IButton>();
			Enviar.Text = "Enviar";
			Enviar.Width = 80;
			Enviar.Height = 30;
			Enviar.FontSize = 12;
			Enviar.BackgroundColor = new Color(1, 255, 0, 255);
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