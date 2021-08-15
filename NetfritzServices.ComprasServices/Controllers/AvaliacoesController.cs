using Microsoft.AspNetCore.Mvc;
using NetfritzServices.ComprasServices.Domain.Controladores;
using NetfritzServices.ComprasServices.Domain.Models;
using NetfritzServices.ComprasServices.Domain.Repositories;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Controllers
{
    [ApiController]
    [Route("avaliacoes")]
    public class AvaliacoesController
    {
        private readonly AvaliacoesControlador _avaliacoesControlador;

        public AvaliacoesController(IAvaliacoesRepository avaliacoesRepository, IComprasRepository comprasRepository)
        {
            _avaliacoesControlador = new AvaliacoesControlador(avaliacoesRepository, comprasRepository);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAvaliacao(Avaliacao avaliacao)
        {
            return await _avaliacoesControlador.CriarAvaliacao(avaliacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAvaliacaoPorId(string id)
        {
            return await _avaliacoesControlador.ObterAvaliacaoPorId(id);
        }

        [HttpGet]
        public async Task<IActionResult> ObterAvaliacoes()
        {
            return await _avaliacoesControlador.ObterAvaliacoes();
        }

        [HttpGet("compra/{compraId}")]
        public async Task<IActionResult> ObterAvaliacoesPorCompra(string compraId)
        {
            return await _avaliacoesControlador.ObterAvaliacoesPorCompra(compraId);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> ObterAvaliacoesPorUsuario(string clienteId)
        {
            return await _avaliacoesControlador.ObterAvaliacoesPorUsuario(clienteId);
        }
    }
}
