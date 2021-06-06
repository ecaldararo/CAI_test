using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sucursal
    {
        private int _id;
        private string _direccion;
        public List<Persona> _personas;

        public Sucursal(int id, string direccion)
        {
            _id = id;
            _direccion = direccion;
            _personas = new List<Persona>();
        }
    }
}
