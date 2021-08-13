using System.ComponentModel.DataAnnotations.Schema;

namespace NetfritzServices.CadastroService.Domain.Models
{
    [Table("Administradores")]
    public class Administrador : Usuario
    {
        public Administrador(string nome, string email, string senha) : base(nome, email, senha)
        {
        }
    }
}