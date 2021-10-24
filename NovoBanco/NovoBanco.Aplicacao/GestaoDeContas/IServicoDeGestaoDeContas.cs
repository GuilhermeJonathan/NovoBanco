using NovoBanco.Aplicacao.GestaoDeContas.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.GestaoDeContas
{
    public interface IServicoDeGestaoDeContas
    {
        IList<ModeloDeContaBancariaDaLista> ListarTodasContas();
        Task<BaseModel<ModeloDeContaBancariaDaLista>> CadastrarConta(ModeloDeCadastroDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> EditarConta(ModeloDeEdicaoDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> AtivarDesativarConta(ModeloDeEdicaoDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> ExcluirConta(ModeloDeEdicaoDeContaBancaria modelo);
    }
}
