using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Dominio
{
    [Serializable]
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio() { }
        public ExcecaoDeNegocio(string message) : base(message) { }
    }
}
