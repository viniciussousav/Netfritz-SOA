using NetfritzServices.ComprasServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Repositories
{
    public interface IComprasRepository
    {
        Task<List<Compra>> ObterCompras();

        Task<Compra> ObterCompraPorId(string id);

        Task<List<Compra>> ObterComprasPorClienteId(string clienteId);

        Task InserirCompra(Compra compra);
    }
}
