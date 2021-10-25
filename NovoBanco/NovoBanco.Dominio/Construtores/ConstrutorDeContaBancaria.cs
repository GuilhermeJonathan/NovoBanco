using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Construtores
{
    public class ConstrutorDeContaBancaria
    {
        private int _id;
        private string _nome;
        private string _documento;
        private string _conta;
        private string _agencia;
        private bool _ativo;
        private int _bancoId;

        internal ConstrutorDeContaBancaria()
        {
        }

        public ConstrutorDeContaBancaria ComId(int id)
        {
            this._id = id;
            return this;
        }

        public ConstrutorDeContaBancaria Ativo(bool ativo = true)
        {
            this._ativo = ativo;
            return this;
        }

        public ConstrutorDeContaBancaria ComNome(string nome)
        {
            this._nome = nome;
            return this;
        }

        public ConstrutorDeContaBancaria ComDocumento(string documento)
        {
            this._documento = documento;
            return this;
        }

        public ConstrutorDeContaBancaria ComConta(string conta)
        {
            this._conta = conta;
            return this;
        }

        public ConstrutorDeContaBancaria ComAgencia(string agencia)
        {
            this._agencia = agencia;
            return this;
        }

        public ConstrutorDeContaBancaria ComBanco(int banco)
        {
            this._bancoId = banco;
            return this;
        }

        public static implicit operator ContaBancaria(ConstrutorDeContaBancaria construtor)
        {
            return new ContaBancaria(construtor._nome, construtor._documento, 
                construtor._agencia, construtor._conta, construtor._bancoId);
        }
    }
}
