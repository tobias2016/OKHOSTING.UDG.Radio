using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{
	public class ProgramasController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		protected IImage BackgroundImage;

		public override void Start()
		{
			base.Start ();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon2--49.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://app-udg.okhosting.com/iconos%20new/app-09.png"));
			cmdProgramas.Width = 80;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			panel.Add(cmdProgramas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Regionales = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://app-udg.okhosting.com/iconos%20new/app-17.png"));
			Regionales.Width = 80;
			panel.Add(Regionales, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.TopWith);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://app-udg.okhosting.com/iconos%20new/app-18.png"));
			Virtuales.Width = 80;
			panel.Add(Virtuales, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Archivo de programas";
			lblLabel.Width = 240;
			lblLabel.Height = 20;
			lblLabel.FontColor = new Color(1, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, cmdProgramas);

			ILabel lblLabels = Platform.Current.Create<ILabel>();
			lblLabels.Text = "";
			lblLabels.Height = 50;
			lblLabels.Width = 20;
			panel.Add(lblLabels, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			ILabelButton Programa1 = Platform.Current.Create<ILabelButton>();
			Programa1.Click += (object sender, EventArgs e) => new AcordeonController().Start();
			Programa1.Text = "El acordeon";
			Programa1.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa1, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabels);

			ILabel lblLabel2 = Platform.Current.Create<ILabel>();
			lblLabel2.Text = "";
			lblLabels.Height = 50;
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabelButton Programa2 = Platform.Current.Create<ILabelButton>();
			//Programa2.Click += Programa2_Click;
			Programa2.Text = "Teleferico";
			Programa2.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabel lblLabel3 = Platform.Current.Create<ILabel>();
			lblLabel3.Text = "";
			lblLabels.Height = 50;
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabelButton Programa3 = Platform.Current.Create<ILabelButton>();
			//Programa3.Click += Programa3_Click;
			Programa3.Text = "El despeñadero";
			Programa3.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabel lblLabel4 = Platform.Current.Create<ILabel>();
			lblLabel4.Text = "";
			lblLabels.Height = 30;
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabelButton Programa4 = Platform.Current.Create<ILabelButton>();
			//Programa4.Click += Programa4_Click;
			Programa4.Text = "El ritual de lo habitual";
			Programa4.FontColor = new Color(1, 255, 255, 255);
			panel.Add(Programa4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabel lblLabel5 = Platform.Current.Create<ILabel>();
			lblLabel5.Text = "";
			lblLabels.Height = 30;
			panel.Add(lblLabel5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);

			ILabelButton Programa5 = Platform.Current.Create<ILabelButton>();
			Programa5.Text = "El expreso de las 10";
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
	}
}

