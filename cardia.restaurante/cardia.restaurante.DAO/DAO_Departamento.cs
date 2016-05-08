using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Departamento
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public DataTable ListarDepartamento()
        {
            SqlCommand cmd = new SqlCommand("p_SelectDepartamento", conexao);
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

        public void NovoDepartamento(string Nome)
        {
            SqlCommand cmd = new SqlCommand("p_InsertDepartamento", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", Nome);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void EditarDepartamento(int ID, string Nome)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateDepartamento", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Nome", Nome);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarDepartamento(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteDepartamento", conexao);

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
