using NovoBanco.Aplicacao.GestaoDeBancos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeBancos
{
    public interface IServicoDeGestaoDeBancos
    {
        IList<ModeloDeBancoDaLista> ListarTodosBancos();
    }
}
