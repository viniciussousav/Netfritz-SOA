using System.Threading.Tasks;
using NetfritzCadastroService.Domain.Models;

namespace NetfritzCadastroService.Domain.Repositories
{
    public interface ICadastroRepository
    {
        Task<Usuario> login(string email, string senha);

        Task<Cliente> obterClientePorId(string clienteId);

        Task InserirCliente(Cliente cliente);

        Task AtualizarCliente(Cliente cliente);

        Task RemoverCliente(Cliente cliente);
    }
}