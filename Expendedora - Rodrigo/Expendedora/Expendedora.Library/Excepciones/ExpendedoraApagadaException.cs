using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Excepciones
{
    public class ExpendedoraApagadaException : Exception
    {
        public ExpendedoraApagadaException() : base("La expendedora está apagada.") { }
    }
}
