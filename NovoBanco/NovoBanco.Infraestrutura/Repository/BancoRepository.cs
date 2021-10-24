using Microsoft.EntityFrameworkCore;
using NovoBanco.Dominio.Entidades;
using NovoBanco.Dominio.Repositories;
using NovoBanco.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovoBanco.Infraestrutura.Repository
{
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(AppDbContext contexto) : base(contexto) { }

        public Banco PegarPorId(int id)
        {
            IQueryable<Banco> query = _context.Bancos;

            query = query.AsNoTracking()
                .Where(b => b.Id == id);

            return query.FirstOrDefault();
        }

        public List<Banco> ListarTodosBancos()
        {
            IQueryable<Banco> query = _context.Bancos;
            query = query.AsNoTracking().OrderBy(a => a.Nome);
            return query.ToList();
        }
    }
}
