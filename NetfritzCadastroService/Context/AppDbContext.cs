using Microsoft.EntityFrameworkCore;
using NetfritzCadastroService.Domain.Models;

namespace NetfritzCadastroService.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Administrador> Administradors { get; set; }
    }
}