using System.Threading.Tasks;
using NetfritzServices.CadastroService.Domain.Models;

namespace NetfritzServices.CadastroService.Domain.Repositories
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