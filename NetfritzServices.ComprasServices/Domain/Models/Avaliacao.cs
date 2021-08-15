using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Models
{
    public class Avaliacao
    {
        public Avaliacao(string compraId, string descricao, int nota)
        {
            CompraId = compraId;
            Descricao = descricao;
            Nota = nota;
        }

        [Key]
        public string Id { get; private set; }

        [Required]
        public string CompraId { get; private set; }

        [Required]
        public string Descricao { get; private set; }

        [Required]
        public int Nota { get; private set; }

    }
}
