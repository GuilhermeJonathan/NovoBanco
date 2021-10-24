using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeContas.Modelos
{
    public class ModeloDeCadastroDeContaBancaria
    {
        public ModeloDeCadastroDeContaBancaria()
        {

        }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Documento { get; private set; }
        [Required]
        public string Agencia { get; private set; }
        [Required]
        public string Conta { get; private set; }
        [Required]
        public int BancoId { get; set; }
    }
}
