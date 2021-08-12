using System;
using System.ComponentModel.DataAnnotations;

namespace NetfritzCadastroService.Domain.Models
{
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
    }
}