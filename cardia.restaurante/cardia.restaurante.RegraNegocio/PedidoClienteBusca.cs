using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class PedidoClienteBusca : Pedido
    {
        public string nomeCliente { get; set; }

        public override void GerarPedidoClienteBusca()
        {
            Console.WriteLine("Cliente vem buscar");
        }

        public override void GerarPedidoMesa()
        {
            Console.WriteLine("");
        }

        public override void GerarPedidoMotoboyEntrega()
        {
            Console.WriteLine("");
        }
    }
}
