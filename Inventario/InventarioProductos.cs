using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class InventarioProductos
    {
        public List<ProductoSimple> Productos { get; set; }

        public InventarioProductos()
        {
            Productos = new List<ProductoSimple>();
        }

        public void RegistrarProducto(ProductoSimple prod)
        {
            this.Productos.Add(prod);
        }

        public ProductoSimple BuscarProducto(string id)
        {
            return this.Productos.Find(x => x.Id.Equals(id));
        }


        public string RegistrarEntrada(string id, int cantidad)
        {
            return BuscarProducto(id).RegistrarEntrada(cantidad);
        }

        public void RegistrarSalidaPreparado(ProductoPreparado prod, int cantidad)
        {
            for(int i = 0; i < cantidad; i++)
            {
                foreach (var item in prod.productos)
                {
                    RegistrarSalida(item.Id, 1);
                }
            }
        }

        public string RegistrarSalida(string id, int cantidad)
        {
           
            return BuscarProducto(id).RegistrarSalida(cantidad);
        }
    }
}
