using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Dtos
{
    public class ContaBancariaDto
    {
        /// <summary>
        /// Identificador da Fruta
        /// </summary> 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBanco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Situacao { get; set; }
    }
}
