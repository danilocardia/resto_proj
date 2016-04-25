using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class PedidoMotoboyEntrega : Pedido
    {
        public string nomeCliente { get; set; }
        public string enderecoEntrega { get; set; }
        public override void GerarPedidoMotoboyEntrega()
        {
            Console.WriteLine("Entrega Motoboy");
        }

        public override void GerarPedidoClienteBusca()
        {
            Console.WriteLine("");
        }

        public override void GerarPedidoMesa()
        {
            Console.WriteLine("");
        }
    }
}
