using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    public static class Interfaz
    {
        #region Métodos

        public static string Menu_Principal()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opción:\n");
            Console.WriteLine("<1> Ingresar un Producto Nuevo");
            Console.WriteLine("<2> Buscar un Producto por su Código");
            Console.WriteLine("<3> Modificar el Stock y Precio de un Producto dado");
            Console.WriteLine("<4> Procesar una Venta");
            Console.WriteLine("<5> Eliminar un Producto dado su Código");
            Console.WriteLine("<6> Contratar a un Vendedor");
            Console.WriteLine("<7> Eliminar a un Vendedor");
            Console.WriteLine("<8> Listas");
            Console.WriteLine("<ADMIN> Eliminar todos los datos registrados");
            Console.WriteLine("<0> Salir");
            Console.Write("\nOpción: ");
            string opcion = Console.ReadLine();

            return opcion;
        }

        public static string Submenu_Listas()
        {
            Console.Clear();
            Console.WriteLine("<1> Listar todos los productos");
            Console.WriteLine("<2> Listar los 3 productos más vendidos (%)");
            Console.WriteLine("<3> Listar los 3 productos menos vendidos (%)");
            Console.WriteLine("<4> Listar los productos a surtir (stock mínimo)");
            Console.WriteLine("<5> Lista de vendedores y cantidad de ventas realizadas");
            Console.WriteLine("<0> Volver al menú principal");
            Console.Write("\nOpción: ");
            string opcion = Console.ReadLine();

            return opcion;
        }

        public static void Borde()
        {
            int ancho = 100, alto = 25;

            Console.SetCursorPosition(6, 2);
            Console.Write("╔");

            Console.SetCursorPosition(ancho + 8, 2);
            Console.Write("╗");

            Console.SetCursorPosition(6, alto - 1);
            Console.Write("╚");

            Console.SetCursorPosition(ancho + 8, alto - 1);
            Console.Write("╝");

            for (int i = 8; i < ancho + 9; i++)
            {
                Console.SetCursorPosition(i - 1, 2);
                Console.Write("═");

                Console.SetCursorPosition(i - 1, alto - 1);
                Console.Write("═");
            }

            for (int i = 3; i < alto - 1; i++)
            {
                Console.SetCursorPosition(6, i);
                Console.Write("║");

                Console.SetCursorPosition(ancho + 8, i);
                Console.Write("║");
            }
        }

        public static void Error(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {mensaje}.");
            Console.ResetColor();
        }

        public static void Continuar()
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        #endregion
    }
}
