using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    public static class Interfaz
    {
        #region Métodos

        public static string Menu_Principal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Borde(); ImprimirEngranaje();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            xy(48, 4); Console.Write("===FERRETERIA IZANAGI==="); Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Borde(); Console.ForegroundColor = ConsoleColor.DarkYellow;

            xy(52, 4); Console.Write("===LISTAS==="); Console.ResetColor();
            xy(15, 8); Console.WriteLine("<1> Listar todos los productos");
            xy(15, 10); Console.WriteLine("<2> Listar los 3 productos más vendidos (%)");
            xy(15, 12); Console.WriteLine("<3> Listar los 3 productos menos vendidos (%)");
            xy(15, 14); Console.WriteLine("<4> Listar los productos a surtir (stock mínimo)");
            xy(15, 16); Console.WriteLine("<5> Lista de vendedores y cantidad de ventas realizadas");
            xy(15, 18); Console.WriteLine("<0> Volver al menú principal");
            xy(8, 23); Console.Write("Opción: ");
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

        public static void Adios()
        {
            int x = 15, y = 10;

            Console.Clear();
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("    _       _ _               ____  ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("   / \\   __| (_) ___  ___   _|  _ \\ ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("  / _ \\ / _` | |/ _ \\ __| (_) | | |");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine(" / ___ \\ (_| | | (_) \\__\\  _| |_| |");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("/_/     \\__,_|_||___/|___/ (_)____/ ");
            Thread.Sleep(50); xy(x, y++); Console.ResetColor();
        }

        public static void ImprimirEngranaje()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            xy(75, 5); Console.Write("           :#%%%%:           ");
            xy(75, 6); Console.Write("   ..==:...*%%%%%*...:==..   ");
            xy(75, 7); Console.Write(" ..=#%%%##%%%%%%%%%##%%%#=.. ");
            xy(75, 8); Console.Write(" ..#%%%%%%%%%%%%%%%%%%%%%#:. ");
            xy(75, 9); Console.Write("  ..+%%%%%%*-:::-*%%%%%%+..  ");
            xy(75, 10); Console.Write("  .:%%%%%=..     ..=%%%%%-.  ");
            xy(75, 11); Console.Write("#%%%%%%%=.         .=%%%%%%%#");
            xy(75, 12); Console.Write("%%%%%%%%-           -%%%%%%%%");
            xy(75, 13); Console.Write("%%%%%%%%=.         .=%%%%%%%%");
            xy(75, 14); Console.Write("  .:%%%%%=..     ..=%%%%%-.  ");
            xy(75, 15); Console.Write("  ..+%%%%%%*-::::*%%%%%%+..  ");
            xy(75, 16); Console.Write(" ..*%%%%%%%%%%%%%%%%%%%%%*:. ");
            xy(75, 17); Console.Write(" ..=#%%%##%%%%%%%%%##%%%%=.. ");
            xy(75, 18); Console.Write("   ..=+:...*%%%%%*. .:+=..   ");
            xy(75, 19); Console.Write("           :#%%%%:           ");
        }

        public static void ImprimirLogoUSM()
        {
            int x = 60, y = 7;
            Console.ForegroundColor = ConsoleColor.Blue;
            Borde();

            Thread.Sleep(50); xy(x, y); Console.WriteLine("         .+%%%%%%+.=#%%%%#:+%%%%%%%%%%%-        ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("      .+%%%%%%*.-#%%%%%:=%%%%%%%%%%%%#-.      ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("     .+%%%%%%%::*%%%%%--%%%%%%%%%%%%%%#-.     ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("    .+%%%%%%%-.*%%%%%=:%%%%#==++++++++++:.    ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("   .+%%%%%%%+.+%%%%%+:#%%%%==%%%%%%%%%%%#-.   ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("  .=%%%%%%%%++%%%%%*:*%%%%+-%%%%%%%%%%%%%%-.  ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine(" .:*%%%%%%%%%%%%%%#:+%%%%*-#%%%%%%%%%%%%%%#:. ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("  .:*%%%%%%%%%%%%#-+%%%%#:*%%%%%%%%%%%%%%%=.  ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("    .+%%%%%%%%%%#=-#%%%%-+%%*+%#=*%%%%%%%=.   ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("     .:==========+#%%%%-=%%*-*%=:#%%%%%%+.    ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("      :*%%%%%%%%%%%%%%=:%%#-+%*:*%%%%%%+.     ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("       .+%%%%%%%%%%%%*:%%%=-%%--%%%%%%*.      ");
            Thread.Sleep(50); xy(x, y++); Console.WriteLine("        .=%%%%%%%%%%#:#%%+:#%+:*%%%%%*.       ");

            Console.ResetColor();
            xy(x, y++); Console.ReadKey();
            Console.Clear();
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
