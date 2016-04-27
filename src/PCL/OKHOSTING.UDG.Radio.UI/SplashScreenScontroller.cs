using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UDG.Radio.UI
{
	public class SplashScreenScontroller: Controller
	{
		public override void Start()
		{
			base.Start();

			IGrid grdGrid = Platform.Current.Create<IGrid> ();
			grdGrid.ColumnCount = 1;
			grdGrid.RowCount = 3;
			grdGrid.BackgroundColor = new Color(255, 255, 255, 255);

			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = "Radio Universidad De Guadalajara";
			lblTitulo.FontColor = Constantes.FontColor1;
			lblTitulo.FontSize = 20;
			lblTitulo.Bold = true;
			lblTitulo.FontFamily = Constantes.FontFamily;
			lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			grdGrid.SetContent (0, 0, lblTitulo);

			IImageButton imglogo = Platform.Current.Create<IImageButton>();
			imglogo.Width = Platform.Current.Page.Width * 0.8;
			imglogo.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--01.png"));
			imglogo.Click += Logo_Click;
			grdGrid.SetContent (1, 0, imglogo);

			ILabel lblTocar = Platform.Current.Create<ILabel> ();
			lblTocar.Text = "Presiona la imagen para continuar";
			lblTocar.FontColor = Constantes.FontColor1;
			lblTocar.FontSize = Constantes.FontSize1;
			lblTocar.FontFamily = Constantes.FontFamily;
			lblTocar.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTocar.TextVerticalAlignment = VerticalAlignment.Top;
			grdGrid.SetContent (2, 0, lblTocar);

			Platform.Current.Page.Title = "Radio Universidad de Guaralajara";
			Platform.Current.Page.Content = grdGrid;
		}

		private void Logo_Click(object sender, EventArgs e)
		{
			Finish();
			new HomeController().Start();
		}
	}
}