namespace NetfritzServices.CadastroService.Domain.Shared
{
    public class Login
    {
        public Login(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }

        public string Senha { get; private set; }
    }
}