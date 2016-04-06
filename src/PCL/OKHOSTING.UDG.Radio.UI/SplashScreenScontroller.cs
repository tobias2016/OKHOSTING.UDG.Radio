using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio.UI
{
    public class SplashScreenScontroller: Controller
    {
        public override void Start()
        {
            base.Start();

			IGrid grdGrid = Platform.Current.Create<IGrid> ();
			grdGrid.ColumnCount = 1;
			grdGrid.RowCount = 5;

			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = "Radio Universidad De Guadalajara";
			lblTitulo.FontColor = new Color(255, 230, 230, 230);
			lblTitulo.FontSize = 14;
			lblTitulo.Bold = true;
			lblTitulo.FontFamily = "Arial";
			lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			lblTitulo.Margin = new Thickness (0, 25, 0, 0);
			grdGrid.SetContent (0, 0, lblTitulo);

            IImageButton imglogo = Platform.Current.Create<IImageButton>();
			imglogo.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon2--01.png"));
			imglogo.Click += Logo_Click;
			grdGrid.SetContent (1, 0, imglogo);

			ILabel lblTocar = Platform.Current.Create<ILabel> ();
			lblTocar.Text = "Presiona la imagen para continuar";
			lblTocar.FontColor = new Color (255, 255, 255, 255);
			lblTocar.FontSize = 12;
			lblTocar.FontFamily = "Arial";
			lblTocar.Margin = new Thickness (0, 25, 0, 0);
			lblTocar.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTocar.TextVerticalAlignment = VerticalAlignment.Top;
			lblTocar.Margin = new Thickness(0, 35, 0, 0);
			grdGrid.SetContent (2, 0, lblTocar);

            Platform.Current.Page.Title = "Radio Universidad de Guaralajara";
			Platform.Current.Page.Content = grdGrid;
            //System.Threading.Tasks.Task.Delay(1000).Wait();
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Finish();
            new HomeController().Start();
        }
    }
}