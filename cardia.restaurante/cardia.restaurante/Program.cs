using cardia.restaurante.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cardia.restaurante.RegraNegocio;

namespace cardia.restaurante
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.Date);
            Console.WriteLine(DateTime.Now.ToLongTimeString());

            Pedido n = new Pedido();
            decimal val = Convert.ToDecimal(78.40);
            n.AdicionarItens(1,1,2,1,1,"Observação",val,1);
            

            Console.ReadKey();
        }

        static void AbrirCaixa()
        {
            decimal valor = 0;
            DateTime data = DateTime.Now.Date;
            AberturaCaixa abrir = new AberturaCaixa();


            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    if (abrir.verificarRegistroMotoboy() == false)
                    {
                        Console.Write("\nDigite o valor para o motoboy: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        abrir.setor = 2;
                        abrir.valor = valor;
                        abrir.VerificarCAixa();
                        Console.Clear();

                        Console.WriteLine(abrir.retornar);
                    }
                    break;
                }
                else
                {
                    if (abrir.verificarRegistroBalcao() == false)
                    {
                        Console.Write("\nDigite o valor para o balcão: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        abrir.setor = 1;
                        abrir.valor = valor;
                        abrir.VerificarCAixa();

                        Console.Clear();
                        Console.WriteLine(abrir.retornar);
                    }
                }
            }

            Console.WriteLine("Já foi efetuado abertura de caixa para o balcão e motoboy.");
        }

        static void verUltimosRegistrosAbrirCAixa()
        {
            AberturaCaixa abrir = new AberturaCaixa();
            DataTable dt = new DataTable();
            DataRow drow1, drow2;
            
            dt = abrir.ListarRegistrodeHoje();

            if (dt.Rows.Count > 1)
            {
                drow1 = dt.Rows[dt.Rows.Count - 1];
                drow2 = dt.Rows[dt.Rows.Count - 2];

                if (Convert.ToDateTime(drow1.ItemArray[3]).ToString("dd/MM/yyy") != DateTime.Now.Date.ToString("dd/MM/yyy") &&
                    Convert.ToDateTime(drow2.ItemArray[3]).ToString("dd/MM/yyy") != DateTime.Now.Date.ToString("dd/MM/yyy"))
                {
                    Console.WriteLine("reree");
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine(dt.Rows[i][0] + " " + dt.Rows[i][1] + " " + dt.Rows[i][2] + " " + dt.Rows[i][3]);
                }
            }
        }

        static void ListarCategoriaPorProd()
        {
            Pedido pedido = new Pedido();

            for (int i = 0; i < pedido.ListarCategoriaPorProd(1).Count; i++)
            {
                Console.WriteLine(pedido.ListarCategoriaPorProd(1)[i]);
            }
        }

        static void ExibirCategoriaPorProd()
        {
            Pedido pedido = new Pedido();

            for (int i = 0; i < pedido.ExibirProdutoPorCategoria().Count; i++)
            {
                Console.WriteLine(pedido.ExibirProdutoPorCategoria()[i]);
            }
        }

    }//classe program
}//Namespace
