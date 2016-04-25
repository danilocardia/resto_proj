using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public abstract class Pedido
    {
        public int idProduto { get; set; }
        public string categoriaProduto { get; set; }
        public string produto { get; set; }
        public int qtdProduto { get; set; }
        public string descricao { get; set; }
        public string itemAdcional { get; set; }
        public int qtdItemAdicional { get; set; }

        public abstract void GerarPedidoMesa();

        public abstract void GerarPedidoClienteBusca();

        public abstract void GerarPedidoMotoboyEntrega();
    }
}
