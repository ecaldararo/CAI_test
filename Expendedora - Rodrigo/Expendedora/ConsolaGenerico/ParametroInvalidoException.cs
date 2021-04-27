﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaGenerico
{
    public class ParametroInvalidoException : Exception
    {
        public ParametroInvalidoException(string mensaje) : base(mensaje) { }

        public ParametroInvalidoException() : base() { }
    }
}
