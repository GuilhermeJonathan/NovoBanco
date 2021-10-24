using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Dtos
{
    public class ContaBancariaExclusaoDto
    {
        /// <summary>
        /// Id do Cliente {int}
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
    }
}
