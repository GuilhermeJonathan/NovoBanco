using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeContas.Modelos
{
    public class ModeloDeEdicaoDeContaBancaria
    {
        public ModeloDeEdicaoDeContaBancaria()
        {

        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Documento { get; private set; }
        [Required]
        public string Agencia { get; private set; }
        [Required]
        public string Conta { get; private set; }
        [Required]
        public int IdBanco { get; set; }
        public int Ativo { get; set; }
    }
}
