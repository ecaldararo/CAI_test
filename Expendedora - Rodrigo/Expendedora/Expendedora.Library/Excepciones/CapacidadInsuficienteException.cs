using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Excepciones
{
    public class CapacidadInsuficienteException : Exception
    {
        public CapacidadInsuficienteException(string message) : base(message) { }

        public CapacidadInsuficienteException() : base() { }
    }
}
