using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    internal class Venta
    {
        #region Atributos

        private Producto ProductoVendido { get; set; }
        private Vendedor Vendedor { get; set; }
        private int Cantidad { get; set; }
        private DateTime Fecha { get; set; }

        #endregion

        #region Constructor

        public Venta(Producto producto_vendido, Vendedor vendedor, int cantidad) // Constructor con parámetros
        {
            ProductoVendido = producto_vendido;
            Vendedor = vendedor;
            Cantidad = cantidad;
            Fecha = DateTime.Now;
        }

        public Venta() : this(new Producto(), new Vendedor(), 0) // Constructor sin parámetros
        {
            Fecha = DateTime.Now;
        }

        public double CalcularTotal() => ProductoVendido.GetPrecio() * Cantidad;

        #endregion
    }
}
