using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vegetal
    {
        protected string _familia;

        public abstract string GetFamilia();
 
        public override string ToString()
        {
            return $"{_familia}";
        }
    }
}