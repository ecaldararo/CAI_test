using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expendedora.Library.Entidades;
using Expendedora.Library.Excepciones;
using ConsolaGenerico;
using Expendedora.Library.Modelos;

namespace Expendedora.Interfaz
{
    class Program
    {
        static private ExpendedoraMaq expendedora; // ¿Está bien esto definido acá? Sino tendría que pasarlo por todos lados
        
        static Program()
        {
            expendedora = new ExpendedoraMaq("ExpendedorasAsociadas", 10); // 0x5555
        }

        static void Main(string[] args)
        {
            bool terminarPrograma = false;

            do
            {
                ImprimirMenu();

                try
                {
                    EjecutarOpcion(LeerOpcion(), out terminarPrograma);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }

            } while (!terminarPrograma);
        }

        static void EjecutarOpcion(int opcion, out bool terminarPrograma)
        {
            terminarPrograma = false;

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    EncenderExpendedora();
                    break;
                case 2:
                    ListarStock();
                    break;
                case 3:
                    AgregarLata();
                    break;
                case 4:
                    ComprarLata();
                    break;
                case 5:
                    VerBalance();
                    break;
                case 6:
                    VerDescripcionCompleta();
                    break;
                case 7:
                    terminarPrograma = true;
                    break;
                default:
                    Consola.ImprimirError("Operación inválida.");
                    break;
            }
        }

        private static void ComprarLata()
        {
            string codigo;
            Lata lata;
            double dineroDelUsuario;

            // Listar latas
            Console.Clear();
            Console.WriteLine("=== COMPRAR LATA === \n");
            ListarStock();

            // Elegir lata
            try
            {
                codigo = Consola.LeerString("código de lata", false);
            

                // Buscar lata
                lata = expendedora.BuscarLata(codigo);
                if(lata == null)
                {
                    Consola.ImprimirError($"El tipo de lata \"{codigo}\" no se encuentra en la expendedora.");
                    return;
                }
                else if(lata.Cantidad <= 0) 
                {
                    Consola.ImprimirError($"No hay stock disponible de \"{lata.Nombre}\".");
                    return;
                }


                // Pedir dinero
                dineroDelUsuario = Consola.LeerDouble("su dinero");
                if(dineroDelUsuario < lata.Precio)
                {
                    Consola.ImprimirError($"Dinero insuficiente.");
                    return;
                }

                // Recibir dinero e imprimir
                DevolucionMaquina devolucionMaquina = expendedora.ComprarLata(codigo, dineroDelUsuario);
                Console.WriteLine($"\nSu lata: {devolucionMaquina.Lata.ToString()} y su vuelto {devolucionMaquina.Vuelto.ToString("$0.00")}");
            }
            catch (ParametroInvalidoException e)
            {
                Consola.ImprimirError(e.Message);
                return;
            }
            catch (ExpendedoraApagadaException e)
            {
                Consola.ImprimirError(e.Message);
                return;
            }
            catch (Exception e)
            {
                Consola.ImprimirError(e.Message);
                return;
            }
        }

        private static void AgregarLata()
        {
            Console.WriteLine("AGREGAR LATA\n");

            try
            {
                expendedora.AgregarLata(
                    Consola.LeerString("código", false),
                    Consola.LeerString("nombre", false),
                    Consola.LeerString("sabor", true),
                    Consola.LeerDouble("precio", false, false),
                    Consola.LeerDouble("volumen", false, false),
                    Consola.LeerInt("cantidad", false, true));
            }
            catch (Exception e)
            {
                Consola.ImprimirError(e.Message);
            }
            

        }

        private static void VerBalance()
        {
            try
            {
                Console.WriteLine($"La expendedora tiene {expendedora.ContarLatas()} latas y un balance de ${expendedora.Balance}.");
            }
            catch (ExpendedoraApagadaException e)
            {
                Consola.ImprimirError(e.Message);
            }
            return;
        }

        private static void VerDescripcionCompleta()
        {
            try
            {
                List<string> lista = expendedora.VerStockYDescripcion();

                Console.Clear();
                Console.WriteLine("LISTA COMPLETA:");
                foreach(string item in lista)
                {
                    Console.WriteLine($"{item}");
                }
            }
            catch (ExpendedoraApagadaException e)
            {

                Consola.ImprimirError(e.Message);
            }
            catch (SinStockException e)
            {

                Consola.ImprimirError(e.Message);
            }
            catch (Exception e)
            {

                Consola.ImprimirError(e.Message);
            }

        }

        private static void EncenderExpendedora()
        {
            if(expendedora != null)
            {
                expendedora.Encender();
                Console.WriteLine("Expendedora encendida.");
            }
            else
            {
                Consola.ImprimirError("Se intentó encender una expendedora NULL.");
            }
        }

        private static void ListarStock()
        {
            if (expendedora != null)
            {
                List<string> lista;

                try
                {
                    lista = expendedora.ListarLatasDisponibles();

                    if (lista.Count == 0)
                    {
                        Console.WriteLine("No hay latas cargadas en la expendedora.");
                    }
                    else
                    {
                        Console.WriteLine("LISTADO:");
                    }

                    foreach (string item in lista)
                    {
                        Console.WriteLine("  " + item);
                    }
                }
                catch (SinStockException e)
                {
                    Consola.ImprimirError(e.Message);
                }
                catch (Exception e)
                {
                    Consola.ImprimirError(e.Message);
                }
            }
            else
            {
                Consola.ImprimirError("Se intentó listar latas de una expendedora NULL.");
            }
        }

        static int LeerOpcion()
        {
            int opcion;
            Console.Write("Ingresar opción: ");
            int.TryParse(Console.ReadLine(), out opcion);
            return opcion;
        }
        static void ImprimirMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Encender máquina");
            Console.WriteLine("2. Listar latas disponibles");
            Console.WriteLine("3. Agregar lata");
            Console.WriteLine("4. Comprar lata");
            Console.WriteLine("5. Ver balance");
            Console.WriteLine("6. Ver stock y descripción completas");
            Console.WriteLine("7. Salir");
            Console.WriteLine("=============");

            //string titulo = "=== MENU ===";
            //string footer = "=============";
            //List<string> items = new List<string>
            //{
            //    "Encender máquina",
            //    "Listar latas disponibles",
            //    "Agregar lata",
            //    "Comprar lata",
            //    "Salir"
            //};

            //Consola.ImprimirMenu(items, titulo, footer);


        }
    }
}
