using Expendedora.Library.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Modelos
{
    public class DevolucionMaquina
    {
        private double _vuelto;
        private Lata _lata;

        public DevolucionMaquina( Lata lata, double vuelto)
        {
            _vuelto = vuelto;
            _lata = lata;
        }

        public Lata Lata => _lata;
        public double Vuelto => _vuelto;
    }
}
