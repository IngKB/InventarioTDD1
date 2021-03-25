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
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");
            inventario.RegistrarProducto(salchicha);
            inventario.RegistrarEntrada(salchicha.Id, 10);

            RegistroVentas ventas = new RegistroVentas();

           
            //Act
            var respuesta = ventas.RegistrarVenta(new Venta("001",-1), inventario);

            //Assert
            Assert.AreEqual("Salida menor o igual a 0", respuesta);
        }

        /*
       DADO que se ha registrado un producto simple
       CUANDO se registre una salida
       ENTONCES el sistema debe disminuir la cantidad existente 
       */
        [Test]
        public void SalidaDebeDisminuirCantidad()
        {
            //Arrange
            InventarioProductos inventario = new InventarioProductos();
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");
            inventario.RegistrarProducto(salchicha);
            inventario.RegistrarEntrada(salchicha.Id, 10);

            RegistroVentas ventas = new RegistroVentas();


            //Act
            var respuesta = ventas.RegistrarVenta(new Venta("001", 6), inventario);

            //Assert
            Assert.AreEqual("Nueva cantidad: 4", respuesta);
        }
    }
}