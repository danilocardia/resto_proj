using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cardia.restaurante.RegraNegocio
{
    public class DAO_Itens
    {
        SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Carriel_Lanches"].ToString());

        #region Produto CRUD básico
        public DataTable ListarItens()
        {
            SqlCommand cmd = null;
            DataTable dt_listar_Produto = null;
            SqlDataAdapter da = null;

            cmd = new SqlCommand("p_SelectItens", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            dt_listar_Produto = new DataTable();
            da = new SqlDataAdapter(cmd);

            conexao.Open();

            da.Fill(dt_listar_Produto);

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }


            return dt_listar_Produto;
        }

        //Não deseja Item adicional e tem observação  

        public void NovoItens(int ID_Cat, int ID_Prod, int QTD, int ID_IA, int QTD_IA, string OBS, decimal Preco, int Id_Pedido)//deseja Item adicional e tem observação
        {
            SqlCommand cmd = new SqlCommand("p_InsertItens", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);
            cmd.Parameters.AddWithValue("@ID_Prod", ID_Prod);
            cmd.Parameters.AddWithValue("@QTD", QTD);
            cmd.Parameters.AddWithValue("@ID_IA", ID_IA);
            cmd.Parameters.AddWithValue("@QTD_IA", QTD_IA);
            cmd.Parameters.AddWithValue("@OBS", OBS);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void NovoItens(int ID_Cat, int ID_Prod, int QTD, int ID_IA, int QTD_IA, decimal Preco, int Id_Pedido)//deseja Item adicional e não tem observação
        {
            SqlCommand cmd = new SqlCommand("p_InsertItens_V1", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);
            cmd.Parameters.AddWithValue("@ID_Prod", ID_Prod);
            cmd.Parameters.AddWithValue("@QTD", QTD);
            cmd.Parameters.AddWithValue("@ID_IA", ID_IA);
            cmd.Parameters.AddWithValue("@QTD_IA", QTD_IA);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void NovoItens(int ID_Cat, int ID_Prod, int QTD, decimal Preco, int Id_Pedido)//Não deseja Item adicional e não tem observação
        {
            SqlCommand cmd = new SqlCommand("p_InsertItens_V2", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);
            cmd.Parameters.AddWithValue("@ID_Prod", ID_Prod);
            cmd.Parameters.AddWithValue("@QTD", QTD);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void NovoItens(int ID_Cat, int ID_Prod, int QTD, string OBS, decimal Preco, int Id_Pedido)//Não deseja Item adicional e tem observação  
        {
            SqlCommand cmd = new SqlCommand("p_InsertItens_V3", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);
            cmd.Parameters.AddWithValue("@ID_Prod", ID_Prod);
            cmd.Parameters.AddWithValue("@QTD", QTD);
            cmd.Parameters.AddWithValue("@OBS", OBS);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }


        public void EditarItens(int ID, int ID_Cat, int ID_Prod, int QTD, int ID_IA, int QTD_IA, string OBS, decimal Preco, int Id_Pedido)
        {
            SqlCommand cmd = new SqlCommand("p_UpdateItens", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@ID_Cat", ID_Cat);
            cmd.Parameters.AddWithValue("@ID_Prod", ID_Prod);
            cmd.Parameters.AddWithValue("@QTD", QTD);
            cmd.Parameters.AddWithValue("@ID_IA", ID_IA);
            cmd.Parameters.AddWithValue("@QTD_IA", QTD_IA);
            cmd.Parameters.AddWithValue("@OBS", OBS);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Id_Pedido", Id_Pedido);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conexao.Open();

            cmd.ExecuteNonQuery().ToString();

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void DeletarItens(int ID)
        {
            SqlCommand cmd = new SqlCommand("p_DeleteItens", conexao);

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
//Não deseja Item adicional e não tem observação implementado
//Não deseja Item adicional e tem observação  implementado
//deseja Item adicional e tem observação  tudo
//deseja Item adicional e não tem observação