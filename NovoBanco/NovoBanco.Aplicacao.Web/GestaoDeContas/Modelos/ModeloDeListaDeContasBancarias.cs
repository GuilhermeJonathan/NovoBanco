using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos
{
    public class ModeloDeListaDeContasBancarias
    {
        public ModeloDeListaDeContasBancarias()
        {
            this.Filtro = new ModeloDeFiltroDeContasBancarias();
            this.Lista = new List<ModeloDeContaBancariaDaLista>();
        }

        public ModeloDeListaDeContasBancarias(IEnumerable<ContaBancaria> lista, int totalDeRegistros, ModeloDeFiltroDeContasBancarias filtro = null) : this()
        {
            if (lista == null)
                return;

            if (filtro != null)
                this.Filtro = filtro;

            this.TotalDeRegistros = totalDeRegistros;
            lista.ToList().ForEach(a => this.Lista.Add(new ModeloDeContaBancariaDaLista(a)));
        }

        public ModeloDeFiltroDeContasBancarias Filtro { get; set; }
        public List<ModeloDeContaBancariaDaLista> Lista { get; set; }
        public int TotalDeRegistros { get; set; }
    }
}
