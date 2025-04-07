using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    public static class Archivo
    {
        #region Atributos

        private static readonly string Directorio = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly BinaryFormatter Formateador = new BinaryFormatter();

        #endregion

        #region Métodos

        public static void Guardar<T>(List<T> datos, string nombre_archivo)
        {
            string ruta_completa = Path.Combine(Directorio, nombre_archivo);
            try
            {
                using (FileStream stream = new FileStream(ruta_completa, FileMode.Create))
                {
                    Formateador.Serialize(stream, datos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar {nombre_archivo}: {ex.Message}");
                throw;
            }
        }

        public static void Eliminar(string nombre_archivo)
        {
            string ruta_completa = Path.Combine(Directorio, nombre_archivo);
            if (File.Exists(ruta_completa))
            {
                try
                {
                    File.Delete(ruta_completa);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar {nombre_archivo}: {ex.Message}");
                    throw;
                }
            }
        }

        public static List<T> Cargar<T>(string nombre_archivo)
        {
            string ruta_completa = Path.Combine(Directorio, nombre_archivo);
            if (!File.Exists(ruta_completa))
            {
                return new List<T>();
            }

            try
            {
                using (FileStream stream = new FileStream(ruta_completa, FileMode.Open))
                {
                    return (List<T>)Formateador.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar {nombre_archivo}: {ex.Message}");
                return new List<T>();
            }
        }

        public static void GuardarProductos(List<Producto> productos) => Guardar(productos, "productos.dat");
        public static List<Producto> CargarProductos() => Cargar<Producto>("productos.dat");
        public static void EliminarProductos() => Eliminar("productos.dat");
        public static void GuardarVendedores(List<Vendedor> vendedores) => Guardar(vendedores, "vendedores.dat");
        public static List<Vendedor> CargarVendedores() => Cargar<Vendedor>("vendedores.dat");
        public static void EliminarVendedores() => Eliminar("vendedores.dat");
        public static void GuardarVentas(List<Venta> ventas) => Guardar(ventas, "ventas.dat");
        public static List<Venta> CargarVentas() => Cargar<Venta>("ventas.dat");
        public static void EliminarVentas() => Eliminar("ventas.dat");

        #endregion
    }
}
