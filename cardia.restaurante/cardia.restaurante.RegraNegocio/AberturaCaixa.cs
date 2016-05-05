using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cardia.restaurante.DAO;
using System.Data;

namespace cardia.restaurante.RegraNegocio
{
    public class AberturaCaixa
    {
        public decimal valor { get; set; }
        public int setor { get; set; }
        public string retornar { get; set; }

        public void VerificarCAixa()
        {
            DAO_AberturaCaixa abrirCAixa = new DAO_AberturaCaixa();
            DataTable DT = new DataTable(); //Recebe a tabela abertura de Caixa
            DataTable DT_PorData = new DataTable();// Recebe innerJoin Tabela AberturaCaixa com Departamento.
            DateTime data = DateTime.Now.Date;//Recebe a data atual.
            DateTime dataTabela, dataTabela2;// dataTabela recebe a data do ultimo registro, dataTabela2 recebe a data do penultimo registro
            DataRow dRow, dRow2;// dRow recebe ultima tupla e o dRow2 recebe penultima tupla.

            DT = abrirCAixa.ListarAberturaCaixa();
            DT_PorData = abrirCAixa.ListarAberturaCaixaPorDepartamento();

            try
            {
                dRow = DT.Rows[DT.Rows.Count - 1]; //Ultima tupla
                dRow2 = DT.Rows[DT.Rows.Count - 2];//Penultima tupla

                dataTabela = Convert.ToDateTime(dRow.ItemArray[3]);
                dataTabela2 = Convert.ToDateTime(dRow2.ItemArray[3]);

                if (DT.Rows.Count > 1)
                {

                    if (dataTabela2.ToString("dd/MM/yyyy") != data.ToString("dd/MM/yyyy") || dataTabela.ToString("dd/MM/yyyy") != data.ToString("dd/MM/yyyy"))//Convert.ToInt32(dRow.ItemArray[1]) == 1
                    {
                        if (Convert.ToInt32(dRow.ItemArray[1]) == 1 && setor == 1)
                        {
                            abrirCAixa.NovoAberturaCaixa(setor, valor, data);
                            retornar = "Abertura de caixa para motoboy realizado com sucesso\n";
                        }
                        else
                        {
                            abrirCAixa.NovoAberturaCaixa(setor, valor, data);
                            retornar = "Abertura de caixa para balcão realizado com sucesso\n";
                        }
                    }
                    else
                        retornar = "Já foi realizado abertura de caixa para Balcão e motoboy.\n";
                }
            }
            catch
            {
                abrirCAixa.NovoAberturaCaixa(setor, valor, data);
                if (setor == 1)
                {
                    retornar = "Abertura de caixa para balcão realizado com sucesso\n";
                }
                else
                {
                    retornar = "Abertura de caixa para motoboy realizado com sucesso\n";
                }
            }

        }

        public bool verificarRegistroBalcao()
        {
            bool retornar = false;
            int aux = 0;
            DAO_AberturaCaixa verificar = new DAO_AberturaCaixa();
            DateTime data = DateTime.Now.Date;
            DataTable Dt = new DataTable();
            DateTime tabela1;
            string tabela2, dataAtual;
            DataRow dRow1;

            Dt = verificar.ListarAberturaCaixa();

            if (Dt.Rows.Count > 0)
            {
                dRow1 = Dt.Rows[Dt.Rows.Count - 1]; //Ultima tupla

                tabela1 = Convert.ToDateTime(dRow1.ItemArray[3]);

                tabela2 = tabela1.ToString("dd/MM/yyyy");
                dataAtual = data.ToString("dd/MM/yyyy");
                aux = Convert.ToInt32(dRow1.ItemArray[1]);

                if (tabela2 == dataAtual)
                {
                    if (aux == 1)
                    {
                        retornar = true;
                    }
                }
            }
            return retornar;
        }

        public bool verificarRegistroMotoboy()
        {
            bool retornar = false;
            int aux = 0;
            DAO_AberturaCaixa verificar = new DAO_AberturaCaixa();
            DateTime data = DateTime.Now.Date;
            DataTable Dt = new DataTable();
            DateTime tabela1;
            string tabela2, dataAtual;
            DataRow dRow1;

            Dt = verificar.ListarAberturaCaixa();

            if (Dt.Rows.Count > 0)
            {
                dRow1 = Dt.Rows[Dt.Rows.Count - 1]; //Ultima tupla

                tabela1 = Convert.ToDateTime(dRow1.ItemArray[3]);

                tabela2 = tabela1.ToString("dd/MM/yyyy");
                dataAtual = data.ToString("dd/MM/yyyy");
                aux = Convert.ToInt32(dRow1.ItemArray[1]);

                if (dataAtual == tabela2)
                {
                    if (aux == 2)
                    {
                        retornar = true;
                    }
                }
            }
            return retornar;
        }

        public DataTable ListarRegistrodeHoje()
        {
            DAO_AberturaCaixa listarRegistro = new DAO_AberturaCaixa();
            DataTable DT_PorData = new DataTable();
            DataTable DT_Retornar = new DataTable();
            DateTime dataHoje = DateTime.Now.Date;
            DateTime dataTabela, dataTabela2;// dataTabela recebe a data do ultimo registro, dataTabela2 recebe a data do penultimo registro
            DataRow dRow, dRow2;// dRow recebe ultima tupla e o dRow2 recebe penultima tupla.


            DT_PorData = listarRegistro.ListarAberturaCaixaPorDepartamento();

            dRow = DT_PorData.Rows[DT_PorData.Rows.Count - 1]; //Ultima Tupla
            dRow2 = DT_PorData.Rows[DT_PorData.Rows.Count - 2]; //Penultima Tupla

            dataTabela = Convert.ToDateTime(dRow.ItemArray[3]);
            dataTabela2 = Convert.ToDateTime(dRow2.ItemArray[3]);

            DT_Retornar.Columns.Add("Nome", typeof(string));
            DT_Retornar.Columns.Add("ID", typeof(int));
            DT_Retornar.Columns.Add("Valor", typeof(decimal));
            DT_Retornar.Columns.Add("Data", typeof(string));

            DT_Retornar.Rows.Add(dRow.ItemArray[0], dRow.ItemArray[1], dRow.ItemArray[2], Convert.ToDateTime(dRow.ItemArray[3]).ToString("dd/MM/yyyy"));
            DT_Retornar.Rows.Add(dRow2.ItemArray[0], dRow2.ItemArray[1], dRow2.ItemArray[2], Convert.ToDateTime(dRow2.ItemArray[3]).ToString("dd/MM/yyyy"));

            return DT_Retornar;
        }
    }
}
