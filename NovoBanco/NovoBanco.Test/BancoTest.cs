using Microsoft.Extensions.DependencyInjection;
using NovoBanco.Aplicacao.GestaoDeContas;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NovoBanco.Test
{
    public class BancoTest
    {
        private ContaBancaria novaConta = ContaBancaria.Construir.ComId(1).Ativo()
                .ComNome("Teste").ComDocumento("02025032161")
                .ComAgencia("1020").ComConta("3020").ComBanco(1);

        private Banco novoBanco = Banco.Construir.ComId(1).Ativo()
                .ComNome("BRB").ComCodigo("070");

        [Fact(DisplayName = "Ativar e Inativar Contas")]
        [Trait("CRUD", "Conta")]
        public void AtivarInativarConta()
        {
            novaConta.Ativar();
            novaConta.Inativar();
        }

        [Fact(DisplayName = "Alterar Conta")]
        [Trait("CRUD", "Conta")]
        public void AlterarConta()
        {
            novaConta.AlterarDadosConta(novoBanco, "Novo nome", "12345612312", "1010", "2020");
        }
    }
}
