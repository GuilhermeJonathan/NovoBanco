using NovoBanco.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Infraestrutura
{
    public interface IServicoExternoDePersistencia
    {
        IBancoRepository RepositorioDeBancos { get; }
    }
}
