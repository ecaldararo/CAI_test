using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private static int _id = 0;
        private int _codigo;
        private string _nombre;
        private string _apellido;

        public Persona(string nombre, string apellido)
        {
            _id += 1;
            _codigo += _id;
            _nombre = nombre;
            _apellido = apellido;
        }

        public int Codigo { get => _codigo;  }
        public string Nombre { get => _nombre; }
        public string Apellido { get => _apellido;  }

        public override string ToString()
        {
            return $"{Codigo}) {Apellido},{Nombre}" ;
        }


    }
}
