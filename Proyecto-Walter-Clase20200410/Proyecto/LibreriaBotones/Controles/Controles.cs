using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaBotones.Controles.Boton;
using LibreriaBotones.Controles.Exepciones;

namespace LibreriaBotones.Controles
{
    public class Controles
    {
        List<Botones> _Botones; //Me salta este error, como los soluciono?

        public Controles()
        {
           _Botones = new List<Botones>();
        }

        public string TraerDescripcionBoton(int codigoBoton)
        {
            string desc = string.Empty;

            foreach (Botones i in _Botones)
            {
                if (i.Codigo == codigoBoton)
                {
                    desc = i.Descripcion;
                }
            }

            if(desc == string.Empty)
            {
                throw new CodigoBotonInexistenteException();
            }

            return desc;
        }

        public void AgregarBoton(Botones b)  //Agrego el boton a la lista 
        {
            // existe?
            _Botones.Add(b);
        }

        public void AgregarBoton(int cod, string descripcion)  //Agrego el boton a la lista 
        {
            // existe?
            // if(TraerBoton(cod) == null)
            Botones AB = new Botones(cod, descripcion); //Utilizo el construtor con parametros

            _Botones.Add(AB);
        }

        public List<Botones> TraerBotones()
        {
            if (_Botones.Count > 0)
                return _Botones;
            else
                throw new Exception("No hay botones / lista vacia");
        }

        public void MostrarBotonesControlador() //Bucle, cargo los datos en un string y lo muestro
        {
            
            string CartelMostrar = "";
            Botones MBC = new Botones();

            foreach (Botones i in _Botones )
            {
                CartelMostrar += MBC.MostrarCodigo(i.Codigo)+"\n";
            }

            if (CartelMostrar == "")
            {
                Console.WriteLine("\nNo hay botones Cargados\n");
            }
            else 
            {
                Console.WriteLine(CartelMostrar);
            }
        }



        public void BorrarBotonesControlador() 
        {
            int Ingreso = 0;
            bool flag = true;
            string CartelBorrar = "";

            Botones BBC = new Botones();


            do //BUCLE DE LA ENTRADA DEL CODIGO
            {
                try
                {
                    Console.WriteLine("Ingrese el codigo del Boton que desea BORRAR ");
                    Ingreso = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ForEx)
                {
                    Console.WriteLine("Ingrese un Numero " + ForEx.Message);
                    flag = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error " + ex.Message);
                    flag = false;

                }
            } while (flag != true);


            // traer boton a borrar y lo guardo en una variable (botonAborrar)
            // _Botones.Remove(botonAborrar);


            foreach (Botones i in _Botones) //Me salta un error en el IN
            /*System.InvalidOperationException: 'Colección modificada; puede que no se ejecute la operación de enumeración.'*/
            {
                if ( i.Codigo == Ingreso)
                {
                    CartelBorrar += BBC.MostrarBoton(i.Codigo, i.Descripcion);

                    BorrarBoton(i);

                    break; //Para salir del sistema si o si para que no salte el problema de arriba

                }
            }

            if (CartelBorrar == "")
            {
                Console.WriteLine("\nCodigo De Boton Inexistete");
            }
            else 
            {
                Console.WriteLine("Usted Borro \n"+CartelBorrar);
            }

        }

        private void BorrarBoton(Botones BB)  //Borro el Boton de la lista
        {
            _Botones.Remove(BB);
        }

        private void BorrarBoton(int codBoton)  //Borro el Boton de la lista
        {
            //Boton b = TraerBoton(codBoton);
            // if (b != null)
            // _Botones.Remove(b);

            // remueve todo lo que coicida con la condición
            //_Botones.RemoveAll(d => d.Codigo == codBoton);

        }



        //Muestro la lista de botones


        public void BusquedaRepetido(int Entrada)
        {
            foreach (Botones i in _Botones) 
            {
                if (i.Codigo == Entrada)
                {
                    throw new RepetidoExepcion(); //Pregunta y Como usarlo
                }
            }
        }
    }
}
