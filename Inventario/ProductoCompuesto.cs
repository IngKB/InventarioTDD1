using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public abstract class ProductoCompuesto:Producto
    {

        public decimal Precio_comp { get; set; }
        public decimal Costo_comp { get; set; }

    }
}
