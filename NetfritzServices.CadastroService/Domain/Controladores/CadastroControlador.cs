using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetfritzServices.CadastroService.Domain.Models;
using NetfritzServices.CadastroService.Domain.Repositories;
using NetfritzServices.CadastroService.Domain.Shared;

namespace NetfritzServices.CadastroService.Domain.Controladores
{
    public class CadastroControlador
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroControlador(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        public async Task<IActionResult> Login(Login login)
        {
            var usuario = await _cadastroRepository.Login(login.Email, login.Senha);

            if (usuario is null)
            {
                return Response.CreateResponse("Usuário não encontrado", StatusCodes.Status404NotFound);
            }

            return Response.CreateResponse(usuario, StatusCodes.Status200OK);
        }



        public async Task<IActionResult> ObterClientePorId(string clienteId)
        {
            var cliente = await _cadastroRepository.ObterClientePorId(clienteId);

            if (cliente is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }

            return Response.CreateResponse(cliente, StatusCodes.Status200OK);
        }

        public async Task<IActionResult> InserirCliente(Cliente cliente)
        {
            var clientes = await _cadastroRepository.ObterClientes();

            var emailDuplicated = clientes.Any(c => c.Email == cliente.Email);

            if (emailDuplicated)
            {
                return Response.CreateResponse("Email já utilizado", StatusCodes.Status409Conflict);
            }

            await _cadastroRepository.InserirCliente(cliente);
            return Response.CreateResponse("Cliente cadastrado", StatusCodes.Status200OK);
        }

        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            var clienteToUpdate = await _cadastroRepository.ObterClientePorId(cliente.Id);

            if (clienteToUpdate is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }

            await _cadastroRepository.AtualizarCliente(cliente);
            return Response.CreateResponse("Cliente atualizado", StatusCodes.Status200OK);
        }

        public async Task<IActionResult> RemoverCliente(string clienteId)
        {
            var clienteToUpdate = await _cadastroRepository.ObterClientePorId(clienteId);

            if (clienteToUpdate is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }

            await _cadastroRepository.AtualizarCliente(clienteToUpdate);
            return Response.CreateResponse("Cliente atualizado", StatusCodes.Status200OK);
        }
    }
}