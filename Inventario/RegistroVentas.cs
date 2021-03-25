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

        public string RegistrarVenta(Venta venta, InventarioProductos inv)
        {
            var respuesta = inv.RegistrarSalida(venta.idProd,venta.Cantidad);
            if (respuesta.Contains("Nueva"))
            {
                this.Ventas.Add(venta);
            }
            return respuesta;

        }

    }
}
