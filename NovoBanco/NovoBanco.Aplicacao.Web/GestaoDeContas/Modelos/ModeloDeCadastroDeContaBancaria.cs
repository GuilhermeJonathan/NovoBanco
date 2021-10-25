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

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Documento é obrigatório")]
        [StringLength(15)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Somente números")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Agência é obrigatória")]
        [StringLength(10)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Somente números")]
        public string Agencia { get; set; }
        [Required(ErrorMessage = "Conta é obrigatória")]
        [StringLength(10)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Somente números")]
        public string Conta { get; set; }
        [Required(ErrorMessage = "Banco é obrigatório")]
        public int BancoId { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }
    }
}
