using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public class RegistroVentas
    {
        public List<Venta> Ventas { get; set; }

        public RegistroVentas()
        {
            Ventas = new List<Venta>();
        }

        public void RegistrarVenta(Venta venta, InventarioProductos inv)
        {
            foreach (var item in venta.items)
            {
                
                if(item.prod is ProductoSimple)
                {
                   inv.RegistrarSalida(item.prod.Id, item.cantidad);
                }

                if(item.prod is ProductoPreparado)
                {
                    inv.RegistrarSalidaPreparado(item.prod as ProductoPreparado, item.cantidad);
                }


            }
            
            Ventas.Add(venta);

        }

    }
}
