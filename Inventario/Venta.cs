using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class Venta
    {
        public decimal Costo_venta { get; set; }

        public decimal Precio_venta { get; set; }

        public string idProd { get; set; }

        public int Cantidad { get; set; }

        public Venta(string idProd, int cantidad)
        {
            this.idProd = idProd;
            Cantidad = cantidad;
        }
    }
}
