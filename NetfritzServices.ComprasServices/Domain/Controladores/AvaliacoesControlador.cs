using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetfritzServices.ComprasServices.Domain.Models;
using NetfritzServices.ComprasServices.Domain.Repositories;
using NetfritzServices.ComprasServices.Domain.Shared;
using NetfritzServices.ComprasServices.Requests;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Controladores
{
    public class AvaliacoesControlador
    {

        private readonly IAvaliacoesRepository _avaliacoesRepository;
        private readonly IComprasRepository _comprasRepository;

        private readonly ClienteHttpRequest _clienteHttpRequest;

        public AvaliacoesControlador(IAvaliacoesRepository avaliacoesRepository, IComprasRepository comprasRepository)
        {
            _avaliacoesRepository = avaliacoesRepository;
            _comprasRepository = comprasRepository;

            _clienteHttpRequest = new ClienteHttpRequest();
        }

        public async Task<IActionResult> CriarAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                var compra = await _comprasRepository.ObterCompraPorId(avaliacao.CompraId);

                if(compra is null)
                {
                    return Response.CreateResponse("Compra não encontrada", StatusCodes.Status404NotFound);
                }

                await _avaliacoesRepository.CriarAvaliacao(avaliacao);
                return Response.CreateResponse("Avaliação criada com sucesso", StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterAvaliacaoPorId(string id)
        {
            try
            {
                var avaliacao = await _avaliacoesRepository.ObterAvaliacaoPorId(id);
                return Response.CreateResponse(avaliacao, StatusCodes.Status200OK);

            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterAvaliacoes()
        {
            try
            {
                var avaliacoes = await _avaliacoesRepository.ObterAvaliacoes();
                return Response.CreateResponse(avaliacoes, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterAvaliacoesPorCompra(string compraId)
        {
            try
            {
                var compra = await _comprasRepository.ObterCompraPorId(compraId);

                if (compra is null)
                {
                    return Response.CreateResponse("Compra não encontrada", StatusCodes.Status404NotFound);
                }

                var avaliacoes = await _avaliacoesRepository.ObterAvaliacoesPorCompra(compraId);
                return Response.CreateResponse(avaliacoes, StatusCodes.Status200OK);

            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterAvaliacoesPorUsuario(string clienteId)
        {
            try
            {
                var clienteExists =  await _clienteHttpRequest.CheckClientExists(clienteId);

                if (!clienteExists)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                var avaliacoes = await _avaliacoesRepository.ObterAvaliacoesPorUsuario(clienteId);
                return Response.CreateResponse(avaliacoes, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
