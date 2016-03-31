using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI 
{
	public class VirtualesController : OKHOSTING.UI.Controller
	{
		IAudioPlayer AudioPlayer;
		protected IImage BackgroundImage;

		public override void Start()
		{
			base.Start ();

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
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			cmdProgramas.Width = 50;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new ProgramasController().Start();
			menu.SetContent (0, 1, cmdProgramas);

			IImageButton Regionales = Platform.Current.Create<IImageButton>();
			Regionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			Regionales.Width = 50;
			Regionales.Height = 35;
			//Regionales.Click += (object sender, EventArgs e) => new RegionalesController().Start();
			menu.SetContent (0, 2, Regionales);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-10.png"));
			Virtuales.Width = 50;
			Virtuales.Height = 35;
			menu.SetContent (0, 3, Virtuales);

			IGrid bgdTitulo = Platform.Current.Create<IGrid>();
			bgdTitulo.RowCount = 1;
			bgdTitulo.ColumnCount = 4;
			bgdTitulo.Height = 40;
			bgdTitulo.Width = Platform.Current.Page.Width;
			bgdTitulo.BackgroundColor = new Color(230, 255, 143, 0);
			panel.Add(bgdTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.CenterWith);

			IImage imgArchivos = Platform.Current.Create<IImage>();
			imgArchivos.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--31.png"));
			imgArchivos.Width = 25;
			imgArchivos.Height = 25;
			imgArchivos.Margin = new Thickness(5, 10, 10, 5);
			imgArchivos.Margin = new Thickness (5, 0, 10, 0);
			panel.Add(imgArchivos, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.CenterWith, bgdTitulo);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "¡PROXIMAMENTE!";
			lblLabel.Width = 140;
			lblLabel.Height = 20;
			lblLabel.FontSize = 12;
			lblLabel.Bold = true;
			lblLabel.FontColor = new Color(255, 255, 255, 255);
			lblLabel.Margin = new Thickness (0, 0, 10, 0);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.CenterWith, imgArchivos);

			IImage imgLogo = Platform.Current.Create<IImage> ();
			imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
			imgLogo.Width = 50;
			imgLogo.Height = 50;
			imgLogo.Margin = new Thickness (0, -13, 0, 0);
			panel.Add(imgLogo, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblLabel);

			/*
			IGrid pgrAcordeon = Platform.Current.Create<IGrid>();
			pgrAcordeon.RowCount = 1;
			pgrAcordeon.ColumnCount = 4;
			pgrAcordeon.Height = 50;
			pgrAcordeon.Width = Platform.Current.Page.Width;
			pgrAcordeon.BackgroundColor = new Color(1, 255, 143, 0);
			pgrAcordeon.Margin = new Thickness (0, 15, 0, 15);
			panel.Add(pgrAcordeon, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, bgdTitulo);

			IImage imgAcordeon = Platform.Current.Create<IImage>();
			imgAcordeon.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--19.png"));
			imgAcordeon.Width = 41;
			imgAcordeon.Height = 41;
			imgAcordeon.Margin = new Thickness(10, 10, 10, 5);
			panel.Add(imgAcordeon, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith, pgrAcordeon);

			ILabelButton Programa1 = Platform.Current.Create<ILabelButton>();
			Programa1.Click += (object sender, EventArgs e) => new AcordeonController().Start();
			Programa1.Text = "El acordeon";
			Programa1.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa1, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgAcordeon);

			IImage arvAcordeon = Platform.Current.Create<IImage>();
			arvAcordeon.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--28.png"));
			arvAcordeon.Width = 41;
			arvAcordeon.Height = 41;
			arvAcordeon.Margin = new Thickness(20, 0, 0, 0);
			panel.Add(arvAcordeon, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.CenterWith, Programa1);

			ILabelButton Programa2 = Platform.Current.Create<ILabelButton>();
			//Programa2.Click += Programa2_Click;
			Programa2.Text = "Teleferico";
			Programa2.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa2, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa1);

			ILabelButton Programa3 = Platform.Current.Create<ILabelButton>();
			//Programa3.Click += Programa3_Click;
			Programa3.Text = "El despeñadero";
			Programa3.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa2);

			ILabelButton Programa4 = Platform.Current.Create<ILabelButton>();
			//Programa4.Click += Programa4_Click;
			Programa4.Text = "El ritual de lo habitual";
			Programa4.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa3);

			ILabelButton Programa5 = Platform.Current.Create<ILabelButton>();
			Programa5.Text = "El expreso de las 10";
			Programa5.FontColor = new Color(255, 255, 255, 255);
			panel.Add(Programa5, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, Programa4);
			*/

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
	}
}

