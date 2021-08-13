using System.Collections.Generic;
using System.Threading.Tasks;
using NetfritzServices.CadastroService.Domain.Models;

namespace NetfritzServices.CadastroService.Domain.Repositories
{
    public interface ICadastroRepository
    {
        Task<Usuario> Login(string email, string senha);

        Task<List<Cliente>> ObterClientes();
        
        Task<Cliente> ObterClientePorId(string clienteId);

        Task InserirCliente(Cliente cliente);

        Task AtualizarCliente(Cliente cliente);

        Task RemoverCliente(Cliente cliente);
    }
}