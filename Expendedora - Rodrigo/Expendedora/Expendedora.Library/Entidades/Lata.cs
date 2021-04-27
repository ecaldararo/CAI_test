using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Library.Entidades
{
    public class Lata
    {
        // ATRIBUTOS
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;
        private int _cantidad;

        // ¿Está bien que esta clase tenga atributos que no pertenecen a la lata en sí, sino a cómo se organizan en la expendedora?
        // Por ejemplo la cantidad que hay en la máquina.

        // PROPIEDADES
        public int Cantidad { get { return _cantidad; } }
        public string Codigo => _codigo;
        public string Nombre => _nombre;
        public double Precio => _precio;

        // MÉTODOS
        public Lata(string codigo, string nombre, string sabor, double precio, double volumen, int cantidad = 0)
        {
            _codigo = codigo;
            _nombre = nombre;
            _sabor = sabor;
            _precio = precio;
            _volumen = volumen;
            _cantidad = cantidad;
        }
        private double GetPrecioPorLitro()
        {
            return _precio / _volumen;
        }

        public int ReducirCantidad()
        {
            if(_cantidad > 0)
            {
                _cantidad--;
            }
            return _cantidad;
        }

        public string ToString()
        {
            return $"{_nombre} - {_sabor} - $ {_precio} $/L{this.GetPrecioPorLitro()} - {_cantidad}";
        }
    }
}
