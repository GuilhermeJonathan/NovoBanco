using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NovoBanco.Dominio.Entidades
{
    public class ContaBancaria : Entidade
    {
        public ContaBancaria()
        {
            this.Ativo = true;
            this.DataAbertura = DateTime.Now;
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
            BancoId = banco.Id;
            Documento = documento;
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataUltimaAtualizacao { get; private set; }
        public int BancoId { get; set; }
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

        public void AlterarDadosConta(Banco banco, string nome, string documento, string agencia, string conta)
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

            this.BancoId = banco.Id;
            this.Nome = nome;
            this.Documento = documento;
            this.Conta = conta;
            this.Agencia = agencia;
            this.Atualizar();
        }
    }
}
