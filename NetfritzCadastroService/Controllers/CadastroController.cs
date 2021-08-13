using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetfritzServices.CadastroService.Domain.Controladores;
using NetfritzServices.CadastroService.Domain.Models;
using NetfritzServices.CadastroService.Domain.Repositories;
using NetfritzServices.CadastroService.Domain.Shared;

namespace NetfritzServices.CadastroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroControlador _cadastroControlador;
        
        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroControlador = new CadastroControlador(cadastroRepository);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            return await _cadastroControlador.Login(login);
        }
        
        [HttpGet("cliente/{id}")]
        public async Task<IActionResult> ObterClientePorId(string id)
        {
            return await _cadastroControlador.ObterClientePorId(id);
        }

        [HttpPost("cliente")]
        public async Task<IActionResult> InserirCliente([FromBody] Cliente cliente)
        {
            return await _cadastroControlador.InserirCliente(cliente);
        }
        
        [HttpPut("cliente")]
        public async Task<IActionResult> AtualizarCliente([FromBody] Cliente cliente)
        {
            return await _cadastroControlador.AtualizarCliente(cliente);
        }
        
        [HttpDelete("cliente/{id}")]
        public async Task<IActionResult> RemoverCliente(string id)
        {
            return await _cadastroControlador.RemoverCliente(id);
        }
    }
}