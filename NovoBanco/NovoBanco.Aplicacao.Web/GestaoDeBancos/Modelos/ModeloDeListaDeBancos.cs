using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos
{
    public class ModeloDeListaDeBancos
    {
        public ModeloDeListaDeBancos()
        {
            this.Lista = new List<ModeloDeBancoDaLista>();
        }

        public ModeloDeListaDeBancos(IEnumerable<Banco> lista, int totalDeRegistros) : this()
        {
            if (lista == null)
                return;

            this.TotalDeRegistros = totalDeRegistros;
            lista.ToList().ForEach(a => this.Lista.Add(new ModeloDeBancoDaLista(a)));
        }

        public List<ModeloDeBancoDaLista> Lista { get; set; }
        public int TotalDeRegistros { get; set; }
    }
}
