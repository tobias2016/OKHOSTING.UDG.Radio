﻿using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI 
{
	public class VirtualesController : OKHOSTING.UI.Controller
	{
		protected IImage BackgroundImage;
        protected static IControl Cache;

        public override void Start()
		{
			base.Start ();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color(255, 255, 255, 255);

			IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			imgHome.Width = 25;
			imgHome.Height = 25;
			imgHome.Click += cmdHome_Click;
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Width = 25;
			imgRegionales.Height = 25;
			imgRegionales.Click += cmdEstaciones_Click;
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-07.png"));
			cmdProgramas.Width = 25;
			cmdProgramas.Height = 25;
			cmdProgramas.Click += cmdProgramas_Click;
			grdMenu.SetContent(1, 2, cmdProgramas);

			IImageButton Virtuales = Platform.Current.Create<IImageButton>();
			Virtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-10.png"));
			Virtuales.Width = 25;
			Virtuales.Height = 25;
			grdMenu.SetContent(1, 3, Virtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("Estaciones Virtuales", new Color(230, 103, 57, 183));
			panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = Platform.Current.Page.Width / 6;
				imgLogo.Height = lblTitulo.Height;
				imgLogo.Margin = new Thickness (0, 0, 10, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			IControl referencia = lblTitulo;

            IList<Station> estaciones = LeerEstaciones();

            foreach (Station estacion in estaciones)
            {
                IImageButton imgLogo = Platform.Current.Create<IImageButton>();
                imgLogo.LoadFromUrl(estacion.WebSiteUri);
                imgLogo.Click += Estacion_Click;
                imgLogo.Tag = estacion;
                imgLogo.Width = Constantes.AnchoIconos;
                imgLogo.Height = Constantes.AnchoIconos;

                //set margin for first iteration
                if (referencia == lblTitulo)
                {
                    imgLogo.Margin = new Thickness(10, 10, 10, 10);
                }
                else
                {
                    imgLogo.Margin = new Thickness(0, 10, 10, 10);
                }

                panel.Add(imgLogo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, referencia);

                referencia = imgLogo;

                ILabelButton lblNombre = Platform.Current.Create<ILabelButton>();
                lblNombre.Click += Estacion_Click;
                lblNombre.Text = estacion.Name;
                lblNombre.Tag = estacion;
                lblNombre.Bold = true;
                lblNombre.FontSize = Constantes.FontSize2;
                lblNombre.FontColor = Constantes.FontColor2;
                lblNombre.Width = Platform.Current.Page.Width - (Constantes.AnchoIconos * 3) + 10;
                panel.Add(lblNombre, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogo);

                ILabelButton lblDescripcion = Platform.Current.Create<ILabelButton>();
                lblDescripcion.Click += Estacion_Click;
                lblDescripcion.Text = estacion.Description;
                lblDescripcion.Tag = estacion;
                lblDescripcion.FontSize = Constantes.FontSize3;
                lblDescripcion.FontColor = Constantes.FontColor3;
                lblDescripcion.Width = lblNombre.Width;
                panel.Add(lblDescripcion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombre);

                IImageButton imgPlay = Platform.Current.Create<IImageButton>();
                imgPlay.LoadFromUrl(new Uri("http://radioudg.okhosting.com/images-old/icon-28.png"));
                imgPlay.Click += Estacion_Click;
                imgPlay.Tag = estacion;
                imgPlay.Width = Constantes.AnchoIconos;
                imgPlay.Height = Constantes.AnchoIconos;

                panel.Add(imgPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblNombre);
            }

            Platform.Current.Page.Content = panel;
            Cache = panel;

            Platform.Current.Page.Title = "Virtuales";
			Platform.Current.Page.Content = panel;
		}

		private void cmdHome_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdProgramas_Click(object sender, EventArgs e)
		{
			this.Finish();
			new ProgramasController ().Start ();
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
			new RegionalesController ().Start ();
		}

        public void Estacion_Click(object sender, EventArgs e)
        {
            IControl control = (IControl)sender;
            Station estacion = (Station)control.Tag;
            HomeController.Current.Station = estacion;
            this.Finish();
        }

        public static List<Station> LeerEstaciones()
        {
            List<Station> estaciones = new List<Station>();
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var xmlStream = client.GetStreamAsync("http://radioudg.okhosting.com/virtuales.xml").Result;
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(xmlStream);

            //extraer episodios del xml
            while (reader.ReadToFollowing("estacion"))
            {
                Station estacion = new Station();

                reader.ReadToFollowing("imagen");
                estacion.WebSiteUri = new Uri(reader.ReadElementContentAsString());

                reader.ReadToFollowing("streaming");
                estacion.StramingUri = new Uri(reader.ReadElementContentAsString());
                
                reader.ReadToFollowing("nombre");
                estacion.Name = reader.ReadElementContentAsString();

                reader.ReadToFollowing("descripcion");
                estacion.Description = reader.ReadElementContentAsString();

                estaciones.Add(estacion);
            }

			reader.Dispose();
			xmlStream.Dispose();
			client.Dispose();

			return estaciones;
        }
    }
}