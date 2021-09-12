using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoConMock
{
    public interface IDeposito
    {
        void DespacharPedido(Pedido pedido);
        int StockDelProducto(string claveProducto);
    }
}
