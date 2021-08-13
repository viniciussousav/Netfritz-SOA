using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetfritzServices.CadastroService.Context;
using NetfritzServices.CadastroService.Domain.Models;
using NetfritzServices.CadastroService.Domain.Repositories;

namespace NetfritzCadastroService.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly AppDbContext _context;

        public CadastroRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> Login(string email, string senha)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<List<Cliente>> ObterClientes()
        {
            return await _context.Clientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> ObterClientePorId(string clienteId)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == clienteId);
        }

        public async Task InserirCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}