using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Excepciones
{
    public class DineroInsuficienteException : Exception
    {
        public DineroInsuficienteException(string message) : base(message) { }

        public DineroInsuficienteException() : base() { }
    }
}
