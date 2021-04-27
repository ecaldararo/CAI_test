﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaGenerico
{
    public class Consola
    {
        /*
        public static void ImprimirMenu(Dictionary<string,string> items, string titulo = "", string footer = "")
        {
            if (titulo == string.Empty)
                Console.WriteLine("Lista:");
            else
                Console.WriteLine(titulo);

            foreach(KeyValuePair<string,string> item in items)
            {
                Console.WriteLine($"{item.Key}) {item.Value}");
            }

            Console.WriteLine(footer);

            return;
        }

        public static Dictionary<string,string> ImprimirMenu(List<string> items, string titulo = "", string footer = "")
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            int key = 1;

            foreach(string item in items)
            {
                dict.Add($"{key++}", item);
            }

            ImprimirMenu(dict, titulo, footer);

            return dict;
        }
        */

        /*** LeerString: lee el string llamado "nombre" y lo devuelve, si falla devuelve vacío y tira exception.
         * Exceptions: ParametroInvalidoException
         */
        public static string LeerString(string nombre, bool puedeSerVacio = true)
        {
            string valor;

            Console.Write($"Ingrese {nombre}: ");
            valor = Console.ReadLine();

            if(!puedeSerVacio && valor.Length == 0)
            {
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" no puede estar vacío.");
            }

            return valor;            
        }

        public static double LeerDouble(string nombre, bool puedeSerNegativo = true, bool puedeSerCero = true)
        {
            double valor;

            Console.Write($"Ingrese {nombre}: ");

            if(!Double.TryParse(Console.ReadLine(), out valor))
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" debe ser numérico.");

            if (!puedeSerNegativo && !puedeSerCero && valor <= 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" debe ser mayor a cero.");

            if (!puedeSerNegativo && valor < 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" no puede ser negativo.");

            if (!puedeSerCero && valor == 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" no puede ser cero.");

            return valor;
        }

        public static int LeerInt(string nombre, bool puedeSerNegativo = true, bool puedeSerCero = true)
        {
            int valor;

            Console.Write($"Ingrese {nombre}: ");

            if (!int.TryParse(Console.ReadLine(), out valor))
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" debe ser un número entero.");

            if (!puedeSerNegativo && !puedeSerCero && valor <= 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" debe ser mayor a cero.");

            if (!puedeSerNegativo && valor < 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" no puede ser negativo.");

            if (!puedeSerCero && valor == 0)
                throw new ParametroInvalidoException($"El parámetro \"{nombre}\" no puede ser cero.");

            return valor;
        }
        public static void ImprimirError(string mensaje)
        {
            Console.Error.WriteLine("\n***ERROR: " + mensaje);
        }
    }
}
