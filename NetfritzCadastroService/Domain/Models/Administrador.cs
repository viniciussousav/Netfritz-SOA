namespace NetfritzCadastroService.Domain.Models
{
    public class Administrador : Usuario
    {
        public Administrador(string nome, string email, string senha) : base(nome, email, senha)
        {
        }
    }
}