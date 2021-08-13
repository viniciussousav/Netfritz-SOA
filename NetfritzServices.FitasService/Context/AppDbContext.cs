using Microsoft.EntityFrameworkCore;
using NetfritzServices.FitasService.Domain.Models;

namespace NetfritzServices.FitasService.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Fita> Fitas { get; set; }
    }
}
