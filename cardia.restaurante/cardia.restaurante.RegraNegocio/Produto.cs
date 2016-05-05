using cardia.restaurante.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class Produto
    {
        public decimal calcularPrecoDoProduto(int ID_Prod, int QTD, int ID_IA, int QTD_IA)
        {
            DAO_Produto calcProduto = new DAO_Produto();
            DAO_ItensAdicionais calcItensAdicionais = new DAO_ItensAdicionais();
            decimal preco = 0;
            //DataRow dRowID, dRowPreco;
            //DataTable DT_Produto = new DataTable();

            for (int i = 0; i < calcProduto.ListarProduto().Rows.Count; i++)
            {
                if (ID_Prod == Convert.ToInt32(calcProduto.ListarProduto().Rows[i][0]))
                {
                    preco = QTD * Convert.ToDecimal(calcProduto.ListarProduto().Rows[i][2]);
                    break;
                }
            }

            for (int i = 0; i < calcItensAdicionais.ListarItemAdicional().Rows.Count; i++)
            {
                if (ID_IA == Convert.ToInt32(calcItensAdicionais.ListarItemAdicional().Rows[i][0]))
                {
                    preco += QTD_IA * Convert.ToDecimal(calcItensAdicionais.ListarItemAdicional().Rows[i][2]);
                    break;
                }
            }

            return preco;
        }
    }
}
