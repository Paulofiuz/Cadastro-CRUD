using CadastroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Data;

public class AppDbContext : DbContext
{

      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

     public DbSet<Usuario> Usuarios { get; set; }
}
