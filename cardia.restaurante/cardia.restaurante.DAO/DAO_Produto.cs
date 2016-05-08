using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.DAO
{
    public class DAO_Produto
    {   
        
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public void NovoProduto(int ID, string Nome, decimal valor, int ID_Cat)
        {
            SqlCommand cmd = new SqlCommand("p_InsertProdutos", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataTable ListarProduto()
        {
            SqlCommand cmd = new SqlCommand("p_SelectProdutos", conexao);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt_listar_Produto = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            da.Fill(dt_listar_Produto);

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }


            return dt_listar_Produto;
        }

        public void EditarProduto(int ID, string Nome, decimal valor,int ID_Cat)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateProdutos", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarProduto(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteProdutos", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        #endregion

        public DataTable ListarProdutoPorCategoria(int codCat)
        {
            SqlCommand cmd = new SqlCommand("ListarProdutoPorCategoria", conexao);
            DataTable listarporCat = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@valor", codCat);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();            

            da.Fill(listarporCat);

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return listarporCat;
        }

        public DataTable ExibirProdutoPorCategoria()
        {
            DataTable exibirDT  = new DataTable();
            SqlCommand cmd = new SqlCommand("ExibirProdutoPorCategoria", conexao);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            da.Fill(exibirDT);

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }


            return exibirDT;
        }
    }
}
