using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeContas.Modelos
{
    public class ModeloDeContaBancariaDaLista
    {
        public ModeloDeContaBancariaDaLista()
        {

        }

        public ModeloDeContaBancariaDaLista(ContaBancaria conta)
        {
            if (conta == null)
                return;

            this.Id = conta.Id;
            this.Nome = conta.Nome;
            this.Agencia = conta.Agencia;
            this.Conta = conta.Conta;
            this.DataAbertura = conta.DataAbertura != null ? conta.DataAbertura.Value.ToShortDateString() : String.Empty;
            this.NomeBanco = conta.Banco != null ? conta.Banco.Nome : String.Empty;
            this.CodigoBanco = conta.Banco != null ? conta.Banco.Codigo : String.Empty;
            this.Situacao = conta.Ativo ? "Ativo" : "Inativo";
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string DataAbertura { get; set; }
        public string Situacao { get; set; }
    }
}
