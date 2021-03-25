using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public abstract class ProductoCompuesto
    {
        public string Id { get; set; }
        public string Nombre { get; set;}
        public decimal Precio_comp { get; set; }
        public decimal Costo_comp { get; set; }


    }
}
