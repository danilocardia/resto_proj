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
            int val = 0;

            do
            {
                Console.WriteLine("Codigos:\n 1 - para Abrir Caixa, 2 - Ver data de ultimo de ultima abertura caixa,\n 3 - Listar categoria por Produto, 4 - Exibir categoria por Produto,\n 9 - Limpa a tela");
                Console.Write("Digite o codigo desejado: ");
                val = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                MENU(val);
                
            } while (val != 0);

            Console.WriteLine("Operação finalizada. Pressione qualquer tecla para finalizar a aplicação.");
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
                    Console.WriteLine("Ultima abertura de caixa foi: " + Convert.ToDateTime(drow1.ItemArray[3]).ToString("dd/MM/yyy")+"\n");
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine(dt.Rows[i][0] + " " + dt.Rows[i][1] + " " + dt.Rows[i][2] + " " + dt.Rows[i][3]);
                }
            }
        }

        static void ListarCategoriaPorProd(int CodCat)
        {
            Pedido pedido = new Pedido();

            for (int i = 0; i < pedido.ListarCategoriaPorProd(CodCat).Count; i++)
            {
                Console.WriteLine(pedido.ListarCategoriaPorProd(CodCat)[i]);
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

        static void NovoPedido()
        {
            Pedido novoPedido = new Pedido();
            Produto calcProduto = new Produto();
            DataTable DtNovoPedido = new DataTable();
            int ID_Cat = 0, ID_Prod = 0, QTD = 0, ID_IA = 0, QTD_IA = 0, val = 0;
            string OBS = string.Empty;
            decimal Preco = 0, valorTotal = 0;

            #region Colunas do DataTable DtNovoPedido
            DtNovoPedido.Columns.Add("ID_Cat", typeof(int));
            DtNovoPedido.Columns.Add("ID_Prod", typeof(int));
            DtNovoPedido.Columns.Add("QTD", typeof(int));
            DtNovoPedido.Columns.Add("ID_IA", typeof(int));
            DtNovoPedido.Columns.Add("QTD_IA", typeof(int));
            DtNovoPedido.Columns.Add("OBS", typeof(string));
            DtNovoPedido.Columns.Add("Preco", typeof(decimal));
            #endregion

            #region laço do while
            do
            {   
                Console.Write("Digite o codigo para categoria: ");
                ID_Cat = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite o codigo do produto: ");
                ID_Prod = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite a quantidade do produto: ");
                QTD = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite o codigo para item adicional: ");
                ID_IA = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite a quantidade do item adicional: ");
                QTD_IA = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite uma observação se houver: ");
                OBS = Console.ReadLine();
                Console.Write("\n");


                Preco = calcProduto.calcularPrecoDoProduto(ID_Prod, QTD, ID_IA, QTD_IA);
                

                DtNovoPedido.Rows.Add(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, OBS, Preco);

                Console.Write("Deseja continuar a adicionar pedido? digitar qualquer valor para sim e (zero) 0 para não: ");
                val = Convert.ToInt32(Console.ReadLine());

            } while (val != 0);
            #endregion


            for (int i = 0; i < DtNovoPedido.Rows.Count; i++)
            {
                Console.WriteLine(DtNovoPedido.Rows[i][0] +" "+ DtNovoPedido.Rows[i][1] +" "+ DtNovoPedido.Rows[i][2] +" "+ DtNovoPedido.Rows[i][3] +" "+ DtNovoPedido.Rows[i][4] +" "+ DtNovoPedido.Rows[i][5] +" "+ DtNovoPedido.Rows[i][6]);

                valorTotal += Convert.ToDecimal(DtNovoPedido.Rows[i][6]);
            }

            Console.WriteLine("\nValor total do pedido é: " + valorTotal);

            novoPedido.NovoPedido();

            for (int i = 0; i < DtNovoPedido.Rows.Count; i++)
            {
                novoPedido.AdicionarItens(Convert.ToInt32(DtNovoPedido.Rows[i][0]), Convert.ToInt32(DtNovoPedido.Rows[i][1]), Convert.ToInt32(DtNovoPedido.Rows[i][2]), Convert.ToInt32(DtNovoPedido.Rows[i][3]), Convert.ToInt32(DtNovoPedido.Rows[i][4]), DtNovoPedido.Rows[i][5].ToString(), Convert.ToDecimal(DtNovoPedido.Rows[i][6]));
            }
        }
                
        static void AcrecentarItemEmUmPedido()
        {
            Pedido acrecentar = new Pedido();
            Produto recaucular = new Produto();
            DataTable acrecentarItem = new DataTable();
            int ID_Cat = 0, ID_Prod = 0, QTD = 0, ID_IA = 0, QTD_IA = 0, val = 0, IdPedido = 0;
            string OBS = string.Empty;
            decimal Preco = 0, valorTotal = 0;

            Console.Write("Digite o numero do pedido que deseja acrecentar: ");
            acrecentar.IdPedido = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            acrecentarItem = acrecentar.listarItensDeUmPedido();

            do
            {
                Console.Write("Digite o codigo para categoria: ");
                ID_Cat = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite o codigo do produto: ");
                ID_Prod = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite a quantidade do produto: ");
                QTD = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite o codigo para item adicional: ");
                ID_IA = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite a quantidade do item adicional: ");
                QTD_IA = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Digite uma observação se houver: ");
                OBS = Console.ReadLine();
                Console.Write("\n");

                Preco = recaucular.calcularPrecoDoProduto(ID_Prod, QTD, ID_IA, QTD_IA);

                acrecentarItem.Rows.Add(ID_Cat, ID_Prod, QTD, ID_IA, QTD_IA, OBS, Preco, IdPedido);

                Console.Write("Deseja continuar a adicionar pedido? digitar qualquer valor para sim e (zero) 0 para não: ");
                val = Convert.ToInt32(Console.ReadLine());

            } while (val != 0);

            int qtdacrecentarItem = 0;
            DataRow drow;

            //qtdacrecentarItem = acrecentar.listarItensDeUmPedido().Rows.Count - acrecentarItem.Rows.Count;
            qtdacrecentarItem = acrecentarItem.Rows.Count - acrecentar.listarItensDeUmPedido().Rows.Count;


            for (int i = 0; i <= qtdacrecentarItem; i++)
            {
                if (i != 0)
                {
                    drow = acrecentarItem.Rows[acrecentarItem.Rows.Count - i];
                    //acrecentar.AdicionarItens();
                    acrecentar.AdicionarItens(drow.ItemArray[0],drow.ItemArray[1],drow.ItemArray[2],drow.ItemArray[3],drow.ItemArray[4],drow.ItemArray[5],drow.ItemArray[6],drow.ItemArray[7],);
                }
            }

            for (int i = 0; i < Convert.ToInt32(acrecentarItem.Rows.Count); i++)
            {
                valorTotal += recaucular.calcularPrecoDoProduto(Convert.ToInt32(acrecentarItem.Rows[i][1]), Convert.ToInt32(acrecentarItem.Rows[i][2]), Convert.ToInt32(acrecentarItem.Rows[i][3]), Convert.ToInt32(acrecentarItem.Rows[i][4]));
            }
            Console.WriteLine(valorTotal);
        }

        static void MENU(int num)
        {
            switch (num)
            {
                case 1: AbrirCaixa();
                    break;

                case 2: verUltimosRegistrosAbrirCAixa();
                    break;

                case 3:
                    Console.Write("Digite o codigo da categoria: ");
                    ListarCategoriaPorProd(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 4: ExibirCategoriaPorProd();
                    break;

                case 5: NovoPedido();
                    break;

                case 6: AcrecentarItemEmUmPedido();
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9: Console.Clear();
                    break;

                default:
                    break;
            }

            Console.WriteLine();
        }

    }//classe program
}//Namespace
