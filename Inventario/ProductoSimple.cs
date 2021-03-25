using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class ProductoSimple: Producto
    {


        public decimal Costo_indi { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }

        public ProductoSimple(string id, string nombre, decimal costo_indi, decimal precio, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Costo_indi = costo_indi;
            Precio = precio;
            Cantidad = 0;
            Tipo = tipo;
        }

        public string RegistrarEntrada(int cantidad)
        {
            if (cantidad >= 0)
            {
                this.Cantidad += cantidad;
                return $"Nueva cantidad: {Cantidad}";
            }
            return "Entrada menor o igual a 0";
        }

        public string RegistrarSalida(int cantidad)
        {
            if (cantidad >= 0)
            {
                this.Cantidad -= cantidad;
                return $"Nueva cantidad: {Cantidad}";
            }
            return "Salida menor o igual a 0";
        }
    }
}
