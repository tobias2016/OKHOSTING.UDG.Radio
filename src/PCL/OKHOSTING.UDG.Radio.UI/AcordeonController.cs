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
			BackgroundImage.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--49.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IGrid menu = Platform.Current.Create<IGrid>();
			menu.RowCount = 1;
			menu.ColumnCount = 4;
			menu.Height = 50;
			menu.Width = Platform.Current.Page.Width;
			menu.BackgroundColor = new Color(255, 0, 0, 0);
			panel.Add(menu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Home = Platform.Current.Create<IImageButton>();
			Home.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			Home.Width = 50;
			Home.Height = 35;
			Home.Click += (object sender, EventArgs e) => new HomeController().Start();
			menu.SetContent (0, 0, Home);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-09.png"));
			cmdProgramas.Width = 50;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			menu.SetContent (0, 1, cmdProgramas);

			IImageButton Regionales = Platform.Current.Create<IImageButton>();
			Regionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-17.png"));
			Regionales.Width = 50;
			Regionales.Height = 35;
			menu.SetContent (0, 2, Regionales);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-18.png"));
			Virtuales.Width = 50;
			Virtuales.Height = 35;
			menu.SetContent (0, 3, Virtuales);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Archivo de programas";
			lblLabel.Width = 240;
			lblLabel.Height = 20;
			lblLabel.FontColor = new Color(255, 0, 0, 0);
			lblLabel.BackgroundColor = new Color(255, 255, 212, 79);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, menu);

			ILabelButton Programa1 = Platform.Current.Create<ILabelButton>();
			Programa1.Click += Programa1_Click;
			Programa1.Text = "20 de Marzo del 2016";
			Programa1.FontColor = new Color(255, 255, 255, 255);
			Programa1.Margin = new Thickness (2);
			panel.Add(Programa1, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			ILabelButton Programa2 = Platform.Current.Create<ILabelButton>();
			Programa2.Click += Programa2_Click;
			Programa2.Text = "19 de Marzo del 2016";
			Programa2.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabelButton Programa3 = Platform.Current.Create<ILabelButton>();
			Programa3.Click += Programa3_Click;
			Programa3.Text = "18 de Marzo del 2016";
			Programa3.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabelButton Programa4 = Platform.Current.Create<ILabelButton>();
			Programa4.Click += Programa4_Click;
			Programa4.Text = "17 de Marzo del 2016";
			Programa4.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabelButton Programa5 = Platform.Current.Create<ILabelButton>();
			Programa5.Text = "16 de Marzo del 2016";
			Programa5.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Cerrar";
			cmdClose.Height = 40;
			cmdClose.BackgroundColor = new Color(255, 255, 0, 255);
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

