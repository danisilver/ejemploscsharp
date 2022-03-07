using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Xml.Linq;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace e51
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.btnBuscar.Clicked += buscarPeli;
        }

        public void buscarPeli(Object sender, EventArgs e)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("e51.Files.Novedades.xml");
            String contenido = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                contenido = reader.ReadToEnd();
            }

            //-----Conversion a XML ------
            XDocument docxml = XDocument.Parse(contenido);
            var consulta = from datos in docxml.Descendants("TITULOS")
                           where datos.Element("GENERO").Value == txtCriterioBusqueda.Text
                           select new Pelicula
                           {
                               ///Obtención del atributo:
                               tituloPelicula = datos.Attribute("PELICULA").Value,
                               //Obtencion de los elementos:
                               distribuidorPelicula = datos.Element("DISTRIBUIDOR").Value,
                               precioPelicula = datos.Element("PRECIO").Value,
                               anoPelicula = datos.Element("ANNO").Value,
                               generoPelicula = datos.Element("GENERO").Value,
                               argumentoPelicula = datos.Element("ARGUMENTO").Value,
                               directorPelicula = datos.Element("DIRECTOR").Value,
                               actoresPelicula = datos.Element("ACTORES").Value,
                               imagenPelicula = datos.Element("IMAGEN").Value
                           };
            List<Pelicula> listaPeliculas = consulta.ToList();
            lsvListado.ItemsSource = listaPeliculas;
        }
    }
}
