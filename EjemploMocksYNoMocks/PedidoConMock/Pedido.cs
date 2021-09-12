using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoConMock
{
    public enum EstadoDelPedido
    {
        ACEPTADO,
        RECHAZADO
    }

    public class Pedido
    {
        public int Cantidad { get; set; }
        public EstadoDelPedido Estado { get; set; }
        public string Producto { get; set; }

        public void Despachar(IDeposito deposito)
        {
            int stock = deposito.StockDelProducto(this.Producto);

            if (stock >= this.Cantidad)
            {
                deposito.DespacharPedido(this);
                this.Estado = EstadoDelPedido.ACEPTADO;
            }
            else
            {
                this.Estado = EstadoDelPedido.RECHAZADO;
            }
        }
    }
}
