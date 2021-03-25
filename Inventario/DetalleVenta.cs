using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class DetalleVenta
    {
        public Producto prod { get; set; }
        public int cantidad { get; set; }

        public DetalleVenta(Producto prod, int cantidad)
        {
            this.prod = prod;
            this.cantidad = cantidad;
        }
    }
}
