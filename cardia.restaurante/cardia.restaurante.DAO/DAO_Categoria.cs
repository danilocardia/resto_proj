using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Categoria
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public DataTable ListarCategoria()
        {
            SqlCommand cmd = new SqlCommand("p_SelectCategoria", conexao);
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

        public void NovoCategoria(string NomeCategoria)
        {
            SqlCommand cmd = new SqlCommand("p_InsertCategoria", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NomeCategoria", NomeCategoria);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void EditarCategoria(int ID, string NomeCategoria)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateCategoria", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@NomeCategoria", NomeCategoria);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarCategoria(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteCategoria", conexao);

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
