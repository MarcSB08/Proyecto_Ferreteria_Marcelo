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

        public void Bienvenido()
        {
            Inventario inventario = new Inventario();
            string opcion;
            do
            {
                opcion = Interfaz.Menu_Principal();
                switch (opcion.ToUpper())
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
                        inventario.EliminarProducto();
                        break;
                    case "6":
                        inventario.ContratarVendedor();
                        break;
                    case "7":
                        inventario.EliminarVendedor();
                        break;
                    case "8":
                        Listas(inventario);
                        break;
                    case "ADMIN":
                        inventario.EliminarTodo();
                        break;
                    case "0":
                        Interfaz.Adios();
                        Interfaz.ImprimirLogoUSM();
                        break;
                    default:
                        Interfaz.XY(16, 23); Interfaz.Error("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "0");
        }

        public void Listas(Inventario inventario)
        {
            string opcion;
            do
            {
                opcion = Interfaz.Submenu_Listas();
                switch (opcion)
                {
                    case "1":
                        inventario.ListarProductos();
                        break;
                    case "2":
                        inventario.ListarMasVendidos();
                        break;
                    case "3":
                        inventario.ListarMenosVendidos();
                        break;
                    case "4":
                        inventario.ListarProductosSurtir();
                        break;
                    case "5":
                        inventario.ListarVendedoresPorVentas();
                        break;
                    case "0":
                        break;
                    default:
                        Interfaz.XY(16, 23); Interfaz.Error("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "0");
        }

        #endregion
    }
}
