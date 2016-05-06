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
        public int IdPedido { get; set; }
        public List<string> ListarCategoriaPorProd(int cod)
        {
            DAO_Produto prod = new DAO_Produto();
            DataTable listarPorCat = new DataTable();
            List<string> exibir = new List<string>();

            listarPorCat = prod.ListarProdutoPorCategoria(cod);

            for (int i = 0; i < listarPorCat.Rows.Count; i++)
            {
                exibir.Add(listarPorCat.Rows[i][0] + " " + listarPorCat.Rows[i][1] + " " + listarPorCat.Rows[i][2]);
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

        public void AdicionarItens(int ID_Cat, int ID_Prod, int QTD, int ID_IA, int QTD_IA, string OBS, decimal Preco)
        {
            DAO_Itens adItens = new DAO_Itens();

            int Id_Pedido = PegarUltimoPedido();

            if (ID_IA == 0 && QTD_IA == 0 && OBS == string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, Preco, Id_Pedido); //Não deseja Item adicional e não tem observação

            else if (ID_IA == 0 && QTD_IA == 0 && OBS != string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, OBS, Preco, Id_Pedido); //Não deseja Item adicional e tem observação

            else if (ID_IA != 0 && QTD_IA != 0 && OBS == string.Empty)
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, Preco, Id_Pedido);//deseja Item adicional e não tem observação

            else
                adItens.NovoItens(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, OBS, Preco, Id_Pedido);//deseja Item adicional e tem observação
        }

        public DataTable listarItensDeUmPedido()
        {
            //DAO_Pedidos pegarPedido = new DAO_Pedidos();
            DAO_Itens pegarPedido = new DAO_Itens();
            DataTable DT = new DataTable();
            int ID_IA = 0, QTD_IA = 0;
            string OBS = "";

            //int IdPedido = 4;
            DT.Columns.Add("ID_Cat", typeof(int));
            DT.Columns.Add("ID_Prod", typeof(int));
            DT.Columns.Add("QTD", typeof(int));
            DT.Columns.Add("ID_IA", typeof(int));
            DT.Columns.Add("QTD_IA", typeof(int));
            DT.Columns.Add("OBS", typeof(string));
            DT.Columns.Add("Preco", typeof(decimal));
            DT.Columns.Add("IdPedido", typeof(int));

            for (int i = 0; i < pegarPedido.ListarItens().Rows.Count; i++)
            {
                if (IdPedido == Convert.ToInt32(pegarPedido.ListarItens().Rows[i][8]))
                {
                    try
                    {
                        ID_IA = Convert.ToInt32(pegarPedido.ListarItens().Rows[i][4]);
                    }
                    catch (Exception)
                    {
                        ID_IA = 0;
                    }

                    try
                    {
                        QTD_IA = Convert.ToInt32(pegarPedido.ListarItens().Rows[i][5]);
                    }
                    catch (Exception)
                    {
                        QTD_IA = 0;
                    }

                    try
                    {
                        OBS = pegarPedido.ListarItens().Rows[i][6].ToString();
                    }
                    catch (Exception)
                    {
                        OBS = string.Empty;
                    }

                    DT.Rows.Add(Convert.ToInt32(pegarPedido.ListarItens().Rows[i][1]), Convert.ToInt32(pegarPedido.ListarItens().Rows[i][2]), Convert.ToInt32(pegarPedido.ListarItens().Rows[i][3]), ID_IA, QTD_IA, OBS, Convert.ToDecimal(pegarPedido.ListarItens().Rows[i][7]), Convert.ToInt32(pegarPedido.ListarItens().Rows[i][8]));
                }//Convert.ToInt32(pegarPedido.ListarItens().Rows[i][0]), 
            }

            return DT;
        }
    }
}
