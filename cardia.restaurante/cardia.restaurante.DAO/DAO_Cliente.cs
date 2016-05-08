using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Cliente
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public DataTable ListarCliente()
        {
            SqlCommand cmd = new SqlCommand("p_SelectCliente", conexao);
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

        public void NovoCliente(int ID_Pedido, string NomeCli, decimal ValorTotal, bool Entrega)
        {
            SqlCommand cmd = new SqlCommand("p_InsertCliente", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);
            cmd.Parameters.AddWithValue("@NomeCli", NomeCli);
            cmd.Parameters.AddWithValue("@ValorTotal", ValorTotal);
            cmd.Parameters.AddWithValue("@Entrega", Entrega);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void EditarCliente(int ID, int ID_Pedido, string NomeCli, decimal ValorTotal, bool Entrega)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateCliente", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);
            cmd.Parameters.AddWithValue("@NomeCli", NomeCli);
            cmd.Parameters.AddWithValue("@ValorTotal", ValorTotal);
            cmd.Parameters.AddWithValue("@Entrega", Entrega);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarCliente(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteCliente", conexao);

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
