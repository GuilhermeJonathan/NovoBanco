using NovoBanco.Aplicacao.Web.GestaoDeBancos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.Web.GestaoDeBancos
{
    public interface IServicoDeGestaoDeBancos
    {
        Task<List<ModeloDeBancoDaLista>> BuscarBancos();
        Task<ModeloDeListaDeBancos> BuscarListaDeBancos();
    }
}
