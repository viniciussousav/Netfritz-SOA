using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetfritzCadastroService.Context;
using NetfritzCadastroService.Domain.Models;
using NetfritzCadastroService.Domain.Repositories;

namespace NetfritzCadastroService.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly AppDbContext _context;

        public CadastroRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> login(string email, string senha)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<Cliente> obterClientePorId(string clienteId)
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