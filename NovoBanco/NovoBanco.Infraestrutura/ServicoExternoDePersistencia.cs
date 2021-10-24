using NovoBanco.Dominio.Repositories;
using NovoBanco.Infraestrutura.Context;
using NovoBanco.Infraestrutura.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovoBanco.Infraestrutura
{
    public class ServicoExternoDePersistencia : IServicoExternoDePersistencia
    {
        private readonly AppDbContext _contexto;

        public ServicoExternoDePersistencia(AppDbContext contexto)
        {
            this._contexto = contexto;
        }

        public IBancoRepository RepositorioDeBancos
        {
            get
            {
                return new BancoRepository(this._contexto);
            }
        }

        public IContaBancariaRepository RepositorioDeContas
        {
            get
            {
                return new ContaBancariaRepository(this._contexto);
            }
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }

        public void Dispose()
        {
            if (this._contexto != null)
                this._contexto.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
