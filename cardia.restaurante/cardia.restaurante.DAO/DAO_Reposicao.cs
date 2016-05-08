using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Reposicao
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public void NovoReposicao(string Descricao, decimal valor, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_InsertProdutos", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@Valor", valor);
            cmd.Parameters.AddWithValue("@Data_Hora", Data_Hora);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataTable ListarReposicao()
        {
            SqlCommand cmd = new SqlCommand("p_SelectReposicao", conexao);
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

        public void EditarReposicao(int ID, string Descricao, decimal valor, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateReposicao", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@Data_Hora", Data_Hora);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarReposicao(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteReposicao", conexao);

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

    }
}
