using Clases.Library1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases.PrimeraClase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una palabra de menos de 4 letras");
            string palabra = Console.ReadLine();

            if (TextValidator.ValidarLongitudMaxima(palabra, 4))
                Console.WriteLine("Superó o igual");
            else
                Console.WriteLine("No superó");


            Console.ReadKey();
        }
    }
}
