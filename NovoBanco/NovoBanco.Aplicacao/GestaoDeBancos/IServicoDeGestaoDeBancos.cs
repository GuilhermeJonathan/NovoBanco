using NovoBanco.Aplicacao.GestaoDeBancos.Modelos;
using NovoBanco.Aplicacao.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Aplicacao.GestaoDeBancos
{
    public interface IServicoDeGestaoDeBancos
    {
        BaseModel<List<ModeloDeBancoDaLista>> ListarTodosBancos();
    }
}
