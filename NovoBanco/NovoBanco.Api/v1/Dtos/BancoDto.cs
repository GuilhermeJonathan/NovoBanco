using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Dtos
{
    public class BancoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
