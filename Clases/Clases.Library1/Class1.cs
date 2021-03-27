using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Library1
{
    public class TextValidator
    {
        public static string Start()
        {
            return "Hola";
        }

        public static bool ValidarLongitudMaxima(string palabra, int LongitudMaxima)
        {
            return (palabra.Length > LongitudMaxima);
        }

        public void SetModelo(string elModelo)
        {
            if (string.IsNullOrEmpty(elModelo))
            {
                elModelo = " ";
            }
            else
            {
                elModelo = elModelo.ToUpper();
            }
        }
    }
}
