using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetfritzServices.FitasService.Domain.Models;
using NetfritzServices.FitasService.Domain.Repositories;
using NetfritzServices.FitasService.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.FitasService.Domain.Controladores
{
    public class FitaControlador
    {
        private readonly IFitaRepository _fitaRepository;

        public FitaControlador(IFitaRepository fitaRepository)
        {
            _fitaRepository = fitaRepository;
        }

        public async Task<IActionResult> ObterFitas()
        {
            try
            {
                var fitas = await _fitaRepository.ObterFitas();
                return Response.CreateResponse(fitas, StatusCodes.Status200OK);
            }
            catch (Exception)
            {

                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> ObterFitaPorId(string id)
        {
            try
            {
                var fita = await _fitaRepository.ObterFitaPorId(id);

                if (fita is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                return Response.CreateResponse(fita, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> CadastrarFita(Fita fita)
        {
            try
            {
                var fitas = await _fitaRepository.ObterFitas();

                var tituloJaExiste = fitas.Any(f => f.Titulo == fita.Titulo);
                if (tituloJaExiste)
                {
                    return Response.CreateResponse("Fita com mesmo título já existente", StatusCodes.Status409Conflict);
                }

                await _fitaRepository.CadastrarFita(fita);
                return Response.CreateResponse("Fita criada com sucesso", StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> AtualizarFita(string id, Fita fita)
        {
            try
            {
                var fitaToUpdate = await _fitaRepository.ObterFitaPorId(id);

                if (fitaToUpdate is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                await _fitaRepository.AtualizarFita(fita);
                return Response.CreateResponse("Fita atualizada com sucesso", StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IActionResult> RemoverFita(string id)
        {
            try
            {
                var fita = await _fitaRepository.ObterFitaPorId(id);

                if (fita is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                await _fitaRepository.AtualizarFita(fita);
                return Response.CreateResponse("Fita removida com sucesso", StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro ao realizar operação", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
