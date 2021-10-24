using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos
{
    public class ModeloDeBancoDaLista
    {
        public ModeloDeBancoDaLista(Banco banco)
        {
            if (banco == null)
                return;

            this.Id = banco.Id;
            this.Nome = banco.Nome;
            this.Codigo = banco.Codigo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
