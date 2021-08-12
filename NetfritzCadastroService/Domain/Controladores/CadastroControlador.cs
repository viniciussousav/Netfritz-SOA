﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetfritzCadastroService.Domain.Models;
using NetfritzCadastroService.Domain.Repositories;
using NetfritzCadastroService.Domain.Shared;

namespace NetfritzCadastroService.Domain.Controladores
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
            var usuario = await _cadastroRepository.login(login.Email, login.Senha);

            if (usuario is null)
            {
                return Response.CreateResponse("Usuário não encontrado", StatusCodes.Status404NotFound);
            }

            return Response.CreateResponse(usuario, StatusCodes.Status200OK);
        }

        public async Task<IActionResult> ObterClientePorId(string clienteId)
        {
            var cliente = await _cadastroRepository.obterClientePorId(clienteId);
            
            if (cliente is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }

            return Response.CreateResponse(cliente, StatusCodes.Status200OK);
        }

        public async Task<IActionResult> InserirCliente(Cliente cliente)
        {
            var clienteDuplicated = await _cadastroRepository.obterClientePorId(cliente.Id);
            
            if (clienteDuplicated is null)
            {
                return Response.CreateResponse("Email já utilizado", StatusCodes.Status409Conflict);
            }

            await _cadastroRepository.InserirCliente(cliente);
            return Response.CreateResponse("Cliente cadastrado", StatusCodes.Status200OK);
        }

        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            var clienteToUpdate = await _cadastroRepository.obterClientePorId(cliente.Id);
            
            if (clienteToUpdate is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }
            
            await _cadastroRepository.AtualizarCliente(cliente);
            return Response.CreateResponse("Cliente atualizado", StatusCodes.Status200OK);
        }
        
        public async Task<IActionResult> RemoverCliente(string clienteId)
        {
            var clienteToUpdate = await _cadastroRepository.obterClientePorId(clienteId);
            
            if (clienteToUpdate is null)
            {
                return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
            }
            
            await _cadastroRepository.AtualizarCliente(clienteToUpdate);
            return Response.CreateResponse("Cliente atualizado", StatusCodes.Status200OK);
        }
    }
}