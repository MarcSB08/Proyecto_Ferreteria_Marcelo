using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    internal class Inventario
    {
        #region Atributos

        private List<Producto> Productos;
        private List<Vendedor> Vendedores;
        private List<Venta> Ventas;

        #endregion

        #region Constructores

        public Inventario()
        {
            Productos = new List<Producto>();
            Vendedores = new List<Vendedor>();
            Ventas = new List<Venta>();
        }

        #endregion

        #region Métodos

        public void IngresarProducto()  // 1
        {
            Producto producto_nuevo = new Producto();
            producto_nuevo.CrearProducto();
            if (Productos.Exists(p => p.GetCodigo() == producto_nuevo.GetCodigo()))
            {
                Interfaz.Error("Ya existe un producto con ese código");
            }
            else
            {
                Productos.Add(producto_nuevo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Producto ingresado correctamente!");
                Console.ResetColor();
            }
            Interfaz.Continuar();
        }

        public void BuscarPorCodigo()  // 2
        {
            Console.Clear();
            Console.WriteLine("===BUSCAR PRODUCTO POR CÓDIGO===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos ingresados");
            }
            else
            {
                Console.Write("\n-Ingrese el código del producto: ");
                string codigo = Console.ReadLine();
                Producto producto = Productos.Find(p => p.GetCodigo() == codigo);
                if (producto != null)
                {
                    Console.WriteLine($"\nNombre: {producto.GetNombre()}");
                    Console.WriteLine($"Precio: {producto.GetPrecio()}$");
                    Console.WriteLine($"Stock actual: {producto.GetStockActual()}");
                    Console.WriteLine($"Stock mínimo: {producto.GetStockMinimo()}");
                    Console.WriteLine($"Descripción: {producto.GetDescripcion()}");
                }
                else
                {
                    Interfaz.Error("No se encontró un producto con ese código");
                }
            }
            Interfaz.Continuar();
        }

        public void ModificarProducto()  // 3
        {
            Console.Clear();
            Console.WriteLine("===MODIFICAR STOCK Y PRECIO DE UN PRODUCTO===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos ingresados");
            }
            else
            {
                Console.Write("-Ingrese el código del producto a modificar: ");
                string codigo = Console.ReadLine();
                Producto producto = Productos.FirstOrDefault(p => p.GetCodigo() == codigo);
                if (producto != null)
                {
                    Console.WriteLine($"\nEl producto '{producto.GetNombre()}' de código '{producto.GetCodigo()}' fue encontrado");
                    Console.WriteLine("\nDATOS ACTUALES DE STOCK Y PRECIO:");
                    Console.WriteLine($"-Precio: {producto.GetPrecio()}$");
                    Console.WriteLine($"-Stock actual: {producto.GetStockActual()}");
                    Console.WriteLine($"-Stock mínimo: {producto.GetStockMinimo()}\n");

                    double nuevo_precio = Producto.ValidarPrecio();
                    int nuevo_stock_actual = Producto.ValidarStockActual();
                    int nuevo_stock_minimo = Producto.ValidarStockMinimo(nuevo_stock_actual);

                    producto.SetPrecio(nuevo_precio);
                    producto.SetStockActual(nuevo_stock_actual);
                    producto.SetStockMinimo(nuevo_stock_minimo);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEl producto ha sido modificado exitosamente.");
                    Console.ResetColor();
                }
                else
                {
                    Interfaz.Error("No se encontró un producto con ese código");
                }
            }
            Interfaz.Continuar();
        }

        public void RegistrarVendedor(string nombre)  // Método para registrar un vendedor nuevo
        {
            if (!Vendedores.Any(v => v.GetNombre() == nombre))
            {
                Vendedores.Add(new Vendedor(nombre, 0));
            }
        }

        public void ProcesarVenta()  // 4
        {
            Console.Clear();
            Console.WriteLine("===PROCESAR VENTA===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos ingresados. No se puede procesar ninguna venta");
            }
            else
            {
                Console.Write("\n-Ingrese el nombre del producto: ");
                string nombre = Console.ReadLine();
                Producto producto = Productos.FirstOrDefault(p => p.GetNombre() == nombre);

                if (producto != null)
                {
                    Console.WriteLine("\nDATOS DEL PRODUCTO:");
                    Console.WriteLine($"\nNombre: {producto.GetNombre()}");
                    Console.WriteLine($"Precio: {producto.GetPrecio()}$");
                    Console.WriteLine($"Stock actual: {producto.GetStockActual()}");

                    int cantidad = Producto.ValidarCantidad(producto.GetStockActual());

                    Console.Write("\n-Ingrese el nombre del vendedor: ");
                    string nombre_vendedor = Console.ReadLine();

                    // Si el vendedor no existe, se crea uno nuevo
                    Vendedor vendedor = Vendedores.FirstOrDefault(v => v.GetNombre() == nombre_vendedor);
                    if (vendedor == null)
                    {
                        vendedor = new Vendedor(nombre_vendedor, 0);
                        Vendedores.Add(vendedor);
                    }

                    producto.ReducirStock(cantidad);
                    vendedor.AumentarVentas();
                    Venta venta = new Venta(producto, vendedor, cantidad);
                    Ventas.Add(venta);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVenta procesada exitosamente");
                    Console.ResetColor();
                    Interfaz.Continuar();
                    venta.GenerarFactura();
                }
                else
                {
                    Interfaz.Error("No se encontró un producto con ese nombre");
                }
            }
            Interfaz.Continuar();
        }

        public void EliminarProducto()  // 5
        {
            Console.Clear();
            Console.WriteLine("===ELIMINAR PRODUCTO POR CÓDIGO===");
            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos ingresados");
            }
            else
            {
                string op = "";
                Console.Write("\n-Ingrese el código del producto a eliminar: ");
                string codigo = Console.ReadLine();
                Producto producto = Productos.FirstOrDefault(p => p.GetCodigo() == codigo);
                if (producto != null)
                {
                    do
                    {
                        Console.WriteLine($"¿Está seguro que desea eliminar el producto '{producto.GetNombre()}'?");
                        Console.Write("-Opción (SI/NO): ");
                        op = Console.ReadLine();

                        if (op.ToUpper() == "SI")
                        {
                            Productos.Remove(producto);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nProducto eliminado exitosamente");
                            Console.ResetColor();
                        }
                        else if (op.ToUpper() == "NO")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nOperación cancelada");
                            Console.ResetColor();
                        }
                        else
                        {
                            Interfaz.Error("Opción inválida");
                        }
                    } while (op.ToUpper() != "SI" && op.ToUpper() != "NO");
                }
                else
                {
                    Interfaz.Error("No se encontró un producto con ese código");
                }
            }
            Interfaz.Continuar();
        }

        public void EliminarVendedor()  // 6
        {
            Console.Clear();
            Console.WriteLine("===ELIMINAR VENDEDOR POR NOMBRE===");

            if (Vendedores.Count == 0)
            {
                Interfaz.Error("No hay vendedores registrados");
            }
            else
            {
                string op = "";
                Console.Write("-Ingrese el nombre del vendedor a eliminar: ");
                string nombre = Console.ReadLine();

                Vendedor vendedor = Vendedores.FirstOrDefault(v => v.GetNombre() == nombre);

                if (vendedor != null)
                {
                    do
                    {
                        Console.WriteLine($"¿Está seguro que desea eliminar el producto '{vendedor.GetNombre()}'?");
                        Console.Write("-Opción (SI/NO): ");
                        op = Console.ReadLine();

                        if (op.ToUpper() == "SI")
                        {
                            Vendedores.Remove(vendedor);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nProducto eliminado exitosamente");
                            Console.ResetColor();
                        }
                        else if (op.ToUpper() == "NO")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nOperación cancelada");
                            Console.ResetColor();
                        }
                        else
                        {
                            Interfaz.Error("Opción inválida");
                        }
                    } while (op.ToUpper() != "SI" && op.ToUpper() != "NO");
                }
                else
                {
                    Interfaz.Error("No se encontró ningún vendedor con ese nombre");
                }
            }
            Interfaz.Continuar();
        }

        #endregion
    }
}
