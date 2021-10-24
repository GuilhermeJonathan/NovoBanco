using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Dtos
{
    public class ContaBancariaEdicaoDto
    {
        /// <summary>
        /// Id do Cliente {int}
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Cliente {string}
        /// </summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>
        /// CPF ou CNPJ do Cliente {string}
        /// </summary>
        [Required]
        public string Documento { get; set; }
        /// <summary>
        /// Agência do Cliente {string}
        /// </summary>

        [Required]
        public string Agencia { get; set; }
        /// <summary>
        /// Nome do Cliente {string}
        /// </summary>
        [Required]
        public string Conta { get; set; }
        /// <summary>
        /// Id do Banco {int}
        /// </summary>
        [Required]
        public int IdBanco { get; set; }
    }
}
