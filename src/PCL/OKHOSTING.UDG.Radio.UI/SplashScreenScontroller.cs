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

			IStack stack = Platform.Current.Create<IStack> ();
			stack.BackgroundColor = new Color(255, 255, 255, 255);

			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = "\n\nRadio Universidad De Guadalajara";
			lblTitulo.FontColor = Constantes.FontColor1;
			lblTitulo.FontSize = 20;
			lblTitulo.Bold = true;
			lblTitulo.FontFamily = Constantes.FontFamily;
			lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			stack.Children.Add(lblTitulo);

			IImageButton imglogo = Platform.Current.Create<IImageButton>();
			imglogo.Width = Platform.Current.Page.Width * 0.7;
			imglogo.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--01.png"));
			imglogo.Click += Logo_Click;
			stack.Children.Add(imglogo);

			ILabel lblTocar = Platform.Current.Create<ILabel>();
			lblTocar.Text = "Presiona la imagen para continuar";
			lblTocar.FontColor = Constantes.FontColor1;
			lblTocar.FontSize = Constantes.FontSize1;
			lblTocar.FontFamily = Constantes.FontFamily;
			lblTocar.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTocar.TextVerticalAlignment = VerticalAlignment.Top;
			stack.Children.Add(lblTocar);

			Platform.Current.Page.Title = "Radio Universidad de Guaralajara";
			Platform.Current.Page.Content = stack;
		}

		private void Logo_Click(object sender, EventArgs e)
		{
			Finish();
			new HomeController().Start();
		}
	}
}