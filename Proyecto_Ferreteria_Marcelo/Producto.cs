using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    internal class Producto
    {
        #region Atributos

        private string Nombre { get; set; }
        private string Codigo { get; set; }
        private double Precio { get; set; }
        private int StockActual { get; set; }
        private int StockMinimo { get; set; }
        private string Descripcion { get; set; }
        private int Vendidos { get; set; }

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
        
        // Métodos públicos para obtener los atributos privados en otras clases
        public string GetNombre() => Nombre;
        public string GetCodigo() => Codigo;
        public double GetPrecio() => Precio;
        public int GetStockActual() => StockActual;
        public int GetStockMinimo() => StockMinimo;
        public string GetDescripcion() => Descripcion;
        public int GetVendidos() => Vendidos;
        public double SetPrecio(double precio) => Precio = precio;
        public int SetStockActual(int stock_actual) => StockActual = stock_actual;
        public int SetStockMinimo(int stock_minimo) => StockMinimo = stock_minimo;

        // Crea el producto a ingresar tomando sus atributos
        public Producto CrearProducto()
        {
            Console.Clear();
            Console.WriteLine("===AGREGAR UN PRODUCTO===");

            Console.Write("\n-Ingrese el nombre: ");
            Nombre = Console.ReadLine();

            Console.Write("-Ingrese el código: ");
            Codigo = Console.ReadLine();

            Precio = ValidarPrecio();
            StockActual = ValidarStockActual();
            StockMinimo = ValidarStockMinimo(StockActual);

            Console.Write("-Ingrese la descripción: ");
            Descripcion = Console.ReadLine();

            return new Producto(Nombre, Codigo, Precio, StockActual, StockMinimo, Descripcion, Vendidos);
        }

        // Reduce el stock del producto y aumenta la cantidad vendida cuando se procesa una venta
        public void ReducirStock(int cantidad)
        {
            StockActual -= cantidad;
            Vendidos += cantidad;
        }

        public static double ValidarPrecio()
        {
            double precio = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.Error(msj);
                }
                try
                {
                    Console.Write("-Ingrese el precio del producto: ");
                    precio = double.Parse(Console.ReadLine());
                    if (precio < 0)
                    {
                        msj = "El precio no puede ser negativo";
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

        public static int ValidarCantidad(int stock_actual)
        {
            int cantidad = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.Error(msj);
                }
                try
                {
                    Console.Write("-Ingrese la cantidad: ");
                    cantidad = int.Parse(Console.ReadLine());
                    if (cantidad < 0)
                    {
                        msj = "La cantidad no puede ser negativa";
                        key = true;
                    }
                    else if (cantidad > stock_actual)
                    {
                        msj = "La cantidad no puede ser mayor que el stock disponible";
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

        public static int ValidarStockActual()
        {
            int stock_actual = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.Error(msj);
                }
                try
                {
                    Console.Write("-Ingrese el stock actual del producto: ");
                    stock_actual = int.Parse(Console.ReadLine());
                    if (stock_actual < 0)
                    {
                        msj = "El stock actual no puede ser negativo";
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

            return stock_actual;
        }

        public static int ValidarStockMinimo(int stock_actual)
        {
            int stock_minimo = 0;
            bool key = false;
            string msj = "";

            do
            {
                if (key)
                {
                    Interfaz.Error(msj);
                }
                try
                {
                    Console.Write("-Ingrese el stock mínimo del producto: ");
                    stock_minimo = int.Parse(Console.ReadLine());
                    if (stock_minimo < 0)
                    {
                        msj = "El stock mínimo no puede ser negativo";
                        key = true;
                    }
                    else if(stock_minimo > stock_actual)
                    {
                        msj = "El stock mínimo no puede ser mayor que el stock actual";
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

            return stock_minimo;
        }

        #endregion
    }
}
