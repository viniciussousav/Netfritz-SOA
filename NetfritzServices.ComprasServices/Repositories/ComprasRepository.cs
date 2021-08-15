using Microsoft.EntityFrameworkCore;
using NetfritzServices.ComprasServices.Context;
using NetfritzServices.ComprasServices.Domain.Models;
using NetfritzServices.ComprasServices.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly AppDbContext _context;

        public ComprasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Compra>> ObterCompras()
        {
            return await _context.Compras.AsNoTracking().ToListAsync();
        }

        public async Task InserirCompra(Compra compra)
        {
            await _context.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Compra>> ObterComprasPorClienteId(string clienteId)
        {
            return await _context.Compras.AsNoTracking().Where(c => c.ClienteId == clienteId).ToListAsync();
        }

        public async Task<Compra> ObterCompraPorId(string id)
        {
            return await _context.Compras.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
