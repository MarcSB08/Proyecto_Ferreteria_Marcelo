using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    [Serializable]
    public class Producto
    {
        #region Atributos

        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public double Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string Descripcion { get; set; }
        public int Vendidos { get; set; }

        #endregion

        #region Constructor

        // Constructor con parámetros
        public Producto(string nombre, string codigo, double precio, int stock_actual, int stock_minimo, string descripcion, int vendidos)
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precio;
            StockActual = stock_actual;
            StockMinimo = stock_minimo;
            Descripcion = descripcion;
            Vendidos = vendidos;
        }

        // Constructor sin parámetros
        public Producto() : this("", "", 0, 0, 0, "", 0) { }

        #endregion

        #region Métodos

        public void ReducirStock(int cantidad)  // Reduce el stock del producto y aumenta la cantidad vendida cuando se procesa una venta
        {
            StockActual -= cantidad;
            Vendidos += cantidad;
        }

        public static double ValidarPrecio(int y)
        {
            int x = 8;
            double precio = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.XY(x, y); Interfaz.Error(msj);
                    Console.ReadKey();
                    Interfaz.XY(x, y); Console.Write("                                               ");
                }
                try
                {
                    Interfaz.XY(x, y); Console.Write("-Ingrese el precio ($): ");
                    precio = double.Parse(Console.ReadLine());
                    if (precio <= 0)
                    {
                        msj = "El precio ingresado es inválido";
                        key = true;
                    }
                    else
                    {
                        key = false;
                    }
                }
                catch (FormatException)
                {
                    msj = "El formato ingresado no es correcto";
                    key = true;
                }
            } while (key);

            return precio;
        }

        public static int ValidarCantidad(int stock_actual, int y)
        {
            int x = 8;
            int cantidad = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.XY(x, y); Interfaz.Error(msj);
                    Console.ReadKey();
                    Interfaz.XY(x, y); Console.Write("                                                              ");
                }
                try
                {
                    Interfaz.XY(x, y); Console.Write("-Ingrese la cantidad del producto: ");
                    cantidad = int.Parse(Console.ReadLine());
                    if (cantidad <= 0)
                    {
                        msj = "La cantidad ingresada es inválida";
                        key = true;
                    }
                    else if (cantidad > stock_actual)
                    {
                        msj = "Cantidad no puede superar el stock disponible";
                        key = true;
                    }
                    else
                    {
                        key = false;
                    }
                }
                catch (FormatException)
                {
                    msj = "El formato ingresado no es correcto";
                    key = true;
                }
            } while (key);

            return cantidad;
        }

        public static int ValidarStock(int y)
        {
            int x = 8;
            int stock = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.XY(x, y); Interfaz.Error(msj);
                    Console.ReadKey();
                    Interfaz.XY(x, y); Console.Write("                                                           ");
                }
                try
                {
                    Interfaz.XY(x, y); Console.Write("-Ingrese el stock: ");
                    stock = int.Parse(Console.ReadLine());
                    if (stock < 0)
                    {
                        msj = "El stock ingresado es inválido";
                        key = true;
                    }
                    else
                    {
                        key = false;
                    }
                }
                catch(FormatException)
                {
                    msj = "El formato ingresado no es correcto";
                    key = true;
                }
            } while (key);

            return stock;
        }

        #endregion
    }
}
