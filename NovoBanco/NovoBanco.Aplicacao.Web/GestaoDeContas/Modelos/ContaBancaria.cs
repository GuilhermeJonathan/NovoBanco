using NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.Web.GestaoDeContas.Modelos
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Documento { get; set; }
        public string Situacao { get; set; }
        public string CodigoBanco { get; set; }
        public string DataAbertura { get; set; }
        public int BancoId { get; set; }
    }
}
