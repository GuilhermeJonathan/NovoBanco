using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Dtos
{
    public class ContaBancariaAtivacaoDto
    {
        /// <summary>
        /// Id do Cliente {int}
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// Ativar Cliente {int} 1: Ativo / 0: Inativo
        /// </summary>
        [Required]
        public int Ativo { get; set; }
    }
}
