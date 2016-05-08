using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Sangria
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public void NovoSangria(string Descricao, decimal valor, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_InsertSangria", conexao);

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

        public DataTable ListarSangria()
        {
            SqlCommand cmd = new SqlCommand("p_SelectSangria", conexao);
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

        public void EditarSangria(int ID, string Descricao, decimal valor, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateSangria", conexao);

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

        public void DeletarSangria(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteSangria", conexao);

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
