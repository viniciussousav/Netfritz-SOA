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
    public class AvaliacoesRepository : IAvaliacoesRepository
    {
        private readonly AppDbContext _context;

        public AvaliacoesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CriarAvaliacao(Avaliacao avaliacao)
        {
            await _context.Avaliacaos.AddAsync(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Avaliacao> ObterAvaliacaoPorId(string id)
        {
            return await _context.Avaliacaos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Avaliacao>> ObterAvaliacoes()
        {
            return await _context.Avaliacaos.ToListAsync();
        }

        public async Task<List<Avaliacao>> ObterAvaliacoesPorCompra(string compraId)
        {
            return await _context.Avaliacaos.Where(a => a.CompraId == compraId).ToListAsync();
        }

        public async Task<List<Avaliacao>> ObterAvaliacoesPorUsuario(string clienteId)
        {
            return await _context.Avaliacaos.ToListAsync();
        }
    }
}
