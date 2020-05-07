using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisacion
{
    [Serializable]
    class Persona
    {
        public string Nombre;
        public string Apellido;
        public int edad;
        public List<Persona> todas_las_personas = new List<Persona>();

        public Persona(string nom, string ape,int ed)
        {
            Nombre = nom;
            Apellido = ape;
            edad = ed;
        }
        public Persona()
        {

        }

    }
}
