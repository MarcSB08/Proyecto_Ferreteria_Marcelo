using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ferreteria_Marcelo
{
    internal class Vendedor
    {
        #region Atributos

        private string Nombre { get; set; }
        private int VentasRealizadas { get; set; }

        #endregion

        #region Constructor

        public Vendedor(string nombre, int ventas_realizadas)  // Constructor con parámetros
        {
            Nombre = nombre;
            VentasRealizadas = ventas_realizadas;
        }

        public Vendedor() : this("", 0) { }  // Constructor sin parámetros

        #endregion

        #region Métodos

        public string GetNombre() => Nombre;
        public int GetVentasRealizadas() => VentasRealizadas;
        public void AumentarVentas() => VentasRealizadas++;


        #endregion
    }
}
