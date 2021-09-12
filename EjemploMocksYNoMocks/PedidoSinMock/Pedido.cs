using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoSinMock
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

        public void Despachar(Deposito deposito)
        {
            deposito.DespacharPedido(this);
        }
    }
}
