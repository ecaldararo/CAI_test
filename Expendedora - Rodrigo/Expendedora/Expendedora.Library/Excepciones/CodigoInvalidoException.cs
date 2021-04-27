using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Excepciones
{
    public class CodigoInvalidoException : Exception
    {
        public CodigoInvalidoException(string message) : base(message) { }

        public CodigoInvalidoException() : base() { }
    }
}
