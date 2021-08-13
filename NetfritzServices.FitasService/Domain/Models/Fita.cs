using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetfritzServices.FitasService.Domain.Models
{
    public class Fita
    {
        public Fita(string titulo, decimal valor, int ano, string descricao)
        {
            Titulo = titulo;
            Valor = valor;
            Ano = ano;
            Descricao = descricao;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; private set; }

        [Required]
        public string Titulo { get; private set; }

        [Required]
        public string Descricao { get; private set; }

        [Required]
        public decimal Valor { get; private set; }

        [Required]
        public int Ano { get; private set; }

        public string ImagemUrl { get; set; }
    }
}
