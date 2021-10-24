using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos
{
    public class ModeloDeEdicaoDeContaBancaria
    {
        public ModeloDeEdicaoDeContaBancaria()
        {
            this.Bancos = new List<SelectListItem>();
        }

        public ModeloDeEdicaoDeContaBancaria(ContaBancaria conta)
        {
            if (conta == null)
                return;

            Id = conta.Id;
            Nome = conta.Nome;
            Documento = conta.Documento;
            Agencia = conta.Agencia;
            Conta = conta.Conta;
            BancoId = conta.BancoId;            
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        public string Agencia { get; set; }
        [Required]
        public string Conta { get; set; }
        [Required]
        public int BancoId { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }
        public int Ativo { get; set; }
    }
}
