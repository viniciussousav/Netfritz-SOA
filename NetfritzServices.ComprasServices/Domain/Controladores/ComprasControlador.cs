using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetfritzServices.ComprasServices.Domain.Models;
using NetfritzServices.ComprasServices.Domain.Repositories;
using NetfritzServices.ComprasServices.Domain.Shared;
using NetfritzServices.ComprasServices.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Controladores
{
    public class ComprasControlador
    {
        private readonly IComprasRepository _comprasRepository;

        private readonly ClienteHttpRequest _clienteHttpRequest;
        private readonly FitaHttpRequest _fitaHttpRequest;


        public ComprasControlador(IComprasRepository comprasRepository)
        {
            _comprasRepository = comprasRepository;

            _clienteHttpRequest = new ClienteHttpRequest();
            _fitaHttpRequest = new FitaHttpRequest();
        }

        public async Task<IActionResult> ObterCompras()
        {
            try
            {
                var compras = await _comprasRepository.ObterCompras();
                return Response.CreateResponse(compras, StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> InserirCompra(Compra compra)
        {
            try
            {
                var clienteExists = await _clienteHttpRequest.CheckClientExists(compra.ClienteId);
                var fitaExists = await _fitaHttpRequest.CheckFitaExists(compra.FitaId);

                if (clienteExists == false)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                if (fitaExists == false)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }


                await _comprasRepository.InserirCompra(compra);
                return Response.CreateResponse("Compra realizada com sucesso", StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return Response.CreateResponse("Erro ao realizar operação " + e.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterComprasPorClienteId(string clienteId)
        {
            try
            {
                var clienteExists = await _clienteHttpRequest.CheckClientExists(clienteId);

                if (clienteExists == false)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                var compras = await _comprasRepository.ObterComprasPorClienteId(clienteId);
                return Response.CreateResponse(compras, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterCompraPorId(string id)
        {
            try
            {
                var compra = await _comprasRepository.ObterCompraPorId(id);

                if (compra is null)
                {
                    return Response.CreateResponse("Compra não encontrada", StatusCodes.Status404NotFound);
                }

                return Response.CreateResponse(compra, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
