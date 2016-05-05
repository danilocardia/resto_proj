using cardia.restaurante.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class Pedido
    {
        public List<string> ListarCategoriaPorProd(int cod)
        {
            DAO_Produto prod = new DAO_Produto();
            DataTable listarPorCat = new DataTable();
            List<string> exibir = new List<string>();

            listarPorCat = prod.ListarProdutoPorCategoria(cod);

            for (int i = 0; i < listarPorCat.Rows.Count; i++)
            {
                exibir.Add(listarPorCat.Rows[i][0]+" "+listarPorCat.Rows[i][1]+" "+listarPorCat.Rows[i][2]);
            }

            return exibir;
        }

        public List<string> ExibirProdutoPorCategoria()
        {
            DAO_Produto prod = new DAO_Produto();
            DataTable exibirDT = new DataTable();
            List<string> exibir = new List<string>();

            exibirDT = prod.ExibirProdutoPorCategoria();

            for (int i = 0; i < exibirDT.Rows.Count; i++)
            {
                exibir.Add(exibirDT.Rows[i][0].ToString() + " " + exibirDT.Rows[i][1].ToString() + " " + exibirDT.Rows[i][2].ToString());
            }

            return exibir;
        }

        public void NovoPedido()
        {
            DAO_Pedidos novoPedido = new DAO_Pedidos();

            novoPedido.NovoPedidos(DateTime.Now);
        }

        private int PegarUltimoPedido()
        {
            DAO_Pedidos pegarPedido = new DAO_Pedidos();
            DataRow cod;
            int IdPedido = 0;

            cod = pegarPedido.ListarPedidos().Rows[pegarPedido.ListarPedidos().Rows.Count - 1];

            IdPedido = Convert.ToInt32(cod.ItemArray[0]);

            return IdPedido;
        }

        public virtual void AdicionarItens(int ID_Cat, int ID_Prod, int QTD, int ID_IA, int QTD_IA, string OBS, decimal Preco, int Id_Pedido)
        {
            DAO_Itens adItens = new DAO_Itens();
            int IdPedido = PegarUltimoPedido();

            if (ID_IA == 0 && QTD_IA == 0 && OBS == string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, Preco, Id_Pedido); //Não deseja Item adicional e não tem observação

            else if (ID_IA == 0 && QTD_IA == 0 && OBS != string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, OBS, Preco, Id_Pedido); //Não deseja Item adicional e tem observação

            else if (ID_IA != 0 && QTD_IA != 0 && OBS == string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, Preco, Id_Pedido);//deseja Item adicional e não tem observação

            else
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, OBS, Preco, Id_Pedido);//deseja Item adicional e tem observação
        }

    }
}
