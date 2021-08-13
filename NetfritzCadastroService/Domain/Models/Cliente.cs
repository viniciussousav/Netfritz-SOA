using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetfritzServices.CadastroService.Domain.Models
{
    [Table("Clientes")]
    public class Cliente : Usuario
    {
        public Cliente(string nome, string email, string senha, string cartao, DateTime dataNascimento) : base(nome, email, senha)
        {
            Cartao = cartao;
            DataNascimento = dataNascimento;
        }

        [Required]
        public string Cartao { get; private set; }

        [Required]
        public DateTime DataNascimento { get; private set; }
        public object Any { get; internal set; }
    }
}