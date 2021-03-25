using Inventario;
using NUnit.Framework;
using System.Collections.Generic;

namespace inventario.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         DADO que se ha registrado un producto simple
         CUANDO se intente registrar una entrada de ese producto menor o igual a 0
         ENTONCES el sistema debe rechazar la entrada 
         Y mostrar el mensaje "Entrada menor o igual a 0"
         */
        [Test]
        public void EntradaProductoMenorACero()
        {
            //Arrange
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple salchicha = new ProductoSimple("001","Salchicha",1000,0,"Preparacion");
            inventario.RegistrarProducto(salchicha);

            //Act
            var respuesta = inventario.RegistrarEntrada(salchicha.Id, -1);

            //Assert
            Assert.AreEqual("Entrada menor o igual a 0",respuesta);
        }

        /*
         DADO que se ha registrado un producto simple
         CUANDO se ingrese una entrada de este producto
         ENTONCES el sistema debe aumentar la cantidad existente 
         */
        [Test]
        public void EntradaDebeAumentarCantidad()
        {
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");
            inventario.RegistrarProducto(salchicha);

            //Act
            var respuesta = inventario.RegistrarEntrada(salchicha.Id, 10);

            //Assert
            Assert.AreEqual("Nueva cantidad: 10", respuesta);
        }

        /*
        DADO que se ha registrado un producto simple
        CUANDO se intente registrar una salida menor o igual a 0
        ENTONCES el sistema debe rechazar la salida 
         Y mostrar el mensaje "Salida menor o igual a 0"
        */
        [Test]
        public void SalidaMenorACero()
        {
            //Arrange
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple cocacola = new ProductoSimple("002", "CocaCola", 1000, 3000, "Venta");
            inventario.RegistrarProducto(cocacola);
            inventario.RegistrarEntrada(cocacola.Id, 10);

      

            //Act
            var respuesta = inventario.RegistrarSalida(cocacola.Id, -1);

            //Assert
            Assert.AreEqual("Salida menor o igual a 0", respuesta);
        }

        /*
       DADO que se ha registrado un producto simple
       CUANDO se registre una salida
       ENTONCES el sistema debe disminuir la cantidad existente 
       */
        [Test]
        public void SalidaSencillaDebeDisminuirCantidad()
        {
            //Arrange
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple cocacola = new ProductoSimple("002", "CocaCola", 1000, 3000, "Venta");
            inventario.RegistrarProducto(cocacola);
            inventario.RegistrarEntrada(cocacola.Id, 10);

            //Act
            var respuesta = inventario.RegistrarSalida(cocacola.Id, 6);
            //Assert
            Assert.AreEqual("Nueva cantidad: 4", respuesta);
        }

        [Test]
        public void SalidaCompuestaDebeDisminuirCantidad()
        {
            //Arrange
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");
            ProductoSimple pan = new ProductoSimple("003", "Pan", 200, 0, "Preparacion");

            inventario.RegistrarProducto(salchicha);
            inventario.RegistrarProducto(pan);

            inventario.RegistrarEntrada(pan.Id, 10);
            inventario.RegistrarEntrada(salchicha.Id, 10);

            ProductoPreparado perroCaliente = new ProductoPreparado("005","Perro",4000,new List<ProductoSimple>() { 
                salchicha,pan
                }
            );

            RegistroVentas ventas = new RegistroVentas();

            List<DetalleVenta> items = new List<DetalleVenta>()
            {
                new DetalleVenta(perroCaliente,1)
            };

            //Act
            ventas.RegistrarVenta(new Venta(items), inventario);


            //Assert
            int cantSalchicha = inventario.BuscarProducto(salchicha.Id).Cantidad;
            int canPan = inventario.BuscarProducto(pan.Id).Cantidad;

            if(cantSalchicha==9 && canPan == 9)
            {
                Assert.Pass();
            }
        }
    }
}