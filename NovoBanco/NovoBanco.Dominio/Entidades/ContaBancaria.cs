using NovoBanco.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NovoBanco.Dominio.Entidades
{
    public class ContaBancaria : Entidade
    {
        public ContaBancaria()
        {
            this.Ativo = true;
        }

        public ContaBancaria(string nome, string documento, string agencia, string conta, Banco banco) : this()
        {
            if (banco == null)
                throw new ExcecaoDeNegocio("Obrigatório informar um banco");

            if (string.IsNullOrEmpty(nome))
                throw new ExcecaoDeNegocio("Obrigatório informar um nome");

            if (string.IsNullOrEmpty(documento))
                throw new ExcecaoDeNegocio("Obrigatório informar um documento");

            if (string.IsNullOrEmpty(agencia))
                throw new ExcecaoDeNegocio("Obrigatório informar uma agência");

            if (string.IsNullOrEmpty(conta))
                throw new ExcecaoDeNegocio("Obrigatório informar uma conta");

            Nome = nome;
            Agencia = agencia;
            Conta = conta;
            Banco = banco;
            Documento = documento;
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataUltimaAtualizacao { get; private set; }
        [ForeignKey("BancoId")]
        public Banco Banco { get; set; }

        public void Ativar()
        {
            this.Ativo = true;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }

        public void Atualizar()
        {
            this.DataUltimaAtualizacao = DateTime.Now;
        }

        public void AlterarDadosConta(Banco banco, string nome, string documento, string agencia, string conta, bool ativo)
        {
            this.Nome = nome;
            if (banco == null)
                throw new ExcecaoDeNegocio("Obrigatório informar um banco");

            if (string.IsNullOrEmpty(nome))
                throw new ExcecaoDeNegocio("Obrigatório informar um nome");

            if (string.IsNullOrEmpty(documento))
                throw new ExcecaoDeNegocio("Obrigatório informar um documento");

            if (string.IsNullOrEmpty(agencia))
                throw new ExcecaoDeNegocio("Obrigatório informar uma agência");

            if (string.IsNullOrEmpty(conta))
                throw new ExcecaoDeNegocio("Obrigatório informar uma conta");

            this.Banco = banco;
            this.Nome = nome;
            this.Documento = documento;
            this.Conta = conta;
            this.Agencia = agencia;
            this.Ativo = ativo;
            this.Atualizar();
        }
    }
}
