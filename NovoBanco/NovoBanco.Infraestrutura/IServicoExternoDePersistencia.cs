using NovoBanco.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Infraestrutura
{
    public interface IServicoExternoDePersistencia
    {
        void Persistir();
        void Dispose();
        IBancoRepository RepositorioDeBancos { get; }
        IContaBancariaRepository RepositorioDeContas { get; }
    }
}
