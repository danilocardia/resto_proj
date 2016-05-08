using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Mesa
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public DataTable ListarMesa()
        {
            SqlCommand cmd = new SqlCommand("p_SelectMesa", conexao);
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

        public void NovoMesa(int ID_Pedido, int Num_Mesa, bool EstadoMesa, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_InsertMesa", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);
            cmd.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);
            cmd.Parameters.AddWithValue("@EstadoMesa", EstadoMesa);
            cmd.Parameters.AddWithValue("@Data_Hora", Data_Hora);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void EditarMesa(int ID, int ID_Pedido, int Num_Mesa, bool EstadoMesa, DateTime Data_Hora)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateMesa", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);
            cmd.Parameters.AddWithValue("@Num_Mesa", Num_Mesa);
            cmd.Parameters.AddWithValue("@EstadoMesa", EstadoMesa);
            cmd.Parameters.AddWithValue("@Data_Hora", Data_Hora);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarMesa(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteMesa", conexao);

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
