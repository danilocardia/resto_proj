using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class Reposicao
    {
        public string Descricao { get; set; }
        public decimal valor { get; set; }
        public void ReporDinheiro()
        {
            var repor = new DAO_Reposicao();

            repor.NovoReposicao(Descricao, valor, DateTime.Now.Date);
        }
    }
}
