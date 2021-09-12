using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoSinMock
{
    public class Deposito
    {
        private Dictionary<string, int> productos;

        public Deposito()
        {
            this.productos = new Dictionary<string, int>();
        }

        public void AgregarProducto(string claveProducto, int stock)
        {
            this.productos.Add(claveProducto, stock);
        }

        public int StockDelProducto(string claveProducto)
        {
            if (this.productos.ContainsKey(claveProducto))
            {
                return this.productos[claveProducto];
            }

            return 0;
        }

        public void DespacharPedido(Pedido pedido)
        {
            int stock = this.StockDelProducto(pedido.Producto);

            if (stock >= pedido.Cantidad)
            {
                this.productos[pedido.Producto] = stock - pedido.Cantidad;
                pedido.Estado = EstadoDelPedido.ACEPTADO;
            }
            else
            {
                pedido.Estado = EstadoDelPedido.RECHAZADO;
            }
        }
    }
}
