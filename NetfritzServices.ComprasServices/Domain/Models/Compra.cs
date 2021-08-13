using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Models
{
    public class Compra
    {
        public Compra(string clienteId, string fitaId)
        {
            ClienteId = clienteId;
            FitaId = fitaId;
            DataCompra = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; private set; }

        [Required]
        public string ClienteId { get; private set; }

        [Required]
        public string FitaId { get; private set; }

        public DateTime DataCompra { get; }
    }
}
