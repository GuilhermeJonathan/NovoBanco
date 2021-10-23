using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio.Entidades
{
    public class Banco : Entidade
    {
        public Banco()
        {
            this.Ativo = true;
        }

        public Banco(int id, string codigo, string nome) : this()
        {
            this.Id = id;
            Codigo = codigo;
            Nome = nome;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}
