using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Motoboy
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public void NovoMotoboy(int ID_Cli, int ID_End, int Num_Resid, decimal Valor_Entrega)
        {
            SqlCommand cmd = new SqlCommand("p_InsertMotoboy", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cli", ID_Cli);
            cmd.Parameters.AddWithValue("@ID_End", ID_End);
            cmd.Parameters.AddWithValue("@Num_Resid", Num_Resid);
            cmd.Parameters.AddWithValue("@ValorEntrega", Valor_Entrega);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public DataTable ListarMotoboy()
        {
            SqlCommand cmd = new SqlCommand("p_SelectMotoboy", conexao);
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

        public void EditarMotoboy(int ID, string Nome, decimal valor, int ID_Cat)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateMotoboy", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@ID_Cli", Nome);
            cmd.Parameters.AddWithValue("@ID_End", valor);
            cmd.Parameters.AddWithValue("@Num_Resid", ID_Cat);
            cmd.Parameters.AddWithValue("@ValorEntrega", ID_Cat);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarMotoboy(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteMotoboy", conexao);

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
