using NovoBanco.Aplicacao.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovoBanco.Aplicacao.Shared
{
    public class BaseModel<T>
    {
        public BaseModel()
        {

        }

        public BaseModel(bool sucesso, EnumMensagens mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = new EnumModel
            {
                Codigo = mensagem.GetEnumValue(),
                Nome = mensagem.GetEnumName(),
                Descricao = mensagem.GetEnumDescription()
            };
        }

        public BaseModel(bool sucesso, EnumMensagens mensagem, T dados) : this(sucesso, mensagem) => this.Dados = dados;
        public BaseModel(bool sucesso, EnumMensagens mensagem, T dados, ValidationResult[] resultadoValidacao) : this(sucesso, mensagem, dados) => this.ResultadoValidacao = resultadoValidacao;

        public bool Sucesso { get; set; }
        public EnumModel Mensagem { get; set; }
        public ValidationResult[] ResultadoValidacao { get; set; }
        public T Dados { get; set; }
    }
}
