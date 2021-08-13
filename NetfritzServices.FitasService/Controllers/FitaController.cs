using Microsoft.AspNetCore.Mvc;
using NetfritzServices.FitasService.Domain.Controladores;
using NetfritzServices.FitasService.Domain.Models;
using NetfritzServices.FitasService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.FitasService.Controllers
{
    [ApiController]
    [Route("fitas")]
    public class FitaController
    {
        private readonly FitaControlador _fitaControlador;

        public FitaController(IFitaRepository fitaRepository)
        {
            _fitaControlador = new FitaControlador(fitaRepository);
        }

        [HttpGet]
        public async Task<IActionResult> ObterFitas()
        {
            return await _fitaControlador.ObterFitas();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFita([FromBody] Fita fita)
        {
            return await _fitaControlador.CadastrarFita(fita);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterFitaPorId(string id)
        {
            return await _fitaControlador.ObterFitaPorId(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFita(string id, [FromBody] Fita fita)
        {
            return await _fitaControlador.AtualizarFita(id, fita);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverFita(string id)
        {
            return await _fitaControlador.RemoverFita(id);
        }
    }
}
