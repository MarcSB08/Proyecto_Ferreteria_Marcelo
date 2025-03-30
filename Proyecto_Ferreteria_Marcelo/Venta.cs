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

        #endregion

        #region Métodos

        public double CalcularTotal() => ProductoVendido.GetPrecio() * Cantidad;

        public void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("===FACTURA DE VENTA===");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Producto: {ProductoVendido.GetNombre()}");
            Console.WriteLine($"Código: {ProductoVendido.GetCodigo()}");
            Console.WriteLine($"Precio unitario: {ProductoVendido.GetPrecio()}$");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Vendedor: {Vendedor.GetNombre()} (Ventas: {Vendedor.GetVentasRealizadas()})");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"TOTAL A PAGAR: {CalcularTotal()}$");
        }

        #endregion
    }
}
