using AutoMapper;
using NovoBanco.Api.v1.Dtos;
using NovoBanco.Aplicacao.GestaoDeBancos.Modelos;
using NovoBanco.Aplicacao.GestaoDeContas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoBanco.Api.v1.Profiles
{
    public class BancoProfile : Profile
    {
        public BancoProfile()
        {
            CreateMap<ModeloDeContaBancariaDaLista, ContaBancariaDto>().ReverseMap();
            CreateMap<ModeloDeCadastroDeContaBancaria, ContaBancariaRegistroDto>().ReverseMap();
            CreateMap<ModeloDeEdicaoDeContaBancaria, ContaBancariaEdicaoDto>().ReverseMap();
            CreateMap<ModeloDeEdicaoDeContaBancaria, ContaBancariaExclusaoDto>().ReverseMap();
            CreateMap<ModeloDeEdicaoDeContaBancaria, ContaBancariaAtivacaoDto>().ReverseMap();
            
            CreateMap<ModeloDeBancoDaLista, BancoDto>()
                .ForMember(dest => dest.Nome, opts => opts.MapFrom(src => $"{src.Codigo} - {src.Nome}"))
                .ReverseMap();
        }
    }
}
