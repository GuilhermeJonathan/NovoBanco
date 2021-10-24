using NovoBanco.Aplicacao.GestaoDeContas.Modelos;
using NovoBanco.Aplicacao.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.GestaoDeContas
{
    public interface IServicoDeGestaoDeContas
    {
        BaseModel<List<ModeloDeContaBancariaDaLista>> ListarTodasContas();
        BaseModel<List<ModeloDeContaBancariaDaLista>> BuscarPorNome(string nome);
        BaseModel<ModeloDeContaBancariaDaLista> BuscarPorId(int id);
        Task<BaseModel<ModeloDeContaBancariaDaLista>> CadastrarConta(ModeloDeCadastroDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> EditarConta(ModeloDeEdicaoDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> AtivarDesativarConta(ModeloDeEdicaoDeContaBancaria modelo);
        BaseModel<ModeloDeContaBancariaDaLista> ExcluirConta(ModeloDeEdicaoDeContaBancaria modelo);
    }
}
