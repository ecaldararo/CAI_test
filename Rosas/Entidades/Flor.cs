using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Flor : Vegetal
    {
        protected int altura;
        protected int id;
        protected string _nombre;

        public Flor(string nombre)
        {
            _nombre = nombre;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }

        public override string GetFamilia()
        {
            return _familia;
        }
    }
}
