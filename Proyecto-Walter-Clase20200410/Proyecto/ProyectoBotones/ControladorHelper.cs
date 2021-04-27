using LibreriaBotones.Controles;
using LibreriaBotones.Controles.Boton;
using LibreriaBotones.Controles.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBotones
{
    public static class ControladorHelper
    {
        public static void MostrarDescripcionBotonesControlador(Controles c)
        {
            int ingreso = 0;
            bool flag = true;
            string cartelDesc = "";

            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton que desea ver la Descripcion ");
                    ingreso = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException forEx)
                {
                    Console.WriteLine("Ingrese un Numero " + forEx.Message);
                    flag = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);

            try
            {
                string mensaje = c.TraerDescripcionBoton(ingreso);
                Console.WriteLine(mensaje);
            }
            catch (CodigoBotonInexistenteException cex)
            {
                // Preguntarle de nuevo?
                Console.WriteLine(cex.Message);
            }
            catch (Exception ex)
            {
                // no sé que pasó, pero falló. 
                Console.WriteLine(ex.Message);
            }
           
                
           
        }

        public static void AgregarBotonEnLista(Controles c)  //Agrego los botones por medio del menu
        {
            bool flag = false;
            int IngresoBoton = 0;
            string DescripcionBoton = "";

            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton");
                    IngresoBoton = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ForEx)
                {
                    Console.WriteLine("Ingrese un Numero " + ForEx.Message);
                    flag = false;

                }
                catch (RepetidoExepcion Rex)
                {
                    Console.WriteLine("Valor Repetido, Ingrese otro " + Rex.Message);
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);

            do //BUCLE PARA EL INGRESO DE LA DESCRIPCION
            {
                try
                {
                    Console.WriteLine("Ingrese la Descripcion del Boton");
                    DescripcionBoton = Console.ReadLine();
                    flag = true;
                }
                catch (ArgumentNullException ArEx)
                {
                    Console.WriteLine("No debe ser Nula la descripcion " + ArEx.Message);
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);

            try
            {
                c.AgregarBoton(IngresoBoton, DescripcionBoton);
                
                //c.AgregarBoton(btn); OTRA OPCION Válida
                //Botones btn = new Botones(IngresoBoton, DescripcionBoton);

            }
            catch (Exception e)
            {
                
                // mostrar errro
            }

        }
        public static void MostrarBotones(Controles controles)
        {
            try
            {
                List<Botones> lst = controles.TraerBotones();
                
                foreach(Botones b in lst)
                {
                    Console.WriteLine(string.Format("Codigo {0} - Descripción {1}",b.Codigo, b.Descripcion));
                    Console.WriteLine($" Codigo {b.Codigo} - Descripcion {b.Descripcion}" );
                    Console.WriteLine("Codigo "+b.Codigo+" - Descripcion " + b.Descripcion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


        }
    }
}
