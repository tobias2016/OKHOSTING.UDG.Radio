using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{
	public class AcordeonController : OKHOSTING.UI.Controller
	{
		protected IImage BackgroundImage;
		IAudioPlayer AudioPlayer;

		public override void Start()
		{
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon2--49.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			ILabelButton Programas = Platform.Current.Create<ILabelButton>();
			Programas.Text = "Programas";
			Programas.Width = 80;
			Programas.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			ILabelButton Regionales = Platform.Current.Create<ILabelButton>();
			Regionales.Text = "Regionales";
			Regionales.Width = 80;
			panel.Add(Regionales, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.TopWith);

			ILabelButton Virtuales = Platform.Current.Create<ILabelButton>();
			Virtuales.Text = "Virtuales";
			Virtuales.Width = 80;
			panel.Add(Virtuales, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Archivo de programas";
			lblLabel.Width = 240;
			lblLabel.Height = 20;
			lblLabel.FontColor = new Color(1, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programas);

			ILabel lblLabels = Platform.Current.Create<ILabel>();
			lblLabels.Text = "";
			lblLabels.Height = 50;
			lblLabels.Width = 20;
			panel.Add(lblLabels, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programas);

			IButton Programa1 = Platform.Current.Create<IButton>();
			Programa1.Click += Programa1_Click;
			Programa1.Text = "20 de Marzo del 2016";
			Programa1.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa1, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabels);

			ILabel lblLabel2 = Platform.Current.Create<ILabel>();
			lblLabel2.Text = "";
			lblLabels.Height = 50;
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			IButton Programa2 = Platform.Current.Create<IButton>();
			Programa2.Click += Programa2_Click;
			Programa2.Text = "19 de Marzo del 2016";
			Programa2.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabel lblLabel3 = Platform.Current.Create<ILabel>();
			lblLabel3.Text = "";
			lblLabels.Height = 50;
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			IButton Programa3 = Platform.Current.Create<IButton>();
			Programa3.Click += Programa3_Click;
			Programa3.Text = "18 de Marzo del 2016";
			Programa3.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "";
			lblLabels.Height = 30;
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			IButton Programa4 = Platform.Current.Create<IButton>();
			Programa4.Click += Programa4_Click;
			Programa4.Text = "17 de Marzo del 2016";
			Programa4.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabel lblLabel5 = Platform.Current.Create<ILabel>();
			lblLabel5.Text = "";
			lblLabels.Height = 30;
			panel.Add(lblLabel5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);

			ILabelButton Programa5 = Platform.Current.Create<ILabelButton>();
			Programa5.Text = "16 de Marzo del 2016";
			Programa5.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);

			ILabel lblLabel6 = Platform.Current.Create<ILabel>();
			lblLabel6.Text = "";
			lblLabels.Height = 30;
			panel.Add(lblLabel6, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa5);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Cerrar";
			cmdClose.Height = 40;
			cmdClose.BackgroundColor = new Color(1, 255, 0, 255);
			cmdClose.Click += CmdClose_Click;
			panel.Add(cmdClose, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BottomWith);

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = panel;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
		private void Programa1_Click(object sender, EventArgs e)
		{
			AudioPlayer.Stop ();
			AudioPlayer.Source = new Uri ("http://148.202.114.39:8000/;stream/1");
			AudioPlayer.Play();
		}
		private void Programa2_Click(object sender, EventArgs e)
		{
			AudioPlayer.Stop ();
			AudioPlayer.Source = new Uri ("http://148.202.119.233:8080/;stream/1");
			AudioPlayer.Play();
		}
		private void Programa3_Click(object sender, EventArgs e)
		{
			AudioPlayer.Stop ();
			AudioPlayer.Source = new Uri ("http://148.202.114.39:8000/;stream/1");
			AudioPlayer.Play();
		}
		private void Programa4_Click(object sender, EventArgs e)
		{
			AudioPlayer.Stop ();
			AudioPlayer.Source = new Uri ("http://148.202.79.112:8000/;stream/1");
			AudioPlayer.Play();
		}
	}
}

