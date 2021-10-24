using NovoBanco.Aplicacao.GestaoDeContas.Modelos;
using NovoBanco.Aplicacao.Util;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Dominio.ObjetosDeValor;
using NovoBanco.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoBanco.Aplicacao.GestaoDeContas
{
    public class ServicoDeGestaoDeContas : IServicoDeGestaoDeContas
    {
        private readonly IServicoExternoDePersistencia _servicoExternoDePersistencia;

        public ServicoDeGestaoDeContas(IServicoExternoDePersistencia servicoExternoDePersistencia)
        {
            this._servicoExternoDePersistencia = servicoExternoDePersistencia;
        }

        public IList<ModeloDeContaBancariaDaLista> ListarTodasContas()
        {
            var contas = this._servicoExternoDePersistencia.RepositorioDeContas.ListarTodasContas();
            var modelo = new List<ModeloDeContaBancariaDaLista>();

            contas.ToList().ForEach(a => modelo.Add(new ModeloDeContaBancariaDaLista(a)));
            return modelo;
        }

        public async Task<BaseModel<ModeloDeContaBancariaDaLista>> CadastrarConta(ModeloDeCadastroDeContaBancaria modelo)
        {
            try
            {
                var resultadoValidacao = modelo.ValidarPropriedades();
                if (resultadoValidacao.Any())
                    return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.DadosInvalidos, dados: null, resultadoValidacao: resultadoValidacao.ToArray());

                var banco = this._servicoExternoDePersistencia.RepositorioDeBancos.PegarPorId(modelo.IdBanco);
                var novaConta = new ContaBancaria(modelo.Nome, modelo.Documento, modelo.Agencia, modelo.Conta, banco);
                        
                await this._servicoExternoDePersistencia.RepositorioDeContas.Inserir(novaConta);
                this._servicoExternoDePersistencia.Persistir();
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: true, mensagem: EnumMensagens.RealizadaComSucesso, dados: new ModeloDeContaBancariaDaLista(novaConta));
            } catch(Exception ex)
            {
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.ErroInterno);
            }
        }

        public BaseModel<ModeloDeContaBancariaDaLista> EditarConta(ModeloDeEdicaoDeContaBancaria modelo)
        {
            try
            {
                var resultadoValidacao = modelo.ValidarPropriedades();
                if (resultadoValidacao.Any())
                    return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.DadosInvalidos, dados: null, resultadoValidacao: resultadoValidacao.ToArray());

                var banco = this._servicoExternoDePersistencia.RepositorioDeBancos.PegarPorId(modelo.IdBanco);
                var conta = this._servicoExternoDePersistencia.RepositorioDeContas.BuscarPorId(modelo.Id);

                if(conta == null)
                    return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.DadosNaoEncontrados);

                conta.AlterarDadosConta(banco, modelo.Nome, modelo.Documento, modelo.Agencia, modelo.Conta);
                this._servicoExternoDePersistencia.Persistir();
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: true, mensagem: EnumMensagens.RealizadaComSucesso, dados: new ModeloDeContaBancariaDaLista(conta));
            }
            catch (Exception ex)
            {
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.ErroInterno);
            }
        }

        public BaseModel<ModeloDeContaBancariaDaLista> AtivarDesativarConta(ModeloDeEdicaoDeContaBancaria modelo)
        {
            try
            {
                var conta = this._servicoExternoDePersistencia.RepositorioDeContas.BuscarPorId(modelo.Id);

                if (conta == null)
                    return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.DadosNaoEncontrados);

                if (modelo.Ativo == 0)
                    conta.Inativar();
                else
                    conta.Ativar();

                this._servicoExternoDePersistencia.Persistir();
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: true, mensagem: EnumMensagens.RealizadaComSucesso, dados: new ModeloDeContaBancariaDaLista(conta));
            }
            catch (Exception ex)
            {
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.ErroInterno);
            }
        }

        public BaseModel<ModeloDeContaBancariaDaLista> ExcluirConta(ModeloDeEdicaoDeContaBancaria modelo)
        {
            try
            {
                var conta = this._servicoExternoDePersistencia.RepositorioDeContas.BuscarPorId(modelo.Id);

                if (conta == null)
                    return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.DadosNaoEncontrados);
                
                this._servicoExternoDePersistencia.RepositorioDeContas.Deletar(conta);
                this._servicoExternoDePersistencia.Persistir();
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: true, mensagem: EnumMensagens.RealizadaComSucesso, dados: new ModeloDeContaBancariaDaLista(conta));
            }
            catch (Exception ex)
            {
                return new BaseModel<ModeloDeContaBancariaDaLista>(sucesso: false, mensagem: EnumMensagens.ErroInterno);
            }
        }
    }
}