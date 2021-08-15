using NetfritzServices.ComprasServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Repositories
{
    public interface IAvaliacoesRepository
    {
        Task<List<Avaliacao>> ObterAvaliacoes();

        Task<List<Avaliacao>> ObterAvaliacoesPorUsuario(string usuarioId);

        Task<List<Avaliacao>> ObterAvaliacoesPorCompra(string compraId);

        Task<Avaliacao> ObterAvaliacaoPorId(string id);

        Task CriarAvaliacao(Avaliacao avaliacao);
    }
}
