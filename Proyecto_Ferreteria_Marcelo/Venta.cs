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
            int x = 8, y = 5;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Interfaz.Borde(); Console.ResetColor();
            Interfaz.XY(x, y++); Console.WriteLine("===FACTURA DE VENTA===");
            Interfaz.XY(x, y++); Console.WriteLine($"Fecha: {Fecha}");
            Interfaz.XY(x, y++); Console.WriteLine($"Producto: {ProductoVendido.Nombre}");
            Interfaz.XY(x, y++); Console.WriteLine($"Código: {ProductoVendido.Codigo}");
            Interfaz.XY(x, y++); Console.WriteLine($"Precio unitario: ${ProductoVendido.Precio}");
            Interfaz.XY(x, y++); Console.WriteLine($"Cantidad: {Cantidad}");
            Interfaz.XY(x, y++); Console.WriteLine($"Vendedor: {Vendedor.Nombre} (Ventas: {Vendedor.VentasRealizadas})");
            Interfaz.XY(x, y++); Console.WriteLine("--------------------------");
            Interfaz.XY(x, y++); Console.WriteLine($"TOTAL A PAGAR: ${CalcularTotal()}");
        }

        #endregion
    }
}
