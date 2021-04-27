using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaBotones.Controles.Exepciones
{
    public class CodigoBotonInexistenteException : Exception
    {
        public CodigoBotonInexistenteException(string msg) : base(msg)
        {

        }
        public CodigoBotonInexistenteException() : base("El código de botón no existe.")
        {

        }
    }

}
