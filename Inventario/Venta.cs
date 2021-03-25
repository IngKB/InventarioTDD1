using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class Venta
    {
        public decimal Costo_venta { get; set; }

        public decimal Precio_venta { get; set; }

        public List<DetalleVenta> items { get; set; }

        public Venta(List<DetalleVenta> productos)
        {
            this.items = productos;
        }
    }
}
