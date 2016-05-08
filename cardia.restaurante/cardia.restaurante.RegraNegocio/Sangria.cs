using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardia.restaurante.RegraNegocio
{
    public class Sangria
    {
        public string descricao { get; set; }
        public decimal valor { get; set; }

        public void RetirarDinehiro()
        {
            var retirar = new DAO_Sangria();

            retirar.NovoSangria(descricao,valor,DateTime.Now.Date);
        }
    }
}
