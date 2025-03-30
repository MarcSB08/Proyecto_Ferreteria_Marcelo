using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    [Serializable]
    public class Venta
    {
        #region Atributos

        public Producto ProductoVendido { get; set; }
        public Vendedor Vendedor { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

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

        public double CalcularTotal() => ProductoVendido.Precio * Cantidad;

        public void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("===FACTURA DE VENTA===");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Producto: {ProductoVendido.Nombre}");
            Console.WriteLine($"Código: {ProductoVendido.Codigo}");
            Console.WriteLine($"Precio unitario: {ProductoVendido.Precio}$");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Vendedor: {Vendedor.Nombre} (Ventas: {Vendedor.VentasRealizadas})");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"TOTAL A PAGAR: {CalcularTotal()}$");
        }

        #endregion
    }
}
