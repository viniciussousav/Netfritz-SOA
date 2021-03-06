using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetfritzServices.CadastroService.Domain.Models
{
    [Table("Usuarios")]
    public abstract class Usuario
    {
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCriacao = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }

        [Required]
        public string Nome { get; protected set; }

        [Required]
        public string Email { get; protected set; }

        [Required]
        public string Senha { get; protected set; }

        public DateTime DataCriacao { get; protected set; }
    }
}