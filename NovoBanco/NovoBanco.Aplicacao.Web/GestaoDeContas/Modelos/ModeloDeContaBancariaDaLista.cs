using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos
{
    public class ModeloDeContaBancariaDaLista
    {
        public ModeloDeContaBancariaDaLista(ContaBancaria conta)
        {
            if (conta == null)
                return;

            this.Id = conta.Id;
            this.Nome = conta.Nome;
            this.Agencia = conta.Agencia;
            this.Conta = conta.Conta;
            this.DataAbertura = conta.DataAbertura;
            this.CodigoBanco = conta.CodigoBanco;
            this.Situacao = conta.Situacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string DataAbertura { get; set; }
        public string Situacao { get; set; }
        public bool Ativo => this.Situacao.ToUpper() == "ATIVO" ? true : false;
    }
}
