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
    public class ContaBancariaRepository : Repository<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(AppDbContext contexto) : base(contexto) { }

        public List<ContaBancaria> ListarTodasContas()
        {
            IQueryable<ContaBancaria> query = _context.ContasBancarias.Include(a => a.Banco);
            
            query = query.AsNoTracking().OrderBy(a => a.Nome);
            return query.ToList();
        }

        public List<ContaBancaria> ListarContasPorFiltro(string nome)
        {
            IQueryable<ContaBancaria> query = _context.ContasBancarias.Include(a => a.Banco);
            query = query.AsNoTracking().Where(a => a.Nome.Contains(nome)).OrderBy(a => a.Nome);
            return query.ToList();
        }
    }
}
