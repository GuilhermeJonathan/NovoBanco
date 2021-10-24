using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NovoBanco.Dominio.Entidades
{
    public class Banco : Entidade
    {
        public Banco()
        {
            this.Ativo = true;
        }

        public Banco(string codigo, string nome) : this()
        {
            Codigo = codigo;
            Nome = nome;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}
