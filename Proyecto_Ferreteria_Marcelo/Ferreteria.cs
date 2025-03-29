using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    internal class Ferreteria
    {
        #region Métodos

        public void Inicio()
        {
            Inventario inventario = new Inventario();
            string opcion;
            do
            {
                opcion = Interfaz.Menu_Principal();
                switch (opcion)
                {
                    case "1":
                        inventario.IngresarProducto();
                        break;
                    case "2":
                        inventario.BuscarPorCodigo();
                        break;
                    case "3":
                        inventario.ModificarProducto();
                        break;
                    case "4":
                        inventario.ProcesarVenta();
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        Interfaz.Submenu_Listas();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Gracias por utilizar el programa :D");
                        Interfaz.Continuar();
                        break;
                    default:
                        Interfaz.Error("Opción no válida");
                        Interfaz.Continuar();
                        break;
                }
            } while (opcion != "0");
        }

        #endregion
    }
}
