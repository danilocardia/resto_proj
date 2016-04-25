using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class PedidoMesa : Pedido
    {
        public int NumeroMesa { get; set; }
        public override void GerarPedidoMesa()
        {
            Console.WriteLine("Garsçon atende os clientes dentro do restaurante");

        }

        public override void GerarPedidoClienteBusca()
        {
            Console.WriteLine("");
        }
        public override void GerarPedidoMotoboyEntrega()
        {
            Console.WriteLine("");
        }
    }
}