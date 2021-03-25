using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class ProductoPreparado: ProductoCompuesto
    {
        public List<ProductoSimple> productos { get; set; }

        public ProductoPreparado(string id, string nombre, decimal precio, List<ProductoSimple> productos)
        {
            Id = id;
            Nombre = nombre;
            Precio_comp = precio;
            this.productos = productos;
            this.getCosto();
        }

        public decimal getCosto()
        {
            decimal total = 0;
            foreach (var item in productos)
            {
                total += item.Costo_indi;
            }

            Costo_comp = total;
            return Costo_comp;
        }
    }
}
