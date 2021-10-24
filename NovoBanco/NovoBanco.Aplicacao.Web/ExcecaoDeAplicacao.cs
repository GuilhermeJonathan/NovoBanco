using System;

namespace NovoBanco.Aplicacao.Web
{
    public class ExcecaoDeAplicacao : Exception
    {
        public ExcecaoDeAplicacao(string message) : base(message)
        {
        }
    }
}
