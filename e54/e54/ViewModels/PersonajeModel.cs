using System;
using Realms;
using e54.Models;
using Xamarin.Forms;
using e54.Repositories;

namespace e54.ViewModels
{
    public class PersonajeModel: ViewModelBase
    {
        private RepositoryRealm repo;
        private Personaje _Personaje;
        private string _Mensaje;

        public PersonajeModel()
        {
            repo = new RepositoryRealm();
            Personaje = new Personaje();
        }

        public Personaje Personaje
        {
            get { return _Personaje; }
            set
            {
                _Personaje = value;
                OnPropertyChanged("Personaje");
            }
        }

        public String Mensaje
        {
            get { return _Mensaje; }
            set
            {
                _Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        public Command InsertarDato
        {
            get
            {
                return new Command(() =>
                {
                    repo.InsertarPersonaje(Personaje);
                    Mensaje = "Dato insertado";
                });
            }
        }

        public Command ModificarDato
        {
            get
            {
                return new Command(()=> {
                    repo.ModificarPersonaje(Personaje);
                    Mensaje = "Dato modificado";
                });
            }
        }

        public Command EliminarDato
        {
            get
            {
                return new Command(() => {
                    repo.EliminarPersonaje(Personaje.IdPersonaje);
                    Mensaje = "Dato eliminado";
                });
            }
        }

    }
}
