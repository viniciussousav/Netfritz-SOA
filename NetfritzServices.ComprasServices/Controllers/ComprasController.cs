using Microsoft.AspNetCore.Mvc;
using NetfritzServices.ComprasServices.Domain.Controladores;
using NetfritzServices.ComprasServices.Domain.Models;
using NetfritzServices.ComprasServices.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Controllers
{
    [ApiController]
    [Route("compras")]
    public class ComprasController
    {
        private readonly ComprasControlador _comprasControlador;

        public ComprasController(IComprasRepository comprasRepository)
        {
            _comprasControlador = new ComprasControlador(comprasRepository);
        }

        [HttpGet]
        public async Task<IActionResult> ObterCompras()
        {
            return await _comprasControlador.ObterCompras();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCompraPorId(string id)
        {
            return await _comprasControlador.ObterCompraPorId(id);
        }

        [HttpPost]
        public async Task<IActionResult> InserirCompra([FromBody] Compra compra)
        {
            return await _comprasControlador.InserirCompra(compra);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> ObterComprasPorClienteId(string clienteId)
        {
            return await _comprasControlador.ObterComprasPorClienteId(clienteId);
        }

       
    }
}
