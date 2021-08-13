
using Microsoft.EntityFrameworkCore;
using NetfritzServices.FitasService.Context;
using NetfritzServices.FitasService.Domain.Models;
using NetfritzServices.FitasService.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetfritzServices.FitasService.Repositories
{
    public class FitaRepository : IFitaRepository
    {
        private readonly AppDbContext _context;

        public FitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fita>> ObterFitas()
        {
            return await _context.Fitas.AsNoTracking().ToListAsync();
        }

        public async Task<Fita> ObterFitaPorId(string id)
        {
            return await _context.Fitas.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task CadastrarFita(Fita fita)
        {
            await _context.Fitas.AddAsync(fita);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarFita(Fita fita)
        {
            _context.Fitas.Update(fita);
            await _context.SaveChangesAsync();
        }
       
        public async Task RemoverFita(Fita fita)
        {
            _context.Fitas.Remove(fita);
            await _context.SaveChangesAsync();
        }
    }
}
