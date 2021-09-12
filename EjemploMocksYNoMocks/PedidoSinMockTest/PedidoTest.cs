using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PedidoSinMock;

namespace PedidoSinMockTest
{
    [TestClass]
    public class PedidoTest
    {
        private const string BICICLETA = "Bicicleta";

        [TestMethod]
        public void SiHaySuficienteProductoElPedidoSeAcepta()
        {
            Deposito deposito = new Deposito();
            deposito.AgregarProducto(BICICLETA, 30);
            Pedido pedido = new Pedido() { Cantidad = 29, Producto = BICICLETA };

            pedido.Despachar(deposito);

            Assert.AreEqual(EstadoDelPedido.ACEPTADO, pedido.Estado);
            Assert.AreEqual(1, deposito.StockDelProducto(BICICLETA));
        }

        [TestMethod]
        public void SiNoHaySuficienteProductoElPedidoSeRechaza()
        {
            Deposito deposito = new Deposito();
            deposito.AgregarProducto(BICICLETA, 30);
            Pedido pedido = new Pedido() { Cantidad = 50, Producto = BICICLETA };

            pedido.Despachar(deposito);

            Assert.AreEqual(EstadoDelPedido.RECHAZADO, pedido.Estado);
            Assert.AreEqual(30, deposito.StockDelProducto(BICICLETA));
        }
    }
}
