using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Rosas.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            Flor flor1 = new Flor("florPadre");

            Rosa rosa1 = new Rosa("rosaHija");

            Flor flor2 = new Rosa("florInstanciadaComoRosa",3);

            Rosa rosa2 = (Rosa)flor2;

            

            try
            {
                MostrarRosa(rosa1);
                MostrarRosa(rosa2); //flor casteada e instanciada como rosa

                MostrarFlor(flor1);
                MostrarFlor(flor2);

                MostrarRosa((Rosa)flor1); //Error en tiempo de ejecución
                MostrarRosa((Rosa)flor2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

            Console.ReadKey();

        }

        static void MostrarRosa(Rosa rosa)
        {
            Console.WriteLine("Nombre: "+rosa.Nombre+"- Cant. Espinas: "+rosa.CantEspinas);
        }

        static void MostrarFlor(Flor flor)
        {
            Console.WriteLine("Nombre: " + flor.Nombre);
        }
    }
}
