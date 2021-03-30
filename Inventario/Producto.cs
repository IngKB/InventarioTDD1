using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario
{
    public abstract class Producto
    {
        private string Id { get; set; }
        public string Nombre { get; protected set; }
        protected decimal Costo { get; set; }

        public Producto(string id, string nombre, decimal costo)
        {
            Id = id;
            Nombre = nombre;
            Costo = costo;
        }

        public abstract string RegistrarSalida(int cantidad);


        public abstract decimal getCosto();

    }
}
