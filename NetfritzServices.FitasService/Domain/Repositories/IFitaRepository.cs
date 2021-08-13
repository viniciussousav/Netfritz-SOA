using NetfritzServices.FitasService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.FitasService.Domain.Repositories
{
    public interface IFitaRepository
    {
        Task<List<Fita>> ObterFitas();
        Task<Fita> ObterFitaPorId(string id);
        Task CadastrarFita(Fita fita);
        Task AtualizarFita(Fita fita);
        Task RemoverFita(Fita fita);
    }
}
