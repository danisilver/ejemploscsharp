using System;
using Realms;
using e54.Repositories;
using e54.ViewModels;
using System.Collections.ObjectModel;
using e54.Models;

namespace e54.ViewModels
{
    public class PersonajesViewModel: ViewModelBase
    {
        private RepositoryRealm repo;
        private ObservableCollection<Personaje> _Personajes;

        public ObservableCollection<Personaje> Personajes
        {
            get { return _Personajes; }
            set {
                _Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }

        public PersonajesViewModel()
        {
            repo = new RepositoryRealm();
            Personajes = new ObservableCollection<Personaje>(repo.GetPersonajes());
        }
    }
}