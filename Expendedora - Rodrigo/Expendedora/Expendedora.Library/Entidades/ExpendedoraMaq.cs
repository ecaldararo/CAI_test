using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expendedora.Library.Entidades;
using Expendedora.Library.Excepciones;
using Expendedora.Library.Modelos;

namespace Expendedora.Library.Entidades
{
    public class ExpendedoraMaq
    {
        // ATRIBUTOS
        private List<Lata> _latas;
        private string _proveedor;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;

        // PARAMETROS
        public double Balance => _dinero;

        // MÉTODOS
        public ExpendedoraMaq(string proveedor, int capacidad)
        {
            if(proveedor == string.Empty || capacidad < 0)
            {
                throw new ArgumentException("Debe indicarse un proveedor y la capacidad debe ser mayor a cero.");
            }

            this._latas = new List<Lata>();
            this._proveedor = proveedor;
            this._capacidad = capacidad;
            this._dinero = 0;
            this._encendida = false;

            

        }

        public void Encender()
        {
            _encendida = true;

        }

        public void AgregarLata(string codigo, string nombre, string sabor, double precio, double volumen, int cantidad = 0)
        {
            if (!_encendida) 
                throw new ExpendedoraApagadaException();

            // TOCHANGE: Debería poder agregar stock de una lata ya ingresada...
            if( codigo != "" && BuscarLata(codigo) != null)
                throw new CodigoInvalidoException($"La lata con el código \"{codigo}\" ya se encuentra en la expendedora.");

            if (codigo == "" || nombre == "" || precio <= 0 || volumen <= 0)
                throw new ArgumentException("Algún valor en la lata está vacío o no es válido.");

            _latas.Add(new Lata(codigo, nombre, sabor, precio, volumen, cantidad));

            return;
        }

        // Busca una lata en la expendedora. Si la encuentra la devuelve, sino devuelve null.
        public Lata BuscarLata(string codigo)
        {
            foreach(Lata lata in _latas)
            {
                if (lata.Codigo == codigo)
                    return lata;
            }

            return null;
        }
        public List<string> ListarLatasDisponibles()
        {
            List<string> lista = new List<string>();
            
            foreach(Lata lata in _latas)
            {
                lista.Add($"{lata.Codigo}) {lata.Nombre} [{lata.Cantidad}]");
            }

            return lista;
        }

        public DevolucionMaquina ComprarLata(string codigo, double dineroDelUsuario)
        {
            Lata lata;

            if (!_encendida)
                throw new ExpendedoraApagadaException();

            lata = BuscarLata(codigo);
            if (lata == null)
                throw new CodigoInvalidoException("El código ingresado no está disponible en la expendedora");
            if (lata.Cantidad <= 0)
                throw new SinStockException("No hay stock de la lata seleccionada");
            if (lata.Precio > dineroDelUsuario)
                throw new DineroInsuficienteException("Dinero insuficiente");

            double vuelto = dineroDelUsuario - lata.Precio;

            _dinero += lata.Precio; 

            lata.ReducirCantidad();

            DevolucionMaquina devolucionMaquina = new DevolucionMaquina(lata, vuelto);

            return devolucionMaquina;
        }

        public int ContarLatas()
        {
            int cantidadDeLatas = 0;

            if (!_encendida)
                throw new ExpendedoraApagadaException();

            foreach (Lata lata in _latas)
            {
                cantidadDeLatas += lata.Cantidad;
            }

            return cantidadDeLatas;
        }

        public List<string> VerStockYDescripcion()
        {
            List<string> lista = new List<string>();
            
            if (!_encendida)
                throw new ExpendedoraApagadaException();

            if (this.ContarLatas() <= 0)
                throw new SinStockException("La expendedora está vacía.");

            foreach(Lata lata in _latas)
            {
                lista.Add(lata.ToString());
            }

            return lista;
        }
    }
}
