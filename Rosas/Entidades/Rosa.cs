using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Rosa : Flor
    {
        int _cantEspinas;

        public Rosa(string nombre) : base(nombre)
        {
            //Nombre = nombre; No hace falta, porque lo asigna con el padre
        }

        public Rosa(string nombre, int esp) : this(nombre)
        {
            this._cantEspinas = esp;
        }

        public int CantEspinas { get => _cantEspinas; set => _cantEspinas = value; }
        public int Altura { get => altura; set => altura = value; }
        public int Id { get => id; set => id = value; }

        public override string GetFamilia()
        {
            return $"Familia de la Rosa: {_familia}";
        }

    }
}
