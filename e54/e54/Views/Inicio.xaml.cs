using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using e54.Models;
using e54.Repositories;
using e54.ViewModels;

namespace e54.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private RepositoryRealm repo;

        public Inicio()
        {
            InitializeComponent();
            this.repo = new RepositoryRealm();
            this.botondetalles.Clicked += Botondetalles_Clicked;
            this.botoneliminar.Clicked += Botoneliminar_Clicked;
            this.botoninsertar.Clicked += Botoninsertar_Clicked;
            this.botonmodificar.Clicked += Botonmodificar_Clicked;
            this.botonmostrarregistros.Clicked += Botonmostrarregistros_Clicked;
        }

        private async void Botoninsertar_Clicked(object sender, EventArgs e)
        {
            InsertarPersonaje insertview = new InsertarPersonaje();
            await Navigation.PushModalAsync(insertview);
        }

        private async void Botonmostrarregistros_Clicked(object sender, EventArgs e)
        {
            PersonajesView listaview = new PersonajesView();
            await Navigation.PushModalAsync(listaview);
        }

        private async void Botondetalles_Clicked(object sender, EventArgs e)
        {
            DetallesPersonaje detailsview = new DetallesPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            detailsview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(detailsview);
        }

        private async void Botonmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarPersonaje updateview = new ModificarPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            updateview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(updateview);
        }

        private async void Botoneliminar_Clicked(object sender, EventArgs e)
        {
            EliminarPersonaje deleteview = new EliminarPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            deleteview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(deleteview);
        }
    }
}
