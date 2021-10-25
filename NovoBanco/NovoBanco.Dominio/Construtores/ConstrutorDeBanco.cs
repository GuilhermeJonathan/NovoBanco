using NovoBanco.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Construtores
{
    public class ConstrutorDeBanco
    {
        private int _id;
        private string _nome;
        private string _codigo;
        private bool _ativo;

        internal ConstrutorDeBanco()
        {
        }

        public ConstrutorDeBanco ComId(int id)
        {
            this._id = id;
            return this;
        }

        public ConstrutorDeBanco Ativo(bool ativo = true)
        {
            this._ativo = ativo;
            return this;
        }

        public ConstrutorDeBanco ComNome(string nome)
        {
            this._nome = nome;
            return this;
        }

        public ConstrutorDeBanco ComCodigo(string codigo)
        {
            this._codigo = codigo;
            return this;
        }

        public static implicit operator Banco(ConstrutorDeBanco construtor)
        {
            return new Banco(construtor._codigo, construtor._nome);
        }
    }
}
