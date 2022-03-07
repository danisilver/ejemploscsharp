using System;
using Realms;

namespace e54.Models
{
    public class Personaje : RealmObject
    {
        public int IdPersonaje {get; set;}
        public String Nombre { get; set; }
        public String Serie { get; set; }
    }
}
