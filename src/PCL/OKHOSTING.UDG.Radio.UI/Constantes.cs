using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UDG.Radio.UI
{
	public static class Constantes
	{
		public static readonly Color FontColor1 = new Color(255, 0, 0, 0);
		public static readonly Color FontColor2 = new Color(255, 20, 20, 20);
		public static readonly Color FontColor3 = new Color(255, 50, 50, 50);

		public static int FontSize1
		{
			get
			{
				return 16;
			}
		}

		public static int FontSize2
		{
			get
			{
				return 14;
			}
		}

		public static int FontSize3
		{
			get
			{
				return 12;
			}
		}

		public static double AnchoIconos
		{
			get
			{
				double ancho = Platform.Current.Page.Width * .2;

				if (ancho > 50)
				{
					ancho = 50;
				}

				return ancho;
			}
		}

        public const string FontFamily = "Arial";

		public static IGrid CrearMenuVacio()
		{
			IGrid grdMenu = Platform.Current.Create<IGrid>();
			grdMenu.RowCount = 3;
			grdMenu.ColumnCount = 4;
			grdMenu.Height = 90;
			grdMenu.Width = Platform.Current.Page.Width;
			grdMenu.BackgroundColor = new Color(255, 50, 50, 50);

			return grdMenu;
		}

		public static ILabel CrearTitulo(string texto, Color fondo)
		{
			ILabel lblTitulo = Platform.Current.Create<ILabel>();
			lblTitulo.Text = texto;
			lblTitulo.Width = Platform.Current.Page.Width;
			lblTitulo.FontFamily = Constantes.FontFamily;
			lblTitulo.FontSize = Constantes.FontSize1;
			lblTitulo.Height = 70;
			lblTitulo.Bold = true;
			lblTitulo.BackgroundColor = fondo;
			lblTitulo.FontColor = Constantes.FontColor1;
			lblTitulo.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblTitulo.TextVerticalAlignment = VerticalAlignment.Center;
			lblTitulo.Margin = new Thickness(0, 0, 0, 20);

			return lblTitulo;
		}
	}
}