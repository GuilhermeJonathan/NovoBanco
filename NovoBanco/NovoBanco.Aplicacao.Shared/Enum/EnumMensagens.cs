using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NovoBanco.Aplicacao.Shared
{
    public enum EnumMensagens
    {
        [Description("Operação realizada com sucesso.")]
        RealizadaComSucesso = 1,

        [Description("Dados Inválidos.")]
        DadosInvalidos = 2,

        [Description("Ocorreu um erro não identificado na aplicação.")]
        ErroInterno = 3,

        [Description("Dados não encontrados.")]
        DadosNaoEncontrados = 4

    }
}
