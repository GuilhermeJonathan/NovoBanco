using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos
{
    public class ModeloDeCadastroDeContaBancaria
    {
        public ModeloDeCadastroDeContaBancaria()
        {
            this.Bancos = new List<SelectListItem>();
        }

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
    }
}
