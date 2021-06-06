using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SucursalControlador
    {

        private int _id;
        private string _direccion;
        public List<Persona> _personas;

        public SucursalControlador(int id, string direccion)
        {
            _id = id;
            _direccion = direccion;
            _personas = new List<Persona>();
        }

        public void AgregarPersonas(Persona p)
        {
            if (p != null)
                _personas.Add(p);
            else
                throw new Exception("No es una persona");
        }

        public List<Persona> ListaPersonas()
        {
            return _personas;
        }

        
    }
}
