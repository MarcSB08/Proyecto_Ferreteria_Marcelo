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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Borde(); Console.ResetColor();

            xy(48, 4); Console.Write("===FERRETERIA IZANAGI===");
            xy(15, 8); Console.WriteLine("<1> Ingresar un Producto Nuevo");
            xy(15, 9); Console.WriteLine("<2> Buscar un Producto por su Código");
            xy(15, 10); Console.WriteLine("<3> Modificar el Stock y Precio de un Producto dado");
            xy(15, 11); Console.WriteLine("<4> Procesar una Venta");
            xy(15, 12); Console.WriteLine("<5> Eliminar un Producto dado su Código");
            xy(15, 13); Console.WriteLine("<6> Contratar a un Vendedor");
            xy(15, 14); Console.WriteLine("<7> Eliminar a un Vendedor");
            xy(15, 15); Console.WriteLine("<8> Listas");
            xy(15, 16); Console.WriteLine("<0> Salir");
            xy(62, 23); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("<ADMIN> Eliminar todos los datos registrados");
            xy(8, 23); Console.ResetColor(); Console.Write("Opción: ");
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

        public static void xy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void Error(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"ERROR: {mensaje}");
            Console.ResetColor();
        }

        public static void Continuar()
        {
            Interfaz.xy(8, 23); Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        #endregion
    }
}
