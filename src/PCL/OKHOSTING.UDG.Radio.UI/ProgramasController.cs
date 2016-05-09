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
		protected HomeController HomeController;

		protected static IControl Cache;

		public ProgramasController(HomeController home)
		{
			HomeController = home;
		}

		public override void Start()
		{
			base.Start ();

			Platform.Current.Page.Title = "Selecciona un programa";

			if (Cache != null) 
			{
				Platform.Current.Page.Content = Cache;
				return;
			}
			
			#region lista de programas

			IList<Show> programas = new List<Show> ();
			Show programa1 = new Show ();
			programa1.Id = 1;
			programa1.Name = "Aniversario 41";
			programa1.Description = "¡Radio Maratón de Aniversario!";
			programa1.LogoUri = new Uri ("http://udgtv.com/sites/default/files/41.jpg");
			programa1.PodcastUri = new Uri ("http://podcastudg.com/41/aniversario.xml");

			programas.Add (programa1);

			Show programa2 = new Show ();
			programa2.Id = 2;
			programa2.Name = "Azul";
			programa2.Description = "El color del Blues";
			programa2.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Azul.jpg");
			programa2.PodcastUri = new Uri ("http://podcastudg.com/azul.xml");

			programas.Add (programa2);

			Show programa3 = new Show ();
			programa3.Id = 3;
			programa3.Name = "Birula Radio";
			programa3.Description = "En vivo 10 am 104.3 fm";
			programa3.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Birula_Radio_1_2.jpg");
			programa3.PodcastUri = new Uri ("http://podcastudg.com/birularadio.xml");

			programas.Add (programa3);

			Show programa4 = new Show ();
			programa4.Id = 4;
			programa4.Name = "Cátedra Julio Cortázar";
			programa4.Description = "La Estacion del Mundo";
			programa4.LogoUri = new Uri ("http://udgtv.com/sites/default/files/2catedras.jpg");
			programa4.PodcastUri = new Uri ("http://podcastudg.com/catedras/catedras_jcortazar.xml");

			programas.Add (programa4);

			Show programa5 = new Show ();
			programa5.Id = 5;
			programa5.Name = "Casa de Tinte";
			programa5.Description = "Revista radiofónica";
			programa5.LogoUri = new Uri ("http://udgtv.com/sites/default/files/CazaTinta_1.jpg");
			programa5.PodcastUri = new Uri ("http://podcastudg.com/cazadetinta.xml");

			programas.Add (programa5);

			Show programa6 = new Show ();
			programa6.Id = 6;
			programa6.Name = "Cobertura FICG 31";
			programa6.Description = "Festival Internacional de Cine en Guadalajara";
			programa6.LogoUri = new Uri ("http://udgtv.com/sites/default/files/31.jpg");
			programa6.PodcastUri = new Uri ("http://podcastudg.com/31/coberturaficg.xml");

			programas.Add (programa6);

			Show programa7 = new Show ();
			programa7.Id = 7;
			programa7.Name = "Cobertura FIL 2015";
			programa7.Description = "Feria Internacional del Libro en Guadalajara";
			programa7.LogoUri = new Uri ("http://udgtv.com/sites/default/files/fil2015.jpg");
			programa7.PodcastUri = new Uri ("http://podcastudg.com/FIL2015/CoberturaFIL.xml");

			programas.Add (programa7);

			Show programa8 = new Show ();
			programa8.Id = 8;
			programa8.Name = "Cobertura LéaLA";
			programa8.Description = "Feria del Libro en Español de Los Ángeles";
			programa8.LogoUri = new Uri ("http://udgtv.com/sites/default/files/leala.jpg");
			programa8.PodcastUri = new Uri ("http://podcastudg.com/leala/cobertura_leala.xml");

			programas.Add (programa8);

			Show programa9 = new Show ();
			programa9.Id = 9;
			programa9.Name = "Cosa Publica 2.0";
			programa9.Description = "Todos hacen política";
			programa9.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_CP%C3%BAblica.jpg");
			programa9.PodcastUri = new Uri ("http://podcastudg.com/cosapublica.xml");

			programas.Add (programa9);

			Show programa10 = new Show ();
			programa10.Id = 10;
			programa10.Name = "Dejalo Sangrar";
			programa10.Description = "Música contemporánea";
			programa10.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_DSangrar.jpg");
			programa10.PodcastUri = new Uri ("http://podcastudg.com/dejalosangrar.xml");

			programas.Add (programa10);

			Show programa11 = new Show ();
			programa11.Id = 11;
			programa11.Name = "Diálogos del Pensamiento";
			programa11.Description = "Ciencias Sociales y Humanidades";
			programa11.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Di%C3%A1logos.jpg");
			programa11.PodcastUri = new Uri ("http://podcastudg.com/dialogosdelpensamiento.xml");

			programas.Add (programa11);

			Show programa12 = new Show ();
			programa12.Id = 12;
			programa12.Name = "Dimensión Colorida";
			programa12.Description = "Un programa infantil temático";
			programa12.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Colorida.jpg");
			programa12.PodcastUri = new Uri ("http://podcastudg.com/dimension.xml");

			programas.Add (programa12);

			Show programa13 = new Show ();
			programa13.Id = 13;
			programa13.Name = "El Acordeón";
			programa13.Description = "Pliegues bizantinos de la conversación";
			programa13.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Acorde%C3%B3n.jpg");
			programa13.PodcastUri = new Uri ("http://podcastudg.com/acordeon.xml");

			programas.Add (programa13);

			Show programa14 = new Show ();
			programa14.Id = 14;
			programa14.Name = "El Buskaribe";
			programa14.Description = "Un programa de radio con Música";
			programa14.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Buskaribe.jpg");
			programa14.PodcastUri = new Uri ("http://podcastudg.com/buskaribe.xml");

			programas.Add (programa14);

			Show programa15 = new Show ();
			programa15.Id = 15;
			programa15.Name = "El Despeñadero";
			programa15.Description = "La mejor programacion de Metal";
			programa15.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Despe%C3%B1adero.jpg");
			programa15.PodcastUri = new Uri ("http://podcastudg.com/despe%C3%B1adero.xml");

			programas.Add (programa15);

			Show programa16 = new Show ();
			programa16.Id = 16;
			programa16.Name = "El Expresso de las 10:00";
			programa16.Description = "Es un espacio para la expresión";
			programa16.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Exp10.jpg");
			programa16.PodcastUri = new Uri ("http://podcastudg.com/servicio.xml");

			programas.Add (programa16);

			Show programa17 = new Show ();
			programa17.Id = 17;
			programa17.Name = "El Ojo de Venus";
			programa17.Description = "Anécdotas, literatura y música cachondas";
			programa17.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Ojo_Venus_3.jpg");
			programa17.PodcastUri = new Uri ("http://podcastudg.com/ojodevenus.xml");

			programas.Add (programa17);

			Show programa18 = new Show ();
			programa18.Id = 18;
			programa18.Name = "El Pórtico De Los Cínicos";
			programa18.Description = "Hombres que libremente construyan sus creencias";
			programa18.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_podcast_Port.jpg");
			programa18.PodcastUri = new Uri ("http://podcastudg.com/cinicos.xml");

			programas.Add (programa18);

			Show programa19 = new Show ();
			programa19.Id = 19;
			programa19.Name = "El Punto de la Aurora";
			programa19.Description = "Dark Wave y sus afines";
			programa19.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Aurora.jpg");
			programa19.PodcastUri = new Uri ("http://podcastudg.com/puntodelaaurora.xml");

			programas.Add (programa19);

			Show programa20 = new Show ();
			programa20.Id = 20;
			programa20.Name = "Informe de Actividades 2015-2016";
			programa20.Description = "Desde el teatro Diana";
			programa20.LogoUri = new Uri ("http://udgtv.com/sites/default/files/informe_0.jpg");
			programa20.PodcastUri = new Uri ("http://podcastudg.com/esp/informe.xml");

			programas.Add (programa20);

			Show programa21 = new Show ();
			programa21.Id = 21;
			programa21.Name = "Jamáfrica";
			programa21.Description = "La unión de Jamaica y África";
			programa21.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Jamafrica_3.jpg");
			programa21.PodcastUri = new Uri ("http://podcastudg.com/jamafrica.xml");

			programas.Add (programa21);

			Show programa22 = new Show ();
			programa22.Id = 22;
			programa22.Name = "La Chora Interminable";
			programa22.Description = "No diga \"interminagle\" ...no diga \"interminuble\"...diga...Interminable ";
			programa22.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Chora.jpg");
			programa22.PodcastUri = new Uri ("http://podcastudg.com/chora.xml");

			programas.Add (programa22);

			Show programa23 = new Show ();
			programa23.Id = 23;
			programa23.Name = "La Corte del Rey Carmesí";
			programa23.Description = "\"La Cripta\" ya desde el año 2005";
			programa23.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Corte_Rey_Carmesi.jpg");
			programa23.PodcastUri = new Uri ("http://podcastudg.com/Lacorte.xml");

			programas.Add (programa23);

			Show programa24 = new Show ();
			programa24.Id = 24;
			programa24.Name = "La Jericalla";
			programa24.Description = "El programa que los tapatios ocupaban";
			programa24.LogoUri = new Uri ("http://udgtv.com/sites/default/files/jericalla.jpg");
			programa24.PodcastUri = new Uri ("http://podcastudg.com/lajericalla.xml");

			programas.Add (programa24);

			Show programa25 = new Show ();
			programa25.Id = 25;
			programa25.Name = "La Lengua";
			programa25.Description = "Básicamente rock en español";
			programa25.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_podcast_Lengua.jpg");
			programa25.PodcastUri = new Uri ("http://podcastudg.com/lalengua.xml");

			programas.Add (programa25);

			Show programa26 = new Show ();
			programa26.Id = 26;
			programa26.Name = "La Rocola Arrabalera";
			programa26.Description = "La Mejor música arrabalera";
			programa26.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_RArrabalera.jpg");
			programa26.PodcastUri = new Uri ("http://podcastudg.com/rocolaarrabalera.xml");

			programas.Add (programa26);

			Show programa27 = new Show ();
			programa27.Id = 27;
			programa27.Name = "Leones Negros";
			programa27.Description = "Partidos como locales de los Leones Negros";
			programa27.LogoUri = new Uri ("http://udgtv.com/sites/default/files/webradio_podcasts_0.jpg");
			programa27.PodcastUri = new Uri ("http://podcastudg.com/partidos/leonesnegros.xml");

			programas.Add (programa27);

			Show programa28 = new Show ();
			programa28.Id = 28;
			programa28.Name = "Lugar Común";
			programa28.Description = "Este es un programa de género y número";
			programa28.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_podcast_LugarC.jpg");
			programa28.PodcastUri = new Uri ("http://podcastudg.com/lugarcomun.xml");

			programas.Add (programa28);

			Show programa29 = new Show ();
			programa29.Id = 29;
			programa29.Name = "Luvina Joven";
			programa29.Description = "Luvina roven radio";
			programa29.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_LJoven_3.jpg");
			programa29.PodcastUri = new Uri ("http://podcastudg.com/luvinajoven.xml");

			programas.Add (programa29);

			Show programa30 = new Show ();
			programa30.Id = 30;
			programa30.Name = "Multiverso";
			programa30.Description = "Universitarios, colectivos y ciudadanos";
			programa30.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Multiverso_1.jpg");
			programa30.PodcastUri = new Uri ("http://podcastudg.com/multiverso.xml");

			programas.Add (programa30);

			Show programa31 = new Show ();
			programa31.Id = 31;
			programa31.Name = "Opera Radio";
			programa31.Description = "Bajo la conducción de Ernesto Álvarez";
			programa31.LogoUri = new Uri ("http://udgtv.com/sites/default/files/webradio_podcasts.jpg");
			programa31.PodcastUri = new Uri ("http://podcastudg.com/operaradio.xml");

			programas.Add (programa31);

			Show programa32 = new Show ();
			programa32.Id = 32;
			programa32.Name = "Por el Ojo de la Cerradura";
			programa32.Description = "¡Una mirada más allá de lo que ves!";
			programa32.LogoUri = new Uri ("http://udgtv.com/sites/default/files/ojo_Cerradura_1.jpg");
			programa32.PodcastUri = new Uri ("http://podcastudg.com/porelojo.xml");

			programas.Add (programa32);

			Show programa33 = new Show ();
			programa33.Id = 33;
			programa33.Name = "Punto Cinco";
			programa33.Description = "El programa que los tapatios ocupaban";
			programa33.LogoUri = new Uri ("http://udgtv.com/sites/default/files/PuntoCinco_3.jpg");
			programa33.PodcastUri = new Uri ("http://podcastudg.com/puntocinco.xml");

			programas.Add (programa33);

			Show programa34 = new Show ();
			programa34.Id = 34;
			programa34.Name = "Puro Drama";
			programa34.Description = "En la conducción Circee Rangel";
			programa34.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Puro_Drama_1.jpg");
			programa34.PodcastUri = new Uri ("http://podcastudg.com/purodrama.xml");

			programas.Add (programa34);

			Show programa35 = new Show ();
			programa35.Id = 35;
			programa35.Name = "Radio al Cubo ";
			programa35.Description = "Conducido por Enrique Blanc.";
			programa35.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Radio_Cubo_1.jpg");
			programa35.PodcastUri = new Uri ("http://podcastudg.com/radioalcubo.xml");

			programas.Add (programa35);

			Show programa36 = new Show ();
			programa36.Id = 36;
			programa36.Name = "Radio Ga Ga";
			programa36.Description = "¡Bienvenidos todos a Radio GaGa!";
			programa36.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_podcast_Gaga.jpg");
			programa36.PodcastUri = new Uri ("http://podcastudg.com/radiogaga.xml");

			programas.Add (programa36);

			Show programa37 = new Show ();
			programa37.Id = 37;
			programa37.Name = "Ruta de Evacuación";
			programa37.Description = "Experimentación sonora de los últimos 50 años";
			programa37.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Ruta_Evacuacion_4.jpg");
			programa37.PodcastUri = new Uri ("http://podcastudg.com/rutadeevacuacion.xml");

			programas.Add (programa37);

			Show programa38 = new Show ();
			programa38.Id = 38;
			programa38.Name = "Rutas de México ";
			programa38.Description = "Los pueblos de México a través de su música";
			programa38.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Rutas_Mexico_3.jpg");
			programa38.PodcastUri = new Uri ("http://podcastudg.com/nuestrasraices.xml");

			programas.Add (programa38);

			Show programa39 = new Show ();
			programa39.Id = 39;
			programa39.Name = "Señales de Humo";
			programa39.Description = "Conduce: Alfredo Sánchez";
			programa39.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_SHumo.jpg");
			programa39.PodcastUri = new Uri ("http://podcastudg.com/humo.xml");

			programas.Add (programa39);

			Show programa40 = new Show ();
			programa40.Id = 40;
			programa40.Name = "Séptimo Vicio";
			programa40.Description = "Un viaje a las pantallas de la creación";
			programa40.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_7Vicio.jpg");
			programa40.PodcastUri = new Uri ("http://podcastudg.com/septimo.xml");

			programas.Add (programa40);

			Show programa41 = new Show ();
			programa41.Id = 41;
			programa41.Name = "Solo Jazz";
			programa41.Description = "Conciertos y festivales con artistas de talla internacional";
			programa41.LogoUri = new Uri ("http://udgtv.com/sites/default/files/solo_jazz_1.jpg");
			programa41.PodcastUri = new Uri ("http://podcastudg.com/jazz.xml");

			programas.Add (programa41);

			Show programa42 = new Show ();
			programa42.Id = 42;
			programa42.Name = "Sórico";
			programa42.Description = "El feminismo y las nuevas masculinidades";
			programa42.LogoUri = new Uri ("http://udgtv.com/sites/default/files/sorico_4.jpg");
			programa42.PodcastUri = new Uri ("http://podcastudg.com/sorico.xml");

			programas.Add (programa42);

			Show programa43 = new Show ();
			programa43.Id = 43;
			programa43.Name = "Start";
			programa43.Description = "Es la mejor manera de comenzar el día";
			programa43.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Start_1.jpg");
			programa43.PodcastUri = new Uri ("http://podcastudg.com/start.xml");

			programas.Add (programa43);

			Show programa44 = new Show ();
			programa44.Id = 44;
			programa44.Name = "Territorios";
			programa44.Description = "Expresión auditiva de las Culturas Originales";
			programa44.LogoUri = new Uri ("http://udgtv.com/sites/default/files/Territorios_1.jpg");
			programa44.PodcastUri = new Uri ("http://podcastudg.com/territorios.xml");

			programas.Add (programa44);

			Show programa45 = new Show ();
			programa45.Id = 45;
			programa45.Name = "The Midnight Rambler";
			programa45.Description = "El merodeador nocturno de Radio UDG";
			programa45.LogoUri = new Uri ("http://udgtv.com/sites/default/files/midnightrambler.jpg");
			programa45.PodcastUri = new Uri ("http://podcastudg.com/rambler.xml");

			programas.Add (programa45);

			Show programa46 = new Show ();
			programa46.Id = 46;
			programa46.Name = "Tintero";
			programa46.Description = "El tintero es una revista radiofónica";
			programa46.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_Tintero_1.jpg");
			programa46.PodcastUri = new Uri ("http://podcastudg.com/tintero.xml");

			programas.Add (programa43);

			Show programa47 = new Show ();
			programa47.Id = 47;
			programa47.Name = "Versos al Viento";
			programa47.Description = "El hip hop del barrio";
			programa47.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_VViento_1.jpg");
			programa47.PodcastUri = new Uri ("http://podcastudg.com/versosalviento.xml");

			programas.Add (programa47);

			Show programa48 = new Show ();
			programa48.Id = 48;
			programa48.Name = "Vuelta a la Manzana";
			programa48.Description = "La voz de los académicos";
			programa48.LogoUri = new Uri ("http://udgtv.com/sites/default/files/WebRadio_VManzana.jpg");
			programa48.PodcastUri = new Uri ("http://podcastudg.com/vueltaalamanzana.xml");

			programas.Add (programa48);

			Show programa49 = new Show ();
			programa49.Id = 49;
			programa49.Name = "Zoom";
			programa49.Description = "Bandas locales de la ZMG";
			programa49.LogoUri = new Uri ("http://udgtv.com/sites/default/files/zoom.jpg");
			programa49.PodcastUri = new Uri ("http://podcastudg.com/zoom.xml");

			programas.Add (programa49);

			#endregion

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();
			panel.BackgroundColor = new Color (255, 255, 255, 255);
			AudioPlayer = Core.BaitAndSwitch.Create<IAudioPlayer>((IEnumerable<string>) new string[]{"Xamarin.Android", "Xamarin.iOS"});

			IGrid grdMenu = Constantes.CrearMenuVacio();
			panel.Add(grdMenu, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			IImageButton imgHome = Platform.Current.Create<IImageButton>();
			imgHome.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images/app-15.png"));
			imgHome.Click += cmdHome_Click;
			grdMenu.SetContent(1, 0, imgHome);

			IImageButton imgRegionales = Platform.Current.Create<IImageButton>();
			imgRegionales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-11.png"));
			imgRegionales.Click += cmdEstaciones_Click;
			grdMenu.SetContent(1, 1, imgRegionales);

			IImageButton cmdProgramas = Platform.Current.Create<IImageButton>();
			cmdProgramas.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-08.png"));
			grdMenu.SetContent(1, 2, cmdProgramas);

			IImageButton imgVirtuales = Platform.Current.Create<IImageButton>();
			imgVirtuales.LoadFromUrl (new Uri("http://radioudg.okhosting.com/images-old/icon-09.png"));
			imgVirtuales.Click += cmdVirtuales_Click;
			grdMenu.SetContent(1, 3, imgVirtuales);

			ILabel lblTitulo = Constantes.CrearTitulo("Archivo de Programas", new Color(230, 255, 143, 0));
			panel.Add(lblTitulo, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, grdMenu);

			if (Platform.Current.Page.Width > 250)
			{
				IImage imgLogo = Platform.Current.Create<IImage> ();
				imgLogo.LoadFromUrl (new Uri ("http://radioudg.okhosting.com/images-old/icon2--14.png"));
				imgLogo.Width = Platform.Current.Page.Width / 6;
				imgLogo.Height = lblTitulo.Height;
				imgLogo.Margin = new Thickness(0, 0, 10, 0);
				panel.Add(imgLogo, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith, lblTitulo);
			}

			IControl referencia = lblTitulo;

			foreach (Show programa in programas) 
			{
				IImageButton imgLogo = Platform.Current.Create<IImageButton>();
				imgLogo.LoadFromUrl(programa.LogoUri);
				imgLogo.Click += Programa_Click;
				imgLogo.Tag = programa;
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
				lblNombre.Click += Programa_Click;
				lblNombre.Text = programa.Name;
				lblNombre.Tag = programa;
				lblNombre.Bold = true;
				lblNombre.FontSize = Constantes.FontSize2;
				lblNombre.FontColor = Constantes.FontColor2;
				lblNombre.Width = Platform.Current.Page.Width - (Constantes.AnchoIconos * 3) + 10;
				panel.Add(lblNombre, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, imgLogo);

				ILabelButton lblDescripcion = Platform.Current.Create<ILabelButton>();
				lblDescripcion.Click += Programa_Click;
				lblDescripcion.Text = programa.Description;
				lblDescripcion.Tag = programa;
				lblDescripcion.FontSize = Constantes.FontSize3;
				lblDescripcion.FontColor = Constantes.FontColor3;
				lblDescripcion.Width = lblNombre.Width;
				panel.Add(lblDescripcion, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblNombre);

				IImageButton imgPlay = Platform.Current.Create<IImageButton>();
				imgPlay.LoadFromUrl(new Uri ("http://radioudg.okhosting.com/images-old/icon-20.png"));
				imgPlay.Click += Programa_Click;
				imgPlay.Tag = programa;
				imgPlay.Width = Constantes.AnchoIconos;
				imgPlay.Height = Constantes.AnchoIconos;

				panel.Add(imgPlay, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.TopWith, lblNombre);
			}

			Platform.Current.Page.Content = panel;
			Cache = panel;
		}

		private void cmdHome_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		private void cmdVirtuales_Click(object sender, EventArgs e)
		{
			this.Finish();
			new VirtualesController (HomeController).Start ();
		}

		private void cmdEstaciones_Click(object sender, EventArgs e)
		{
			this.Finish();
			new RegionalesController (HomeController).Start ();
		}

		public void Programa_Click(object sender, EventArgs e)
		{
			IControl control = (IControl)sender;
			Show programa = (Show)control.Tag;
			this.Finish ();

			new PodcastsController (programa, HomeController).Start ();
		}
	}
}