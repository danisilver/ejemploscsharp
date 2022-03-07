using System;
using System.Collections.Generic;
using System.Linq;
using e54.Models;
using Realms;

namespace e54.Repositories
{
    public class RepositoryRealm
    {
        private Realm conexionRealm;
        private Transaction transaction;

        public RepositoryRealm()
        {
            conexionRealm = Realm.GetInstance();
        }

        public List<Personaje> GetPersonajes()
        {
            return conexionRealm.All<Personaje>().ToList();
        }

        public Personaje BuscarPersonaje(int id)
        {
            return GetPersonajes().FirstOrDefault(z => z.IdPersonaje == id);
        }

        public int GetMaximoIdPersonaje()
        {
            return GetPersonajes().Count;
        }

        public void InsertarPersonaje(Personaje p)
        {
            transaction = conexionRealm.BeginWrite();
            var entry = conexionRealm.Add(p);
            transaction.Commit();
        }

        public void ModificarPersonaje(Personaje p)
        {
            Personaje personaje = BuscarPersonaje(p.IdPersonaje);
            using(var trans = conexionRealm.BeginWrite())
            {
                personaje.Nombre = p.Nombre;
                personaje.Serie = p.Serie;
                trans.Commit();
            }
        }

        public void EliminarPersonaje(int idPersonaje)
        {
            Personaje personaje = BuscarPersonaje(idPersonaje);
            if (personaje == null) return;

            using(var trans = conexionRealm.BeginWrite())
            {
                conexionRealm.Remove(personaje);
                trans.Commit();
            }
        }
    }
}
