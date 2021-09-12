using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PedidoConMock;
using Moq;

namespace PedidoConMockTest
{
    [TestClass]
    public class PedidoTest
    {
        private const string BICICLETA = "Bicicleta";

        [TestMethod]
        public void SiHaySuficienteProductoElPedidoSeAcepta()
        {
            var deposito = new Mock<IDeposito>(MockBehavior.Strict);
            Pedido pedido = new Pedido() { Cantidad = 29, Producto = BICICLETA };

            deposito
                .Setup(d => d.StockDelProducto(BICICLETA))
                .Returns(30);

            deposito.Setup(d => d.DespacharPedido(pedido))
                .Verifiable();

            pedido.Despachar(deposito.Object);

            deposito.Verify();
            Assert.AreEqual(EstadoDelPedido.ACEPTADO, pedido.Estado);
        }

        [TestMethod]
        public void SiNoHaySuficienteProductoElPedidoSeRechaza()
        {
            var deposito = new Mock<IDeposito>(MockBehavior.Strict);
            Pedido pedido = new Pedido() { Cantidad = 50, Producto = BICICLETA };

            deposito
                .Setup(d => d.StockDelProducto(BICICLETA))
                .Returns(30);

            pedido.Despachar(deposito.Object);

            deposito.Verify();
            Assert.AreEqual(EstadoDelPedido.RECHAZADO, pedido.Estado);
        }
    }
}
