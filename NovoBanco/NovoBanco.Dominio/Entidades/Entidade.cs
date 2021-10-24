using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Dominio.Entidades
{
    public abstract class Entidade
    {
        public Entidade()
        {
            this.DataDoCadastro = DateTime.Now;
        }

        [Key]
        public int Id { get; protected set; }
        public DateTime DataDoCadastro { get; set; }
    }
}
