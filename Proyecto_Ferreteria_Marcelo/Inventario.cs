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
            Productos = Archivo.CargarProductos();
            Vendedores = Archivo.CargarVendedores();
            Ventas = Archivo.CargarVentas();
        }

        #endregion

        #region Métodos

        public void IngresarProducto()  // 1
        {
            int x = 8, y = 5;
            Producto nuevo_producto = new Producto();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen; Interfaz.Borde();
            Interfaz.xy(48, 3); Console.Write("===INGRESAR UN PRODUCTO==="); Console.ResetColor();

            Interfaz.xy(x, y++); Console.Write("-Ingrese el nombre: ");
            nuevo_producto.Nombre = Console.ReadLine(); y++;

            do
            {
                Interfaz.xy(x, y); Console.Write("-Ingrese el código: ");
                nuevo_producto.Codigo = Console.ReadLine().ToUpper();

                if (Productos.Exists(p => p.Codigo == nuevo_producto.Codigo))
                {
                    Interfaz.xy(x, y); Interfaz.Error("Ya existe un producto con ese código");
                    Console.ReadKey();
                    Interfaz.xy(x, y); Console.Write("                                               ");
                }
            } while (Productos.Exists(p => p.Codigo == nuevo_producto.Codigo));

            y += 2; nuevo_producto.Precio = Producto.ValidarPrecio(y);
            y += 2; nuevo_producto.StockActual = Producto.ValidarStockActual(y);
            y += 2; nuevo_producto.StockMinimo = Producto.ValidarStockMinimo(nuevo_producto.StockActual, y);

            y += 2; Interfaz.xy(x, y); Console.Write("-Ingrese la descripción: ");
            nuevo_producto.Descripcion = Console.ReadLine();

            Productos.Add(nuevo_producto);
            Archivo.GuardarProductos(Productos);
            Console.ForegroundColor = ConsoleColor.Green;
            y += 2; Interfaz.xy(x, y); Console.WriteLine("Producto ingresado correctamente!");
            Console.ResetColor();

            Interfaz.Continuar();
        }

        public void BuscarPorCodigo()  // 2
        {
            int x = 8, y = 5;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; Interfaz.Borde();
            Interfaz.xy(45, 3); Console.Write("===BUSCAR PRODUCTO POR CÓDIGO==="); Console.ResetColor();

            if (Productos.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay productos ingresados");
                Interfaz.Continuar();
                return;
            }

            Interfaz.xy(x, y++); Console.Write("-Ingrese el código del producto: ");
            string codigo = Console.ReadLine().ToUpper();
            Producto producto = Productos.Find(p => p.Codigo == codigo);
            if (producto != null)
            {
                y++;
                Interfaz.xy(x, y++); Console.WriteLine($"Nombre: {producto.Nombre}");
                Interfaz.xy(x, y++); Console.WriteLine($"Código: {producto.Codigo}");
                Interfaz.xy(x, y++); Console.WriteLine($"Precio: ${producto.Precio}");
                Interfaz.xy(x, y++); Console.WriteLine($"Stock actual: {producto.StockActual}");
                Interfaz.xy(x, y++); Console.WriteLine($"Stock mínimo: {producto.StockMinimo}");
                Interfaz.xy(x, y++); Console.WriteLine($"Descripción: {producto.Descripcion}");
            }
            else
            {
                Interfaz.xy(x, y++); Interfaz.Error("No se encontró un producto con ese código");
            }
            Interfaz.Continuar();
        }

        public void ModificarProducto()  // 3
        {
            int x = 8, y = 5;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan; Interfaz.Borde();
            Interfaz.xy(45, 3); Console.Write("===MODIFICAR PRODUCTO==="); Console.ResetColor();

            if (Productos.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay productos ingresados");
                Interfaz.Continuar();
                return;
            }

            Interfaz.xy(x, y++); Console.Write("-Ingrese el código del producto a modificar: ");
            string codigo = Console.ReadLine().ToUpper();
            Producto producto = Productos.FirstOrDefault(p => p.Codigo == codigo);
            if (producto != null)
            {
                Interfaz.xy(x, y++); Console.WriteLine($"El producto '{producto.Nombre}' de código '{producto.Codigo}' fue encontrado"); y++;
                Interfaz.xy(x, y++); Console.WriteLine("DATOS ACTUALES DE STOCK Y PRECIO:");
                Interfaz.xy(x, y++); Console.WriteLine($"-Precio: {producto.Precio}$");
                Interfaz.xy(x, y++); Console.WriteLine($"-Stock actual: {producto.StockActual}");
                Interfaz.xy(x, y++); Console.WriteLine($"-Stock mínimo: {producto.StockMinimo}");

                y++; double nuevo_precio = Producto.ValidarPrecio(y);
                y++; int nuevo_stock_actual = Producto.ValidarStockActual(y);
                y++; int nuevo_stock_minimo = Producto.ValidarStockMinimo(nuevo_stock_actual, y);

                producto.Precio = nuevo_precio;
                producto.StockActual = nuevo_stock_actual;
                producto.StockMinimo = nuevo_stock_minimo;
                Archivo.GuardarProductos(Productos);

                Console.ForegroundColor = ConsoleColor.Green;
                y++; Interfaz.xy(x, y++); Console.WriteLine("El producto ha sido modificado exitosamente.");
                Console.ResetColor();
            }
            else
            {
                Interfaz.xy(x, y++); Interfaz.Error("No se encontró un producto con ese código");
            }
            Interfaz.Continuar();
        }

        public void ProcesarVenta()  // 4
        {
            int x = 8, y = 5;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed; Interfaz.Borde();
            Interfaz.xy(48, 3); Console.Write("===PROCESAR VENTA==="); Console.ResetColor();

            if (Productos.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay productos ingresados. No se puede procesar ninguna venta");
                Interfaz.Continuar();
                return;
            }

            if (Vendedores.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay vendedores contratados. No se puede procesar ninguna venta");
                Interfaz.Continuar();
                return;
            }

            Interfaz.xy(x, y++); Console.Write("-Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Producto producto = Productos.FirstOrDefault(p => p.Nombre == nombre);

            if (producto != null)
            {
                y++; Interfaz.xy(x, y++); Console.WriteLine("DATOS DEL PRODUCTO:");
                Interfaz.xy(x, y++); Console.WriteLine($"Nombre: {producto.Nombre}");
                Interfaz.xy(x, y++); Console.WriteLine($"Código: {producto.Codigo}");
                Interfaz.xy(x, y++); Console.WriteLine($"Precio: {producto.Precio}$");
                Interfaz.xy(x, y++); Console.WriteLine($"Stock actual: {producto.StockActual}");

                y++; int cantidad = Producto.ValidarCantidad(producto.StockActual, y);

                y += 2; Interfaz.xy(x, y++); Console.Write("-Ingrese el nombre del vendedor: ");
                string nombre_vendedor = Console.ReadLine();

                Vendedor vendedor = Vendedores.FirstOrDefault(v => v.Nombre.ToLower() == nombre_vendedor.ToLower());
                if (vendedor == null)
                {
                    Interfaz.Error("No existe un vendedor con ese nombre");
                    Interfaz.Continuar();
                    return;
                }

                producto.ReducirStock(cantidad);
                vendedor.AumentarVentas();
                Venta venta = new Venta(producto, vendedor, cantidad);
                Ventas.Add(venta);

                Archivo.GuardarProductos(Productos);
                Archivo.GuardarVendedores(Vendedores);
                Archivo.GuardarVentas(Ventas);

                Console.ForegroundColor = ConsoleColor.Green;
                y++; Interfaz.xy(x, y++); Console.WriteLine("Venta procesada exitosamente");
                Console.ResetColor();
                Interfaz.Continuar();
                venta.GenerarFactura();
            }
            else
            {
                Interfaz.xy(x, y++); Interfaz.Error("No se encontró un producto con ese nombre");
            }
            Interfaz.Continuar();
        }

        public void EliminarProducto()  // 5
        {
            int x = 8, y = 5;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; Interfaz.Borde();
            Interfaz.xy(48, 3); Console.Write("===ELIMINAR PRODUCTO==="); Console.ResetColor();

            if (Productos.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay productos ingresados");
                Interfaz.Continuar();
                return;
            }

            string op = "";
            Interfaz.xy(x, y++); Console.Write("-Ingrese el código del producto a eliminar: ");
            string codigo = Console.ReadLine().ToUpper();
            Producto producto = Productos.FirstOrDefault(p => p.Codigo == codigo);
            if (producto != null)
            {
                do
                {
                    y++; Interfaz.xy(x, y++); Console.WriteLine($"¿Está seguro que desea eliminar el producto '{producto.Nombre}'?");
                    Interfaz.xy(x, y++); Console.Write("-Opción (SI/NO): ");
                    op = Console.ReadLine();

                    if (op.ToUpper() == "SI")
                    {
                        Productos.Remove(producto);

                        if (Productos.Count == 0)
                        {
                            Archivo.EliminarProductos();
                        }
                        else
                        {
                            Archivo.GuardarProductos(Productos);
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        y++; Interfaz.xy(x, y++); Console.WriteLine("Producto eliminado exitosamente");
                        Console.ResetColor();
                    }
                    else if (op.ToUpper() == "NO")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        y++; Interfaz.xy(x, y++); Console.WriteLine("Operación cancelada");
                        Console.ResetColor();
                    }
                    else
                    {
                        Interfaz.xy(x, y++); Interfaz.Error("Opción inválida");
                    }
                } while (op.ToUpper() != "SI" && op.ToUpper() != "NO");
            }
            else
            {
                y++; Interfaz.xy(x, y++); Interfaz.Error("No se encontró un producto con ese código");
            }
            Interfaz.Continuar();
        }

        public void ContratarVendedor()  // 6
        {
            int x = 8, y = 5;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Interfaz.Borde();
            Interfaz.xy(48, 3); Console.Write("===CONTRATAR VENDEDOR==="); Console.ResetColor();

            Interfaz.xy(x, y++); Console.Write("-Ingrese el nombre del vendedor: ");
            string nombre = Console.ReadLine();

            if (Vendedores.Exists(v => v.Nombre == nombre))
            {
                y++; Interfaz.xy(48, 3); Interfaz.Error("Ya existe un vendedor con ese nombre");
            }
            else
            {
                Vendedores.Add(new Vendedor(nombre, 0));
                Archivo.GuardarVendedores(Vendedores);
                Console.ForegroundColor = ConsoleColor.Green;
                Interfaz.xy(x, y + 1); Console.WriteLine("Vendedor contratado exitosamente");
                Console.ResetColor();
            }
            Interfaz.Continuar();
        }

        public void EliminarVendedor()  // 7
        {
            int x = 8, y = 5;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; Interfaz.Borde();
            Interfaz.xy(48, 3); Console.Write("===ELIMINAR VENDEDOR==="); Console.ResetColor();

            if (Vendedores.Count == 0)
            {
                Interfaz.xy(x, y++); Interfaz.Error("No hay vendedores registrados");
                Interfaz.Continuar();
                return;
            }

            string op = "";
            Interfaz.xy(x, y++); Console.Write("-Ingrese el nombre del vendedor a eliminar: ");
            string nombre = Console.ReadLine();

            Vendedor vendedor = Vendedores.FirstOrDefault(v => v.Nombre.ToLower() == nombre.ToLower());

            if (vendedor != null)
            {
                do
                {
                    y++; Interfaz.xy(x, y++); Console.WriteLine($"¿Está seguro que desea eliminar a este vendedor?");
                    Interfaz.xy(x, y++); Console.Write("-Opción (SI/NO): ");
                    op = Console.ReadLine();

                    if (op.ToUpper() == "SI")
                    {
                        Vendedores.Remove(vendedor);

                        if (Vendedores.Count == 0)
                        {
                            Archivo.EliminarVendedores();
                        }
                        else
                        {
                            Archivo.GuardarVendedores(Vendedores);
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Interfaz.xy(x, y + 1); Console.WriteLine("Vendedor eliminado exitosamente");
                        Console.ResetColor();
                    }
                    else if (op.ToUpper() == "NO")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Interfaz.xy(x, y + 1); Console.WriteLine("Operación cancelada");
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
                Interfaz.xy(x, y + 1); Interfaz.Error("No se encontró ningún vendedor con ese nombre");
            }
            Interfaz.Continuar();
        }

        public void ListarProductos()  //8.1
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PRODUCTOS ===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos registrados");
                Interfaz.Continuar();
                return;
            }

            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine("| CÓDIGO  | NOMBRE           | PRECIO    | STOCK ACTUAL | STOCK MÍNIMO |");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var producto in Productos)
            {
                Console.WriteLine($"| {producto.Codigo,-7} | {producto.Nombre,-15} " +
                                  $"| {producto.Precio,8:C} | {producto.StockActual,12} | {producto.StockMinimo,12} |");
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Interfaz.Continuar();
        }

        public void ListarMasVendidos()  // 8.2
        {
            Console.Clear();
            Console.WriteLine("=== TOP 3 PRODUCTOS MÁS VENDIDOS ===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos registrados");
                Interfaz.Continuar();
                return;
            }

            // Calcular el total de unidades vendidas de todos los productos
            int total_vendidos = Productos.Sum(p => p.Vendidos);

            if (total_vendidos == 0)
            {
                Interfaz.Error("No hay ventas registradas");
                Interfaz.Continuar();
                return;
            }

            var top_mas_vendidos = Productos.OrderByDescending(p => p.Vendidos).Take(3).ToList();

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("| RANK | NOMBRE           | VENDIDOS | PORCENTAJE |");
            Console.WriteLine("-------------------------------------------------");

            for (int i = 0; i < top_mas_vendidos.Count; i++)
            {
                string ranking;
                if (i == 0)
                    ranking = "[1°]";
                else if (i == 1)
                    ranking = "[2°]";
                else if (i == 2)
                    ranking = "[3°]";
                else
                    ranking = $"[{i + 1}°]";

                double porcentaje = (top_mas_vendidos[i].Vendidos * 100.0) / total_vendidos;
                Console.WriteLine($"| {ranking,-5} | {top_mas_vendidos[i].Nombre,-15} | {top_mas_vendidos[i].Vendidos,7}  | {porcentaje,8:N2}% |");
            }

            Console.WriteLine("-------------------------------------------------");
            Interfaz.Continuar();
        }

        public void ListarMenosVendidos()  // 8.3
        {
            Console.Clear();
            Console.WriteLine("=== TOP 3 PRODUCTOS MENOS VENDIDOS ===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos registrados");
                Interfaz.Continuar();
                return;
            }

            int total_vendidos = Productos.Sum(p => p.Vendidos);

            if (total_vendidos == 0)
            {
                Interfaz.Error("No hay ventas registradas");
                Interfaz.Continuar();
                return;
            }

            // Excluye a los productos con 0 ventas
            var top_menos_vendidos = Productos.Where(p => p.Vendidos > 0).OrderBy(p => p.Vendidos).Take(3).ToList();

            if (top_menos_vendidos.Count == 0)
            {
                Interfaz.Error("No hay productos con ventas registradas");
                Interfaz.Continuar();
                return;
            }

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("| RANK | NOMBRE           | VENDIDOS | PORCENTAJE |");
            Console.WriteLine("-------------------------------------------------");

            for (int i = 0; i < top_menos_vendidos.Count; i++)
            {
                string ranking;
                if (i == 0)
                    ranking = "[1°]";
                else if (i == 1)
                    ranking = "[2°]";
                else
                    ranking = "[3°]";

                double porcentaje = (top_menos_vendidos[i].Vendidos * 100.0) / total_vendidos;
                Console.WriteLine($"| {ranking,-5} | {top_menos_vendidos[i].Nombre,-15} | {top_menos_vendidos[i].Vendidos,7}  | {porcentaje,8:N2}% |");
            }

            Console.WriteLine("-------------------------------------------------");
            Interfaz.Continuar();
        }

        public void ListarProductosSurtir()  // 8.4
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS A SURTIR ===");

            if (Productos.Count == 0)
            {
                Interfaz.Error("No hay productos registrados");
                Interfaz.Continuar();
                return;
            }

            var productos_a_surtir = Productos.Where(p => p.StockActual <= p.StockMinimo).OrderBy(p => p.Nombre).ToList();

            if (productos_a_surtir.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n¡Todos los productos tienen stock suficiente!");
                Console.ResetColor();
                Interfaz.Continuar();
                return;
            }

            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine("| CÓDIGO  | NOMBRE           | STOCK ACTUAL | STOCK MÍNIMO | A REPONER |");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var producto in productos_a_surtir)
            {
                int reponer = producto.StockMinimo - producto.StockActual;
                Console.WriteLine($"| {producto.Codigo,-7} | {producto.Nombre,-15} " +
                                  $"| {producto.StockActual,12} | {producto.StockMinimo,12} | {reponer,9} |");
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Interfaz.Continuar();
        }

        public void ListarVendedoresPorVentas()  // 8.5
        {
            Console.Clear();
            Console.WriteLine("=== VENDEDORES POR CANTIDAD DE VENTAS ===");

            if (Vendedores.Count == 0)
            {
                Interfaz.Error("No hay vendedores registrados");
                Interfaz.Continuar();
                return;
            }

            var vendedores_ordenados = Vendedores.OrderByDescending(v => v.VentasRealizadas).ToList();

            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("| PUESTO | NOMBRE          | VENTAS REALIZADAS |");
            Console.WriteLine("------------------------------------------");

            for (int i = 0; i < vendedores_ordenados.Count; i++)
            {
                string puesto = (i + 1).ToString() + "°";
                Console.WriteLine($"| {puesto,-6} | {vendedores_ordenados[i].Nombre,-14} | {vendedores_ordenados[i].VentasRealizadas,17} |");
            }

            Console.WriteLine("------------------------------------------");
            Interfaz.Continuar();
        }

        public void EliminarTodo()  // ADMIN
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR TODOS LOS DATOS ===");

            Console.WriteLine("¿Está seguro que desea eliminar TODOS los datos registrados?");
            Console.Write("-Opción (SI/NO): ");
            string opcion = Console.ReadLine();

            if (opcion.ToUpper() == "SI")
            {
                Archivo.EliminarProductos();
                Archivo.EliminarVendedores();
                Archivo.EliminarVentas();
                Productos.Clear();
                Vendedores.Clear();
                Ventas.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTodos los datos han sido eliminados exitosamente");
                Console.ResetColor();
            }
            else if (opcion.ToUpper() == "NO")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nOperación cancelada");
                Console.ResetColor();
            }
            else
            {
                Interfaz.Error("Opción inválida");
            }
            Interfaz.Continuar();
        }

        #endregion
    }
}
